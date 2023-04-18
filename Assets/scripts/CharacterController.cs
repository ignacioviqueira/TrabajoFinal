using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private float speed;
    [SerializeField] private float rotation;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform pointOfShoot;
    [SerializeField] private ZombieController ZombieController;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerToCollide;
    [SerializeField] private Transform eyesTransform;
    [SerializeField] private Transform particlesPoint;
    [SerializeField] private ParticleSystemController m_particleSystem;
    [SerializeField] private GameObject miraImagen;
    private int numberOfBullets = 30;
    private float currentTIme = 0;

    public Action<float> OnBulletsChange;
    public UnityEvent<int> OnHealthChange;
    


    private void Start()
    {
        GameManager.instance.ObtainPlayerReference(this);
        miraImagen.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= (transform.right * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += (transform.right * speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += (transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= (transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0f, rotation, 0f) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0f, -rotation, 0f) * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        Raycast();
        
    }

    private void Raycast()
    {
        RaycastHit hit;

        var collideWithSomething = Physics.Raycast(eyesTransform.position, transform.forward, out hit, maxDistance, layerToCollide);
        if (collideWithSomething)
        {
            miraImagen.SetActive(true);
        }
        else
        {
            miraImagen.SetActive(false);
        }
      
    }

    private void Shoot()
    {
        Instantiate(bullet, pointOfShoot);
        numberOfBullets--;
        if (numberOfBullets == 0)
        {
            numberOfBullets = 30;
        }
        OnBulletsChange.Invoke(numberOfBullets);
    }

    public void DamageCharacter()
    {
        currentTIme += Time.deltaTime;
        if(currentTIme > 0.5)
        {
            life -= 1;
            currentTIme = 0;
            OnHealthChange.Invoke(life);
            Instantiate(m_particleSystem, particlesPoint);

        }
    }

}
    

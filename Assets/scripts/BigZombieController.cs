using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class BigZombieController : Enemy
{
    [SerializeField] protected ZombieData zombieData;
    [SerializeField] private Dificulty dificulty;
    private float currentTime;
    [SerializeField] private Transform eyesTransform;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Bullet bullet;
    private TextController textController;
    private CharacterController characterController;






    private void Start()
    {
        switch (dificulty)
        {
            case Dificulty.Easy:
                zombieData.zombieLife = 100;
                break;
            case Dificulty.MediumEasy:
                zombieData.zombieLife = 150;
                break;
            case Dificulty.MediumHard:
                zombieData.zombieLife = 200;
                break;
            case Dificulty.Hard:
                zombieData.zombieLife = 250;
                break;
            default:
                Debug.LogError("Invalid state.");
                break;

        }

        transform.localScale = Vector3.one * 2;
        characterController = GameObject.Find("player").GetComponent<CharacterController>();
        textController = GameObject.Find("TextController").GetComponent<TextController>();

    }

    void Update()
    {
        FollowPlayer();
        LookAtPlayer();
        KillZombie();
        IncreaseSpeed();
    }

    private void IncreaseSpeed()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= 10)
        {
            speed = 2;
        }

    }

    public void DamageZombie()
    {
        zombieData.zombieLife -= 50;
    }
    private void KillZombie()
    {
        if (zombieData.zombieLife <= 0)
        {
            Destroy(gameObject);
            textController.UpdateBigZombiesUI();
        }
    }

    public void RaycastDartZombie()
    {
        RaycastHit hit;
        var collidedWithSomething = Physics.Raycast(eyesTransform.position, transform.forward, out hit, maxDistance, layerMask);

        if (collidedWithSomething)
        {
            characterController.DamageCharacter();
        }
    }
}

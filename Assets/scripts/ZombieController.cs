using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

enum Dificulty
{
    Easy,
    MediumEasy,
    MediumHard,
    Hard
}

public class ZombieController : Enemy
{
    [SerializeField] private ZombieData zombieData;
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
        textController = GameObject.Find("TextController").GetComponent<TextController>();

        characterController = GameObject.Find("player").GetComponent<CharacterController>();
        
    }

    void Update()
    {
        FollowPlayer();
        LookAtPlayer();
        KillZombie();
        IncreaseSpeed();
        RaycastDartZombie();
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
        if(zombieData.zombieLife <= 0)
        {
            Destroy(gameObject);
            textController.UpdateZombiesUI();
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

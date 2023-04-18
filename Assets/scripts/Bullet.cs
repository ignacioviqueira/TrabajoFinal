using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{

    [SerializeField] private BulletData bulletData;
    [SerializeField] private float currentTime;

    void Update()
    {
        transform.position += transform.forward * (bulletData.speed * Time.deltaTime);
        DestroyBullet();
    }

    private void OnTriggerEnter(Collider other)
    {
        var l_zombie = other.GetComponent<ZombieController>();
        var l_BigZombie = other.GetComponent<BigZombieController>();
        if(l_zombie != null)
        {
            l_zombie.DamageZombie();
            Destroy(gameObject);
        }
        else if(l_BigZombie != null)
        {
            l_BigZombie.DamageZombie();
            Destroy(gameObject);
        }

    }

    private void DestroyBullet()
    {
        currentTime += Time.deltaTime;
        if (currentTime > 1.5)
        {
            Destroy(gameObject);
        }
    }


}

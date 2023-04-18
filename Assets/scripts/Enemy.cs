using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
     
    [SerializeField] protected float speed;
    [SerializeField] protected float rotationSpeed;

    protected void FollowPlayer()
    {
        var vectorToPlayer = GameManager.instance.player.gameObject.transform.position - transform.position;
        transform.position += vectorToPlayer.normalized * (speed * Time.deltaTime);
    }
    protected void LookAtPlayer()
    {
        var vectorToPlayer = GameManager.instance.player.gameObject.transform.position - transform.position;
        var newRotation = Quaternion.LookRotation(vectorToPlayer);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
    }
}

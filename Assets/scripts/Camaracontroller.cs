using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Camaracontroller : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float lerpValue;
    [SerializeField] private float sensibility;


    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,target.position + offset, lerpValue);
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibility, Vector3.up) * offset;
        transform.LookAt(target);
    }
}

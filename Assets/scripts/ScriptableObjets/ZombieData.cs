using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Entity/ZombieData")]
public class ZombieData : ScriptableObject
{
    [SerializeField] protected string zombieName;
    [SerializeField] public int zombieLife;
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ButtonUI : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public void DesactivarUI()
    {
        object1.SetActive(false);
        object2.SetActive(false);
    }




}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TextController : MonoBehaviour
{
    [SerializeField] private TMP_Text textBullets;
    [SerializeField] private TMP_Text textZombies;
    [SerializeField] private TMP_Text textHeart;
    [SerializeField] private CharacterController characterController;
    public int count = 1;
    public event Action OnZombieUpdate;
    public UnityEvent OnBigZombieUpdate;


    private void Start()
    {
        characterController.OnBulletsChange += UpdateBulletsUI;
        characterController.OnHealthChange.AddListener(UpdateHeartUI);
        

    }


    public void UpdateBulletsUI(float p_currentBullets)
    {
        textBullets.text = p_currentBullets.ToString();
    }

    public void UpdateZombiesUI()
    {
        textZombies.text = count.ToString();
        count++;
        OnZombieUpdate.Invoke();
    }

    public void UpdateBigZombiesUI()
    {
        textZombies.text = count.ToString();
        count++;
        OnBigZombieUpdate.Invoke();
    }

    public void UpdateHeartUI(int p_currentHealth)
    {
        textHeart.text = p_currentHealth.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextController controller;
    [SerializeField] private TMP_Text textScore;
    private void Start()
    {
        controller.OnZombieUpdate += UpdateScore;
    }

    private void Update()
    {
        textScore.text = score.ToString();
    }

    private void UpdateScore()
    {
        score += 10;
    }

    public void UpdateScore2()
    {
        score += 20;
    }

    public void UpdateScore3()
    {
        score -= 25;
    }
}

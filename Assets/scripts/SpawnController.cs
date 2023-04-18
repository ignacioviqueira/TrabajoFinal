using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private float currentTime;
    [SerializeField] private Enemy[] zombiesRonda1;
    [SerializeField] private List <Enemy> zombiesRonda2;
    [SerializeField] private Enemy[] zombiesRonda3;
    [SerializeField] private TextController textController;

    private int count = 0;
    private int count2 = 0;
    private int count3 = 0;


    void Update()
    {
        if (count < zombiesRonda1.Length)
        {
            currentTime += Time.deltaTime;
            if (currentTime > 4)
            {
                SpawnZombies(zombiesRonda1);
                currentTime = 0;

            }
        }
        else if ( textController.count == 6 && count2 < zombiesRonda2.Capacity)
        {
            currentTime += Time.deltaTime;
            if (currentTime > 4)
            {
                SpawnZombiesRound2(zombiesRonda2);
                currentTime = 0;

            }
        }
        else if (textController.count == 16 && count3 < zombiesRonda3.Length)
        {
            currentTime += Time.deltaTime;
            if (currentTime > 4)
            {
                SpawnZombies(zombiesRonda3);
                currentTime = 0;

            }
        }
        
    }

    private void SpawnZombies(Enemy[] p_zombies)
    {
        Instantiate(p_zombies[count],transform);
        count++;
    }

    private void SpawnZombiesRound2(List<Enemy> p_zombiesRound2)
    {
        Instantiate(p_zombiesRound2[count2],transform);
        count2++;
    }
}

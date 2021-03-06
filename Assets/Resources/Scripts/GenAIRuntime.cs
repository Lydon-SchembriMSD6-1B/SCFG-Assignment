﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenAIRuntime : MonoBehaviour
{

    positionRecord ObstaclePos;

    GameObject AIObj;
    // Start is called before the first frame update
    void Start()
    {

        AIObj = Resources.Load<GameObject>("Prefabs/AI-Task2");

        for (int i = 0; i < 10; i++)
        {
            ObstaclePos = new positionRecord();

            float randomX = Mathf.Floor(Random.Range(-49f, 49f));

            float randomY = Mathf.Floor(Random.Range(-49f, 49f));

            Vector3 randomLocation = new Vector3(randomX, randomY);

            //don't allow the food to be spawned on other food

            ObstaclePos.Position = randomLocation;


            ObstaclePos.ObstacleObject = Instantiate(AIObj, randomLocation, Quaternion.Euler(0f, 0f, 0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

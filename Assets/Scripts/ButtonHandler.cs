using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public GameManager gameManager;
    public FileWriter fileWriter;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)) // Red
        {
            gameManager.showNextText = true;
            if ((int)gameManager.data[gameManager.nowTrial]["Word"] == 0) gameManager.trialAccuracy += 1;
            fileWriter.WriteTracking(gameManager.nowTrial, (int)gameManager.data[gameManager.nowTrial]["Type"], gameManager.trialTime, gameManager.trialAccuracy,gameManager.realTime);
            gameManager.nowTrial += 1;
        }

        if (Input.GetKeyDown(KeyCode.S)) // Blue
        {
            gameManager.showNextText = true;
            if ((int)gameManager.data[gameManager.nowTrial]["Word"] == 1) gameManager.trialAccuracy += 1;
            fileWriter.WriteTracking(gameManager.nowTrial, (int)gameManager.data[gameManager.nowTrial]["Type"], gameManager.trialTime, gameManager.trialAccuracy,gameManager.realTime);
            gameManager.nowTrial += 1;
        }

        if (Input.GetKeyDown(KeyCode.D)) // Yellow
        {
            gameManager.showNextText = true;
            if ((int)gameManager.data[gameManager.nowTrial]["Word"] == 2) gameManager.trialAccuracy += 1;
            fileWriter.WriteTracking(gameManager.nowTrial, (int)gameManager.data[gameManager.nowTrial]["Type"], gameManager.trialTime, gameManager.trialAccuracy,gameManager.realTime);
            gameManager.nowTrial += 1;
        }

        if (Input.GetKeyDown(KeyCode.F)) // Green
        {
            gameManager.showNextText = true;
            if ((int)gameManager.data[gameManager.nowTrial]["Word"] == 3) gameManager.trialAccuracy += 1;
            fileWriter.WriteTracking(gameManager.nowTrial, (int)gameManager.data[gameManager.nowTrial]["Type"], gameManager.trialTime, gameManager.trialAccuracy,gameManager.realTime);
            gameManager.nowTrial += 1;
        }

        else
        {            
            fileWriter.WriteTracking(gameManager.nowTrial, (int)gameManager.data[gameManager.nowTrial]["Type"], gameManager.trialTime, gameManager.trialAccuracy,gameManager.realTime);
        }
    }
}

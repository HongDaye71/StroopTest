using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI stroopTaskWord;
    
    public float trialTime;
    public float realTime;

    public int trialAccuracy;
    public int nowTrial;
    public int trialType;
    
    public bool showNextText;

    public List<Dictionary<string, object>> data;
    public float[,] colorInfo;

    void Awake()
    {
        realTime = 5;
        nowTrial = 0;
        colorInfo = new float[4, 4] { { 255 / 255f, 10 / 255f, 10 / 255f, 255 / 255f }, { 0 / 255f, 0 / 255f, 255 / 255f, 255 / 255f }, { 249 / 255f, 215 / 255f, 28 / 255f, 255 / 255f }, { 4 / 255f, 99 / 255f, 7 / 255f, 255 / 255f } };

        data = CSVReader.Read("Event");

        for (var i = 0; i < data.Count; i++)
        {
            print(data[i]["Word"] + " " + data[i]["ColorofText"] + " " + data[i]["Type"]);
        }
    }

    void Update()
    {
        realTime += Time.deltaTime;
        if (nowTrial >= 0 && nowTrial < data.Count)
        {
            if (showNextText) TrialReset();
            else if (!showNextText) TrialProcess();
            trialTime += Time.deltaTime;
        }
        else
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }

    void TrialReset()
    {
        showNextText = false;
        trialTime = 0.0f;
    }

    void TrialProcess()
    {
        float c1 = colorInfo[(int)data[nowTrial]["ColorofText"], 0];
        float c2 = colorInfo[(int)data[nowTrial]["ColorofText"], 1];
        float c3 = colorInfo[(int)data[nowTrial]["ColorofText"], 2];
        float c4 = colorInfo[(int)data[nowTrial]["ColorofText"], 3];
        
        switch((int)data[nowTrial]["Word"])
        {
            case 0:
                stroopTaskWord.GetComponent<TextMeshProUGUI>().text = "Red";
                break;
            case 1:
                stroopTaskWord.GetComponent<TextMeshProUGUI>().text = "Blue";
                break;
            case 2:
                stroopTaskWord.GetComponent<TextMeshProUGUI>().text = "Yellow";
                break;
            case 3:
                stroopTaskWord.GetComponent<TextMeshProUGUI>().text = "Green";
                break;
        }
        stroopTaskWord.GetComponent<TextMeshProUGUI>().color = new Color(c1, c2, c3, c4);
    }
}

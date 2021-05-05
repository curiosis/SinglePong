using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int[] points = {5, 10, 15, 20, 30, 50, 75, 100, 125, 150, 250, 350, 500};

    public TextMeshProUGUI scoreText, speedText, LevelText, actLevel;
    public static float score, time, countAudio = 0, rot;
    public static int levelNo;

    public GameObject helpRow;

    public SoundManager soundManager;

    public static bool paddleAudio = false, levelTextShow = false;

    private void OnEnable()
    {
        score = 0;
        levelNo = 0;
    }

    private void Update()
    {
        actLevel.text = "Level\n" + (levelNo + 1).ToString();

        helpRow.transform.eulerAngles = new Vector3(0,0,rot);

        if (paddleAudio)
        {
            paddleAudio = false;
            soundManager.PlaySound("paddle");
        }

        scoreText.text = score.ToString();
        speedText.text = "Ball speed: " + (Ball.speed * 50.0f).ToString() + "%";

        if (levelTextShow)
        {
            LevelText.text = "Level " + (levelNo+1) + "\n" + time;
            if (countAudio == 1)
                soundManager.PlaySound("count");
            if (countAudio == 2)
                soundManager.PlaySound("countEnd");
            countAudio = 0;
        }
        else
            LevelText.text = "";
            
    }
}

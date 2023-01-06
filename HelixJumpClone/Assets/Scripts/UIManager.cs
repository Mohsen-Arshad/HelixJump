using myTask;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject multiplierText;
    [SerializeField] private GameObject gameOverBackground;
    float textTimer = 0;

    void Start()
    {
        GameManager.instance.CorrectColor += Instance_CorrectColor;
        GameManager.instance.GameLose += Instance_GameLose; ;
    }

    private void Instance_GameLose()
    {
        gameOverBackground.SetActive(true);
    }

    private void Instance_CorrectColor()
    {
        if (ScoreManager.scoreMultiplier >= 1)
        {
            multiplierText.GetComponent<Text>().text = (ScoreManager.scoreMultiplier).ToString() + "X";
            multiplierText.SetActive(true);
            textTimer = 0;
        }
    }

    private void Update()
    {
        textTimer += Time.deltaTime;
        if (textTimer >= 0.6f)
        {
            multiplierText.SetActive(false);
        }
    }

    // Update is called once per frame

}

using myTask;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int scoreMultiplier = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.BallIsLanding += Instance_BallIsLanding;
        GameManager.instance.CorrectColor += Instance_CorrectColor;
    }

    private void Instance_CorrectColor()
    {
        scoreMultiplier++;
    }

    private void Instance_BallIsLanding()
    {
        scoreMultiplier = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

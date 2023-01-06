using myTask;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusRings : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlueBall") || collision.gameObject.CompareTag("YellowBall") || collision.gameObject.CompareTag("RedBall"))
        {
            GameManager.instance.LoseTheGame();
        }
    }
}

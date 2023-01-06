using myTask;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameManager.instance.FinishTheGame();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPaintRed : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.tag = "RedBall";
        collision.gameObject.GetComponent<Renderer>().material.color = new Color(255, 11, 62);
    }
}

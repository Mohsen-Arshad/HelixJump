using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPaintYellow : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.tag = "YellowBall";
        collision.gameObject.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color;
    }
}

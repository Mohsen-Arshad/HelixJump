using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPaintYellow : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.tag = "YellowBall";
        collision.gameObject.GetComponent<Renderer>().material.color = new Color(255, 242, 0);
    }
}

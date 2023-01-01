using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPaintCircle : MonoBehaviour
{
    string tagName;
    private void Start()
    {
        string tagName = gameObject.tag;
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (tagName)
        {
            case "BlueCircle":
                break;
            case "RedCircle":
                break;
            case "YellowCircle":
                break;
            default:
                break;
        }
        collision.gameObject.tag = "YellowBall";
        collision.gameObject.GetComponent<Renderer>().material.color = new Color(255, 242, 0);
    }
}

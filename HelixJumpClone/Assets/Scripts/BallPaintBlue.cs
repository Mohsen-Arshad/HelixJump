using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPaintBlue : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.tag = "BlueBall";
        collision.gameObject.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPaintBlue : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.tag = "BlueBall";
        collision.gameObject.GetComponent<Renderer>().material = collision.gameObject.GetComponent<Renderer>().materials[1];
    }
}

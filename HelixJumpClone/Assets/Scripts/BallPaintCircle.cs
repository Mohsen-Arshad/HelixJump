using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPaintCircle : MonoBehaviour
{
    [SerializeField] private string tagName;
    [SerializeField] private Color color;

    private void Start()
    {
        string tagName = gameObject.tag;
        color = gameObject.GetComponent<Renderer>().material.color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.color = color;
        collision.gameObject.tag = "BlueBall";
        //switch (tagName)
        //{
        //    case "BlueCircle":
        //        collision.gameObject.GetComponent<Renderer>().material.color = color;
        //        collision.gameObject.tag = "BlueBall";
        //        break;
        //    case "RedCircle":
        //        collision.gameObject.GetComponent<Renderer>().material.color = color;
        //        collision.gameObject.tag = "RedBall";
        //        break;
        //    case "YellowCircle":
        //        collision.gameObject.GetComponent<Renderer>().material.color = color;
        //        collision.gameObject.tag = "YellowBall";
        //        break;
        //    default:
        //        break;
        //}        
    }
}

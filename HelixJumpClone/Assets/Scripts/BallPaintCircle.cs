using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPaintCircle : MonoBehaviour
{
    [SerializeField] private string circleTagName;
    [SerializeField] private Color color;

    private void Start()
    {
        color = gameObject.GetComponent<Renderer>().material.color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        string circleTagName = gameObject.tag;
        Debug.Log(circleTagName);
        collision.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.color = color;
        switch (circleTagName)
        {
            case "BlueCircle":
                collision.gameObject.tag = "BlueBall";
                Debug.Log("Blue");
                break;
            case "RedCircle":
                collision.gameObject.tag = "RedBall";
                Debug.Log("Red");
                break;
            case "YellowCircle":
                collision.gameObject.tag = "YellowBall";
                Debug.Log("Yellow");
                break;
            default:
                break;
        }
    }
}

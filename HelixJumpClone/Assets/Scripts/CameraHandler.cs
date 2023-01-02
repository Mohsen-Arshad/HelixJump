using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public Transform player;
    private float xBallPosition;
    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x - 5.5f, transform.position.y, transform.position.z);
        }
    }
}

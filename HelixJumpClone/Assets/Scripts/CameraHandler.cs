using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x - 5f, transform.position.y, transform.position.z);
        }
    }
}

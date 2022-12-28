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
            transform.position = player.transform.position + new Vector3(0, 2, -4.5f);
        }
    }
}

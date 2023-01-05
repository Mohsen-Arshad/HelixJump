using myTask;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class JumpingSystem : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] public static float initialAngle = 40;

    bool foundNextTarget;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, Vector3.right, out hit, 500))
        {
            TargetHandler(hit, Color.red);
        }
        else if (Physics.Raycast(gameObject.transform.position + new Vector3(0, -2.3f, 0), Vector3.right, out hit, 8))
        {
            TargetHandler(hit, Color.green);
        }
    }

    private void SendTheNextLocation(Vector3 nextLocation)
    {
        GameManager.instance.NextTarget(nextLocation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Touched - From JumpingSystem");
        SendTheNextLocation(target.transform.position);
    }

    void TargetHandler(RaycastHit hit, Color color)
    {
        if (hit.collider.gameObject.CompareTag("JumpLocation"))
        {
            target = hit.collider.transform;
            Debug.DrawLine(gameObject.transform.position + new Vector3(0, -2.3f, 0), target.position, color);
        }
    }
}

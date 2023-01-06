using myTask;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class JumpingSurfaceController : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] public static float initialAngle = 40;

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
        if (target != null)
        {
            GameManager.instance.NextTarget(nextLocation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("RedJumpSurface") && collision.gameObject.CompareTag("RedBall")) 
        {
            Debug.Log("Same Color");
            GiveBonus();
        }
        else if (gameObject.CompareTag("BlueJumpSurface") && collision.gameObject.CompareTag("BlueBall"))
        {
            Debug.Log("Same Color");
            GiveBonus();
        }
        else if (gameObject.CompareTag("YellowJumpSurface") && collision.gameObject.CompareTag("YellowBall"))
        {
            Debug.Log("Same Color");
            GiveBonus();
        }
        else if (gameObject.CompareTag("RedCircle")|| gameObject.CompareTag("BlueCircle")|| gameObject.CompareTag("YellowCircle"))
        {
            Debug.Log("Same Color");
            GiveBonus();
        }
        else
        {
            GameManager.instance.LoseTheGame();
            return;
        }

        if (target != null)
        {
            Debug.Log("Touched - From JumpingSurfaceCotroller");
            SendTheNextLocation(target.transform.position);
        }
    }

    private void GiveBonus()
    {
        GameManager.instance.SpeedUpAndBonus();
    }

    void TargetHandler(RaycastHit hit, Color color)
    {
        if (hit.collider.gameObject.CompareTag("JumpLocation"))
        {
            target = hit.collider.transform;
            Debug.DrawLine(gameObject.transform.position, target.position, color);
        }
    }
}

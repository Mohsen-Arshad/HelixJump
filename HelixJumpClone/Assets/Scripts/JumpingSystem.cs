using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class JumpingSystem : MonoBehaviour
{
    [SerializeField] private float jumpingForce;
    [SerializeField] private float distanceBetweenRings;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.rigidbody.velocity = Vector3.zero;
            collision.rigidbody.AddForce(AddForceAtAngle(CalculateAngle()) * jumpingForce);
        }
    }

    private float CalculateAngle()
    {
        float jumpingAngle = Mathf.Asin(-(Physics.gravity.y * distanceBetweenRings) / (jumpingForce * jumpingForce)) / 2;
        jumpingAngle *= Mathf.Rad2Deg;
        Debug.Log(jumpingAngle);
        return jumpingAngle;
    }


    private Vector3 AddForceAtAngle(float angle)
    {
        Vector3 dir = Quaternion.AngleAxis(angle, Vector3.up) * Vector3.forward;
        return dir;
    }
}

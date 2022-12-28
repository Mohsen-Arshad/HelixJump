using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class JumpingSystem : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float initialAngle;


    Vector3 CalculateVelocity()
    {
        Vector3 p = target.position;

        float gravity = Physics.gravity.magnitude;
        // Selected angle in radians
        float angle = initialAngle * Mathf.Deg2Rad;

        // Positions of this object and the target on the same plane
        Vector3 planarTarget = new Vector3(p.x, 0, p.z);
        Vector3 planarPostion = new Vector3(transform.position.x, 0, transform.position.z);

        // Planar distance between objects
        float distance = Vector3.Distance(planarTarget, planarPostion);
        // Distance along the y axis between objects
        float yOffset = transform.position.y - p.y;

        float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));

        Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

        // Rotate our velocity to match the direction between the two objects
        //float angleBetweenObjects = Vector3.Angle(Vector3.forward, planarTarget - planarPostion);
        float angleBetweenObjects = Vector3.Angle(Vector3.forward, planarTarget - planarPostion) * (p.x > transform.position.x ? 1 : -1);
        Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;
        return finalVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.rigidbody.velocity = CalculateVelocity();
        }
    }

    #region FirstModel
    //[SerializeField] private float jumpingForce;
    //[SerializeField] private float distanceBetweenRings;



    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Ball"))
    //    {
    //        collision.rigidbody.velocity = Vector3.zero;
    //        collision.rigidbody.AddForce(AddForceAtAngle(CalculateAngle()) * jumpingForce);
    //    }
    //}

    //private float CalculateAngle()
    //{
    //    float jumpingAngle = Mathf.Asin(-(Physics.gravity.y * distanceBetweenRings) / (jumpingForce * jumpingForce) * 1000) / 2;
    //    jumpingAngle *= Mathf.Rad2Deg;
    //    Debug.Log(jumpingAngle);
    //    return jumpingAngle;
    //}


    //private Vector3 AddForceAtAngle(float angle)
    //{
    //    Vector3 dir = Quaternion.AngleAxis(angle, Vector3.up) * Vector3.forward;
    //    return dir;
    //}
    #endregion
}

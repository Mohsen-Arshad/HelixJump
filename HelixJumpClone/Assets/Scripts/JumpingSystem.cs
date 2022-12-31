using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class JumpingSystem : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float initialAngle = 40;

    private void Update()
    {
        RaycastHit hit;

        //Debug.DrawLine(gameObject.transform.position, target.position, Color.red);
        if (Physics.Raycast(gameObject.transform.position, Vector3.right, out hit, 100))
        {
            target = hit.collider.transform;
            Debug.DrawLine(gameObject.transform.position, target.position, Color.red);
        }
    }

    Vector3 CalculateVelocity()
    {
        Vector3 nextRingLocation = target.position;

        float gravity = Physics.gravity.magnitude;

        float angle = initialAngle * Mathf.Deg2Rad;

        Vector3 planarTarget = new Vector3(nextRingLocation.x, 0, nextRingLocation.z);
        Vector3 planarPostion = new Vector3(transform.position.x, 0, transform.position.z);


        float distance = Vector3.Distance(planarTarget, planarPostion);

        float yOffset = transform.position.y - nextRingLocation.y;

        float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));

        Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

        float angleBetweenObjects = Vector3.Angle(Vector3.up, planarTarget - planarPostion) * (nextRingLocation.x > transform.position.x ? 1 : -1);
        Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;
        return finalVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlueBall") || collision.gameObject.CompareTag("YellowBall") || collision.gameObject.CompareTag("RedBall"))
        {
            if (target != null)
            {
                collision.rigidbody.velocity = Vector3.zero;
                collision.rigidbody.angularVelocity = Vector3.zero;
                collision.rigidbody.velocity = CalculateVelocity();
            }
        }
    }
}

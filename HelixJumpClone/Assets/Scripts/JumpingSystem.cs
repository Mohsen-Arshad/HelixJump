using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class JumpingSystem : MonoBehaviour
{
    [SerializeField] private float jumpingForce;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.rigidbody.velocity = Vector3.zero;
            collision.rigidbody.AddForce(new Vector3(0, jumpingForce*2, jumpingForce));
        }
    }
}

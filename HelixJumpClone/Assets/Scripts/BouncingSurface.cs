using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingSurface : MonoBehaviour
{
    [SerializeField] private float bouncingForce;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.rigidbody.AddRelativeForce(new Vector3(0, bouncingForce, 0));
        }
    }
}

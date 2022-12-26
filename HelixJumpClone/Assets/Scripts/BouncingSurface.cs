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
            collision.rigidbody.velocity = Vector3.zero;
            collision.rigidbody.AddForce(new Vector3(0, bouncingForce, 0));

            //float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
        }
    }
}

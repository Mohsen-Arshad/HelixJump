using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingSurface : MonoBehaviour
{
    [SerializeField] private float bouncingForce = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlueBall") || collision.gameObject.CompareTag("YellowBall") || collision.gameObject.CompareTag("RedBall"))
        {
            collision.rigidbody.velocity = Vector3.zero;
            Vector3 velocityBall = new Vector3(0, bouncingForce, 0);
            collision.rigidbody.velocity = Vector3.ClampMagnitude(velocityBall, bouncingForce);
            //AnimationHandler.isJumping = true;
        }
    }
}

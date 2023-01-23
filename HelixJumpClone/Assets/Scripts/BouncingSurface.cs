using myTask;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class BouncingSurface : MonoBehaviour
{
    [SerializeField] private float bouncingForce = 1;
    bool isSeperated = false;
    private void Start()
    {
        GameManager.instance.TargetLocation += Instance_TargetLocation;
    }

    private void Instance_TargetLocation(Vector3 obj)
    {
        isSeperated = true;
    }

    private void FixedUpdate()
    {
        if (isSeperated)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.transform.localPosition += new Vector3(transform.localPosition.x, transform.localPosition.y, 0.005f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlueBall") || collision.gameObject.CompareTag("YellowBall") || collision.gameObject.CompareTag("RedBall"))
        {
            collision.rigidbody.velocity = Vector3.zero;
            Vector3 velocityBall = new Vector3(0, bouncingForce, 0);
            collision.rigidbody.velocity = Vector3.ClampMagnitude(velocityBall, bouncingForce);
            GameManager.instance.BallLanded();
        }
    }
}

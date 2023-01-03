using myTask;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class JumpingNewSystem : MonoBehaviour
{
    [SerializeField] private float jumpingSpeed = 6;
    [SerializeField] private float jumpingHeight = 2f;
    [SerializeField] private Transform target;
    [SerializeField] private Transform startJumpPosition;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.TargetLocation += Instance_TargetLocation;
    }

    private void OnDestroy()
    {
        GameManager.instance.TargetLocation -= Instance_TargetLocation;
    }

    private void Instance_TargetLocation(Vector3 nextTarget)
    {
        target.position = nextTarget;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            jumpingSpeed += Time.deltaTime * 5;
            jumpingSpeed = jumpingSpeed % 5f;

            transform.position = MathParabola.Parabola(startJumpPosition.position, target.gameObject.transform.position, jumpingHeight, jumpingSpeed / 5);
            if (transform.position.y - 0.6f <= startJumpPosition.position.y)
            {
                Debug.Log("GroundTouched");
                AnimationHandler.isJumping = true;
            }
        }
        else
        {
            jumpingSpeed += Time.deltaTime * 5;
            jumpingSpeed = jumpingSpeed % 5f;

            transform.position = MathParabola.Parabola(startJumpPosition.position, startJumpPosition.position, jumpingHeight, jumpingSpeed / 5);
            if (transform.position.y - 0.6f <= startJumpPosition.position.y)
            {
                Debug.Log("GroundTouched");
                AnimationHandler.isJumping = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        startJumpPosition.position = collision.gameObject.transform.position;
    }
}

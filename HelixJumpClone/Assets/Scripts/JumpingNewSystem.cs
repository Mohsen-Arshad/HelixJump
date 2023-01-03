using myTask;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class JumpingNewSystem : MonoBehaviour
{
    [SerializeField] private float jumpingSpeed = 6;
    [SerializeField] private float jumpingHeight = 2f;
    private Vector3 target;
    private Vector3 startJumpPosition;

    bool isJumpToNext = false;

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
        target = nextTarget;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            jumpingSpeed += Time.deltaTime * 5;
            jumpingSpeed = jumpingSpeed % 5f;

            transform.position = MathParabola.Parabola(startJumpPosition + new Vector3(0, 0.6f, 0), target + new Vector3(0, 0.4f, 0), jumpingHeight, jumpingSpeed / 5);
            if (transform.position.y - 0.7f <= startJumpPosition.y)
            {
                Debug.Log("GroundTouched");
                AnimationHandler.isJumping = true;
            }
            isJumpToNext = true;
        }
        else
        {
            jumpingSpeed += Time.deltaTime * 5;
            jumpingSpeed = jumpingSpeed % 5f;

            transform.position = MathParabola.Parabola(startJumpPosition + new Vector3(0, 0.6f, 0), startJumpPosition + new Vector3(0, 0.4f, 0), jumpingHeight, jumpingSpeed / 5);
            if (transform.position.y - 0.7f <= startJumpPosition.y)
            {
                Debug.Log("GroundTouched");
                AnimationHandler.isJumping = true;
                if (isJumpToNext)
                {
                    startJumpPosition = target;
                }
            }
            isJumpToNext = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isJumpToNext)
        {
            startJumpPosition = collision.gameObject.transform.position;
        }
    }
}

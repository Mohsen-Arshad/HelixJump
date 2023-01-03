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
    private Vector3 initialTarget;

    bool isLanded = false;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.TargetLocation += Instance_TargetLocation;
        GameManager.instance.BallIsLanding += Instance_BallIsLanding;
    }

    private void Instance_BallIsLanding()
    {
        isLanded = true;
    }

    private void OnDestroy()
    {
        GameManager.instance.TargetLocation -= Instance_TargetLocation;
    }

    private void Instance_TargetLocation(Vector3 nextTarget)
    {
        Debug.Log("Next Target" + nextTarget);
        initialTarget = nextTarget;
    }

    // Update is called once per frame
    void Update()
    {
        //time += Time.deltaTime * 0.5f;
        //if (transform.position.x >= positionMiddle.transform.position.x && transform.position.y <= positionMiddle.transform.position.y)
        //{
        //    isLanded = true;
        //    Debug.Log("Landed");
        //}

        //if (!isLanded)
        //{
        //    transform.position = CalculateQuadraticBezierPoint(time, positionStart.position, positionEnd.position, positionMiddle.position);
        //}

        ParabolicMove();
        if (isLanded)
        {
            isLanded = false;
            startJumpPosition = initialTarget;
        }
    }

    void ParabolicMove()
    {
        jumpingSpeed += Time.deltaTime;
        jumpingSpeed = jumpingSpeed % 5f;
        isLanded = false;
        transform.position = MathParabola.Parabola(startJumpPosition + new Vector3(0, 0.6f, 0), target + new Vector3(0, 0.4f, 0), jumpingHeight, jumpingSpeed / 5f);
        if (transform.position.y - 0.6f <= startJumpPosition.y)
        {
            //Debug.Log("GroundTouched");
            AnimationHandler.isJumping = true;
            GameManager.instance.BallIsJumpedToNext();
            target = initialTarget;
            isLanded = true;
        }

        GameManager.instance.BallLocationToNext(transform.position);
    }


    private Vector3 CalculateQuadraticBezierPoint(float time, Vector3 positionStart, Vector3 positionEnd, Vector3 positionMiddle)
    {
        // return (Bezier(t)) = (1-t)^2 P0 + 2(1-t) t P1 + t^2 P2
        //                       uu             u          tt
        // time should pick a number between 0 and 1 ( should be floating point ) 0 < time < 1

        float u = 1 - time;
        float tt = time * time;
        float uu = u * u;

        Vector3 bezierReturn = uu * positionStart + 2 * u * time * positionMiddle + tt * positionEnd;

        return bezierReturn;
    }
}

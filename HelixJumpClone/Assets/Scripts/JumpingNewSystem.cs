using myTask;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class JumpingNewSystem : MonoBehaviour
{
    private Vector3 endPosition;
    private Vector3 nextTarget;
    private Vector3 startPosition;
    [SerializeField] private float jumpingHeight;
    [SerializeField] private float jumpingSpeed;
    [SerializeField] private float bouncingSpeed;
    [SerializeField] bool isLanded = false;
    [SerializeField] bool isMaxHeight = false;
    float flyDuration;
    bool isFoundNextRing = false;
    bool isBouncing = false;
    bool isJumping = false;
    float ballPositionOnYAxis;

    private void Start()
    {
        GameManager.instance.TargetLocation += Instance_TargetLocation;
    }

    private void OnDestroy()
    {
        GameManager.instance.TargetLocation -= Instance_TargetLocation;
    }

    private void Instance_TargetLocation(Vector3 obj)
    {
        nextTarget = obj;
        Debug.Log("Next Target is : " + nextTarget);
        isFoundNextRing = true;
        endPosition = obj + new Vector3(0, 0.5f, 0);
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFoundNextRing)
        {
            JumpForward();
        }
        //else
        //{
        //    Bouncing();
        //}
    }

    private void JumpForward()
    {
        Vector3 middlePosition = Vector3.Lerp(startPosition, endPosition, 0.5f) + new Vector3(0, jumpingHeight * 2, 0);

        flyDuration += Time.deltaTime * jumpingSpeed;
        if (transform.position.x >= endPosition.x && transform.position.y <= endPosition.y)
        {
            isLanded = true;
            isFoundNextRing = false;
            Debug.Log("Landed");
        }

        if (!isLanded)
        {
            transform.position = CalculateQuadraticBezierPoint(flyDuration, startPosition, endPosition, middlePosition);
        }
    }

    //private void Bouncing()
    //{
    //    if (isLanded && !isMaxHeight)
    //    {
    //        ballPositionOnYAxis = transform.position.y;
    //        ballPositionOnYAxis += bouncingSpeed * Time.deltaTime;
    //        if (transform.position.y >= jumpingHeight)
    //        {
    //            isLanded = false;
    //            isMaxHeight = true;
    //        }
    //    }
    //    else
    //    {
    //        ballPositionOnYAxis = transform.position.y;
    //        ballPositionOnYAxis -= bouncingSpeed * Time.deltaTime;
    //        if (transform.position.y <= 0.7f)
    //        {
    //            isLanded = true;
    //            isMaxHeight = false;
    //            GameManager.instance.BallLanded();
    //            if (endPosition != nextTarget)
    //            {
    //                endPosition = nextTarget;
    //                isBouncing = false;
    //            }
    //        }
    //    }
    //    transform.position = new Vector3(transform.position.x, ballPositionOnYAxis, transform.position.z);
    //}

    private Vector3 CalculateQuadraticBezierPoint(float jumpingSpeed, Vector3 positionStart, Vector3 positionEnd, Vector3 positionMiddle)
    {
        // return (Bezier(t)) = (1-t)^2 P0 + 2(1-t) t P1 + t^2 P2
        //                       uu             u          tt
        // time should be a float number between 0 and 1 --------> 0 < time < 1

        float u = 1 - jumpingSpeed;
        float tt = Mathf.Pow(jumpingSpeed, 2);
        float uu = Mathf.Pow(u, 2);

        Vector3 bezierReturn = uu * positionStart + 2 * u * jumpingSpeed * positionMiddle + tt * positionEnd;

        return bezierReturn;
    }

}

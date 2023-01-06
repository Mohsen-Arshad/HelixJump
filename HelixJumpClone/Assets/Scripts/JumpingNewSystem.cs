using myTask;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class JumpingNewSystem : MonoBehaviour
{
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 middlePosition;
    [SerializeField] private float jumpingHeight;
    [SerializeField] private float jumpingSpeed;
    [SerializeField] private float flyDuration;
    [SerializeField] bool isLanded = false;
    [SerializeField] bool isFoundNextRing = false;
    float currentJumpingSpeed;

    private void Start()
    {
        currentJumpingSpeed = jumpingSpeed;
        GameManager.instance.TargetLocation += Instance_TargetLocation;
        GameManager.instance.CorrectColor += Instance_CorrectColor;
        GameManager.instance.BallIsLanding += Instance_BallIsLanding;
    }

    private void OnDestroy()
    {
        GameManager.instance.TargetLocation -= Instance_TargetLocation;
        GameManager.instance.CorrectColor -= Instance_CorrectColor;
        GameManager.instance.BallIsLanding -= Instance_BallIsLanding;
    }

    private void Instance_BallIsLanding()
    {
        currentJumpingSpeed = jumpingSpeed;
    }

    private void Instance_CorrectColor()
    {
        if (currentJumpingSpeed <= 2.5f)
        {
            currentJumpingSpeed += 0.5f;
        }
    }

    private void Instance_TargetLocation(Vector3 obj)
    {
        Debug.Log("Next Target is : " + obj);
        isFoundNextRing = true;
        startPosition = transform.position;
        endPosition = obj;
        middlePosition = Vector3.Lerp(startPosition, endPosition, 0.5f) + new Vector3(0, jumpingHeight * 2, 0);
        flyDuration = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFoundNextRing && !isLanded)
        {
            JumpForward();
        }
    }

    private void JumpForward()
    {
        flyDuration += Time.deltaTime * currentJumpingSpeed;
        transform.position = CalculateQuadraticBezierPoint(flyDuration, startPosition, endPosition, middlePosition);
        if (transform.position.x >= endPosition.x && transform.position.y <= endPosition.y)
        {
            isLanded = true;
            isFoundNextRing = false;
            startPosition = transform.position;
            flyDuration = 0;
            Debug.Log("Landed - From Jumping New System" + transform.position);
        }
        isLanded = false;
    }

    private Vector3 CalculateQuadraticBezierPoint(float jumpSpeed, Vector3 positionStart, Vector3 positionEnd, Vector3 positionMiddle)
    {
        // return (Bezier(t)) = (1-t)^2 P0 + 2(1-t) t P1 + t^2 P2
        //                       uu             u          tt
        // time should be a float number between 0 and 1 --------> 0 < time < 1

        float u = 1 - jumpSpeed;
        float tt = Mathf.Pow(jumpSpeed, 2);
        float uu = Mathf.Pow(u, 2);

        Vector3 bezierReturn = uu * positionStart + 2 * u * jumpSpeed * positionMiddle + tt * positionEnd;
        return bezierReturn;
    }

}

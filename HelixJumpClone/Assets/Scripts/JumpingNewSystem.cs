using myTask;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingNewSystem : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;
    [SerializeField] private float jumpingHeight;
    [SerializeField] private float jumpingSpeed;
    [SerializeField] private float bouncingSpeed;
    [SerializeField] bool isLanded = false;
    [SerializeField] bool isMaxHeight = false;
    float flyDuration;
    bool isFoundNextRing = false;
    float ballPositionOnYAxis;

    // Update is called once per frame
    void Update()
    {
        if (isFoundNextRing)
        {
            Vector3 middlePosition = Vector3.Lerp(startPosition.transform.position, endPosition.transform.position, 0.5f) + new Vector3(0, jumpingHeight * 2, 0);

            flyDuration += Time.deltaTime * jumpingSpeed;
            if (transform.position.x >= endPosition.position.x && transform.position.y <= endPosition.position.y)
            {
                isLanded = true;
                Debug.Log("Landed");
            }

            if (!isLanded)
            {
                transform.position = CalculateQuadraticBezierPoint(flyDuration, startPosition.position, endPosition.position, middlePosition);
            }
        }
        else
        {
            if (isLanded && !isMaxHeight)
            {
                ballPositionOnYAxis = transform.position.y;
                ballPositionOnYAxis += bouncingSpeed * Time.deltaTime;
                if (transform.position.y >= jumpingHeight)
                {
                    isLanded = false;
                    isMaxHeight = true;
                }
            }
            else
            {
                ballPositionOnYAxis = transform.position.y;
                ballPositionOnYAxis -= bouncingSpeed * Time.deltaTime;
                if (transform.position.y <= 0.7f)
                {
                    isLanded = true;
                    isMaxHeight = false;
                    GameManager.instance.BallLanded();
                }
            }
            transform.position = new Vector3(transform.position.x, ballPositionOnYAxis, transform.position.z);
        }

    }

    private Vector3 CalculateQuadraticBezierPoint(float jumpingSpeed, Vector3 positionStart, Vector3 positionEnd, Vector3 positionMiddle)
    {
        // return (Bezier(t)) = (1-t)^2 P0 + 2(1-t) t P1 + t^2 P2
        //                       uu             u          tt
        // time should be a float number between 0 and 1 --------> 0 < time < 1

        float u = 1 - jumpingSpeed;
        float tt = jumpingSpeed * jumpingSpeed;
        float uu = u * u;

        Vector3 bezierReturn = uu * positionStart + 2 * u * jumpingSpeed * positionMiddle + tt * positionEnd;

        return bezierReturn;
    }
}

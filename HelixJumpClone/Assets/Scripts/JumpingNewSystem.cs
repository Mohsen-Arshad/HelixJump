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
    [SerializeField] bool isLanded = false;
    float flyDuration;

    // Update is called once per frame
    void Update()
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

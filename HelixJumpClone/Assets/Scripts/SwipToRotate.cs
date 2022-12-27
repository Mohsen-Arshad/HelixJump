using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipToRotate : MonoBehaviour
{
    private float sceneWidth;
    private Vector3 pressPoint;
    private Quaternion startRotation;

    private void Start()
    {
        sceneWidth = Screen.width;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pressPoint = Input.mousePosition;
            startRotation = transform.rotation;
        }

        else if (Input.GetMouseButton(0))
        {
            float currentDistanceBetweenMousePosition = (Input.mousePosition - pressPoint).x;
            transform.rotation = startRotation * Quaternion.Euler(Vector3.left * (currentDistanceBetweenMousePosition / sceneWidth) * 360);
        }
    }


    //Vector3 mousePreviousPosition = Vector3.zero;
    //Vector3 mousePositionDelta = Vector3.zero;

    //private void Update()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        Debug.Log("clicked");
    //        mousePositionDelta = Input.mousePosition - mousePreviousPosition;
    //        this.transform.Rotate(transform.up, Vector3.Dot(mousePositionDelta, Camera.main.transform.right), Space.World);
    //    }

    //    mousePreviousPosition = Input.mousePosition;
    //}
}

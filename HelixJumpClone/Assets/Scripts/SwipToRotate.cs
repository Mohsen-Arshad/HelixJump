using myTask;
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
        GameManager.instance.GameLose += Instance_GameLose;
        sceneWidth = Screen.width;
    }

    private void OnDestroy()
    {
        GameManager.instance.GameLose -= Instance_GameLose;
    }

    private void Instance_GameLose()
    {
        gameObject.GetComponent<SwipToRotate>().enabled = false;
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
            transform.rotation = startRotation * Quaternion.Euler(Vector3.right * (currentDistanceBetweenMousePosition / sceneWidth) * 360);
        }
    }

    //void TouchScreenMode()
    //{

    //    if (Input.touchCount == 1)
    //    {
    //        Touch screenTouch = Input.GetTouch(0);

    //        if (screenTouch.phase == TouchPhase.Moved)
    //        {
    //            transform.Rotate(0f, screenTouch.deltaPosition.x, 0f);
    //        }
    //    }
    //}
}

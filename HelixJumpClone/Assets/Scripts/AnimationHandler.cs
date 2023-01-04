using myTask;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    Animator animator;
    private bool isJumping;
    float waitForSec = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.BallIsLanding += Instance_BallIsLanding;
        animator = GetComponent<Animator>();
    }

    private void Instance_BallIsLanding()
    {
        isJumping = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isJumping)
        {
            animator.SetBool("isJumping", true);
        }

        waitForSec -= Time.deltaTime;
        if (waitForSec <= 0f)
        {
            waitForSec = 0.3f;
            animator.SetBool("isJumping", false);
            isJumping = false;
        }
    }
}

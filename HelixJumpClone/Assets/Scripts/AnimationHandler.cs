using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    Animator animator;
    public static bool isJumping;
    float waitForSec = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
            waitForSec = 0.5f;
            animator.SetBool("isJumping", false);
            isJumping = false;
        }
    }
}

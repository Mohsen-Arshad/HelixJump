using myTask;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject animatedRing;
    [SerializeField] Transform target;
    [SerializeField] private GameObject bouncingSurfaces;
    [SerializeField] private GameObject completeCircle;
    bool destroyRing = false;
    bool isRingActive = false;
    float disableTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.BallLocation += Instance_BallLocation;
        GameManager.instance.TargetLocation += Instance_TargetLocation;
    }

    private void Instance_TargetLocation(Vector3 obj)
    {
        if (isRingActive)
        {
            if (animatedRing != null)
            {
                animatedRing.SetActive(false);
            }
            destroyRing = true;
        }
    }

    private void OnDestroy()
    {
        GameManager.instance.BallLocation -= Instance_BallLocation;
    }

    private void Instance_BallLocation(Vector3 obj)
    {
        if (Vector3.Distance(transform.position, obj) <= 0.1f)
        {
            Debug.Log("Ball is Here");
            GameManager.instance.BallLanded();
        }
    }

    private void Update()
    {
        if (destroyRing)
        {
            disableTimer += Time.deltaTime;
            if (disableTimer >= 1f)
            {
                completeCircle.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.enabled = true;
        bouncingSurfaces.SetActive(true);
        isRingActive = true;
        if (other.gameObject.CompareTag("BlueBall") || other.gameObject.CompareTag("YellowBall") || other.gameObject.CompareTag("RedBall"))
        {
            if (animator != null)
            {
                if (other.transform.position.y <= gameObject.transform.position.y - 0.5f)
                {
                    GameManager.instance.BallLanded();
                    Debug.Log("Ball is here");
                }
            }
        }
    }
}

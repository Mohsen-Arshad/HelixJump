using myTask;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] Transform target;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.BallLocation += Instance_BallLocation;
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

    private void OnTriggerEnter(Collider other)
    {
        animator.enabled = true;
        if (other.gameObject.CompareTag("BlueBall") || other.gameObject.CompareTag("YellowBall") || other.gameObject.CompareTag("RedBall"))
        {
            if (animator!=null)
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

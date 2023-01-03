using myTask;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] Transform target;
    Vector3 gameObjectPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;

        //Debug.DrawLine(gameObject.transform.position, target.position, Color.red);
        //if (Physics.Raycast(gameObject.transform.position, Vector3.right, out hit, 500))
        //{
        //    if (hit.collider.gameObject.CompareTag("JumpLocation"))
        //    {
        //        target = hit.collider.transform;
        //        Debug.DrawLine(gameObject.transform.position, target.position, Color.red);
        //    }
        //}
        //else if (Physics.Raycast(gameObject.transform.position + new Vector3(0, -2.3f, 0), Vector3.right, out hit, 8))
        //{
        //    if (hit.collider.gameObject.CompareTag("JumpLocation"))
        //    {
        //        target = hit.collider.transform;
        //        Debug.DrawLine(gameObject.transform.position + new Vector3(0, -2.3f, 0), target.position, Color.green);
        //    }
        //}

        //if (gameObject.CompareTag("YellowCircle") || gameObject.CompareTag("BlueCircle") || gameObject.CompareTag("RedCircle"))
        //{
        //    gameObjectPosition = gameObject.transform.position + new Vector3(0, -2.35f, 0);
        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BlueBall") || other.gameObject.CompareTag("YellowBall") || other.gameObject.CompareTag("RedBall"))
        {
            if (animator!=null)
            {
                animator.enabled = true;
            }
        }
    }
}

using myTask;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class JumpingNewSystem : MonoBehaviour
{
    [SerializeField] private float jumpingSpeed = 6;
    [SerializeField] private float jumpingHeight = 2f;
    [SerializeField] private Transform target;
    [SerializeField] Vector3 startJumpPosition;
    // Start is called before the first frame update
    void Start()
    {
        //GameManager.instance.TargetLocation += Instance_TargetLocation;
    }

    private void Instance_TargetLocation(Vector3 nextTarget)
    {
        target.position = nextTarget;
    }

    private void OnDestroy()
    {
        //GameManager.instance.TargetLocation -= Instance_TargetLocation;
    }

    // Update is called once per frame
    void Update()
    {
        jumpingSpeed += Time.deltaTime * 5;
        jumpingSpeed = jumpingSpeed % 5f;

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

        transform.position = MathParabola.Parabola(startJumpPosition, Vector3.right * 7f, jumpingHeight, jumpingSpeed / 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        startJumpPosition = collision.gameObject.transform.position;
    }
}

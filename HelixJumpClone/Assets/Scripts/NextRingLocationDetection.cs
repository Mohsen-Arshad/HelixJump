using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class NextRingLocationDetection : MonoBehaviour
{
    [SerializeField]
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        //Debug.DrawLine(gameObject.transform.position, target.position, Color.red);
        if (Physics.Raycast(gameObject.transform.position, Vector3.right, out hit, 200))
        {
            target = hit.collider.transform;
            Debug.DrawLine(gameObject.transform.position, target.position, Color.red);
        }
        else if (Physics.Raycast(gameObject.transform.position - new Vector3(0, -2.45f, 0), Vector3.right, out hit, 200))
        {
            target = hit.collider.transform;
            Debug.DrawLine(gameObject.transform.position - new Vector3(0, -2.45f, 0), target.position, Color.green);
        }
    }

    Vector3 NextRingPosition()
    {
        Vector3 nextRingLocation;
        if (target.gameObject.CompareTag("BlueCircle") || target.gameObject.CompareTag("RedCircle") || transform.gameObject.CompareTag("YellowCircle") || transform.gameObject.CompareTag("BouncingSurface"))
        {
            nextRingLocation = target.position + new Vector3(0, -2.3f, 0);
        }
        else
        {
            nextRingLocation = target.position;
        }
        return nextRingLocation;
    }
}

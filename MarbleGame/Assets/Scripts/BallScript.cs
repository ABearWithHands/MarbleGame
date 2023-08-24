using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private GameObject target;
    [SerializeField] float rollForce;
    [SerializeField] Transform centerPlatform;
    private Vector3 sweetSpot;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }


    void Update()
    {
        RollAtTarget();
    }

    private void RollAtTarget()
    {
        //Vector3 targetLocation = target.transform.position;
        //Vector3 distanceVector = targetLocation - this.gameObject.transform.position;
        //rb.AddForceAtPosition(rollForce * distanceVector.normalized, transform.position, ForceMode.Impulse);

        Vector3 targetLocation = target.GetComponent<BallScript>().DetermineSweetSpot();
        Vector3 distanceVector = targetLocation - this.gameObject.transform.position;
        rb.AddForceAtPosition(rollForce * distanceVector.normalized, transform.position, ForceMode.Impulse);
    }

    public Vector3 DetermineSweetSpot()
    {
        sweetSpot = (centerPlatform.position - transform.position) * (3 / Vector3.Distance(transform.position, centerPlatform.position));

        return sweetSpot;
    }
}

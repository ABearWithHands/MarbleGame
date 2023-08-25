using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class BallScript : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private GameObject target = null;
    [SerializeField] float rollForce;
    [SerializeField] Transform centerPlatform;
    [SerializeField] List<GameObject> enemyList = new List<GameObject>();
    private GameManager gameManager;
    private Vector3 sweetSpot;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void FixedUpdate()
    {
        if (target == null && gameManager.listOfBalls.Count > 1)
        {
            enemyList = ListEnemies(gameManager.listOfBalls);
            target = NextTarget(enemyList);
        }
        else if (gameManager.listOfBalls.Count > 1)
        {
            RollAtTarget();
        }
    }

    private void RollAtTarget()
    {
        //Vector3 targetLocation = target.transform.position;
        //Vector3 distanceVector = targetLocation - this.gameObject.transform.position;
        //rb.AddForceAtPosition(rollForce * distanceVector.normalized, transform.position, ForceMode.Impulse);

        //Vector3 targetLocation = target.GetComponent<BallScript>().DetermineSweetSpot();
        Vector3 targetLocation = target.transform.position;
        Vector3 distanceVector = targetLocation - this.gameObject.transform.position;
        rb.AddForceAtPosition(rollForce * distanceVector.normalized, transform.position, ForceMode.Impulse);
    }

    private List<GameObject> ListEnemies(List<GameObject> list)
    {
        var enemiesList = from enemy in list
                          where enemy != this.gameObject
                          select enemy;

        return enemiesList.ToList();
    }

    private GameObject NextTarget(List<GameObject> listOfEnemies)
    {
        System.Random rnd = new System.Random();

        return listOfEnemies[rnd.Next(enemyList.Count)];
    }

    public Vector3 DetermineSweetSpot()
    {
        sweetSpot = (centerPlatform.position - transform.position) * (3 / Vector3.Distance(transform.position, centerPlatform.position));

        return sweetSpot;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public List<GameObject> listOfBalls = new List<GameObject>();
    [SerializeField] float distanceFromCenter;
    //public GameObject[] listOfBalls;
   
    void Start()
    {
        listOfBalls.AddRange(GameObject.FindGameObjectsWithTag("Ball"));
        SetBalls();
    }

    private void SetBalls()
    {
        for (int i = 0; i < listOfBalls.Count; i++)
        {
            float j = i;
            listOfBalls[i].transform.position = new Vector3((float)(distanceFromCenter * Math.Cos((double)(j / listOfBalls.Count) * Math.PI * 2)), 3.5f, (float)(distanceFromCenter * Math.Sin((double)(j / listOfBalls.Count) * Math.PI * 2)));
            
        }
    }
}

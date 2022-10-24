using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    [SerializeField] private Transform[] finishLines;
    [SerializeField] private float speedMultiplier;
    private Transform myTranform;
    [SerializeField] public Transform myFinishline;
    private Vector3 directionToGo;

    private void Awake()
    {
        myTranform = GetComponent<Transform>();
        myFinishline = finishLines[Random.Range(0, 4)];
    }
    private void Update()
    {
        StartMovement();
        transform.LookAt(myFinishline);
    }

    public void StartMovement()
    {
        directionToGo = myFinishline.position - myTranform.position;
        myTranform.position += directionToGo*(speedMultiplier/1000);
    }
}


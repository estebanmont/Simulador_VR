using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    [SerializeField] private Transform[] finishLines;
    [SerializeField] private float speedMultiplier,rotateSpeed;
    private Transform myTranform;
    private Rigidbody myRigidbody;
    [SerializeField] Transform myFinishline;
    private Vector3 directionToGo,aux;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myTranform = GetComponent<Transform>();
        myFinishline = finishLines[Random.Range(0, 5)];
        directionToGo = myFinishline.position - myTranform.position;
        aux = new Vector3(directionToGo.x, 0, directionToGo.z);
        StartMovement();
    }
    private void Update()
    {
       
        Quaternion toRotate = Quaternion.LookRotation(directionToGo, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotateSpeed * Time.deltaTime);
    }

    public void StartMovement()
    {
        myRigidbody.AddForce(aux*speedMultiplier);
        
    }
}


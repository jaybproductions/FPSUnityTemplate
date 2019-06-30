﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{


    [SerializeField]
    private Camera cam;

    private Vector3 rotation = Vector3.zero;

    private Vector3 velocity = Vector3.zero;

    private Vector3 cameraRotation = Vector3.zero;

   





    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();


    }


    public void Move(Vector3 _velocity)
    {

        velocity = _velocity;



    }


    public void Rotate(Vector3 _rotation)
    {

        rotation = _rotation;



    }


    //Runs every physics operation
    private void FixedUpdate()
    {

        PerformMovement();
        PerformRotation();

    }



    void PerformMovement()
    {

        if(velocity != Vector3.zero)
        {


            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);


        }


    }

    void PerformRotation()
    {
        rb.MoveRotation(transform.rotation * Quaternion.Euler(rotation));

        if(cam != null)
        {


            cam.transform.Rotate(cameraRotation);


        }


    }

    public void RotateCamera(Vector3 _cameraRotation)
    {

        cameraRotation = _cameraRotation;




    }




}

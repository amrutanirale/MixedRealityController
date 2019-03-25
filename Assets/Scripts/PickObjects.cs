using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickObjects : MonoBehaviour
{
    GameObject pickableObject=null;
    bool isColliding = false;
    bool canDrag = false;
    Vector3 offset;
   // public bool isPressed = false;
    void Start()
    {
        VirtualButtonManager.OnButtonClicked += OnCollideObject;
    }

    private void Update()
    {
        if (pickableObject == null)
        {
            return;
        }
        print(transform.position);
        if (canDrag == true)
        {
            // Apply that offset to get a target position.
            Vector3 targetPosition = transform.position + offset;
            // Smooth follow.    
            pickableObject.transform.position += (targetPosition - pickableObject.transform.position);
        }
    }
    void OnCollideObject(bool canMove)
    {
        if (canMove==true)
        {
            canDrag = true;
        }
        else
        {
            canDrag = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickable"))
        {
            pickableObject = other.gameObject;
            offset = other.transform.position - transform.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        pickableObject = null;
    }
}

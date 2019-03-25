using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class VirtualButtonManager : MonoBehaviour,IVirtualButtonEventHandler
{
    GameObject HoldButton;
    public bool canMove = false;
    public static Action<bool> OnButtonClicked;
    public GameObject controllerHead;
    private new Renderer renderer;

    void Start()
    {
        HoldButton = GameObject.Find("HoldButton");
        HoldButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        renderer = controllerHead.transform.GetComponent<Renderer>();
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        canMove = true;
        OnButtonClicked?.Invoke(true);
        renderer.material.color = Color.green;
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        canMove = false;
        OnButtonClicked?.Invoke(false);
        renderer.material.color = Color.white;

    }
}

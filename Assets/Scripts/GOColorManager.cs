using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOColorManager : MonoBehaviour
{
    private new Renderer renderer;
   
    void Start()
    {
        renderer = transform.GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Controller"))
        {
            renderer.material.color = Color.red;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        renderer.material.color = Color.white;

    }

}

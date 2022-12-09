using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebInteraction : MonoBehaviour, IWebInteractable
{
    public void Start()
    {
    }

    public string GetDescription()
    {
        return "Press E to access to the MediaPlayer";
    }

    public void Interact()
    {
        //material.color = new Color(Random.value, Random.value, Random.value);
    }
}

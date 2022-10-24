using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasInteraction : MonoBehaviour, IInteractable
{
    Material material;


    public void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    public string GetDescription()
    {
        return "Change view and a random color";
    }

    public void Interact()
    {
        material.color = new Color(Random.value, Random.value, Random.value);
    }
}

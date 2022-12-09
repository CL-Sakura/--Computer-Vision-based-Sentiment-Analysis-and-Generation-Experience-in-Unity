using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setUIActive : MonoBehaviour
{
   
    public GameObject canvasUI;

    public bool isButtonHit = false;


    public void setCanvasUIActive()
    {
        isButtonHit = true;
    }

    public void setCanvasUIUnActive()
    {
        isButtonHit = false;
    }

    private void Update()
    {
        canvasUI.SetActive(isButtonHit);
    }
}

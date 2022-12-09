using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotationFixed : MonoBehaviour
{
    public Camera MainCamera;

    private void Start()
    {
        MainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        var rotation = MainCamera.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }


}

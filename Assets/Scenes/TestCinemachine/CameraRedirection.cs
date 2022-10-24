using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraRedirection : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera CM_vcam1;
    [SerializeField] private CinemachineVirtualCamera CM_vcam2;

    private void OnEnable()
    {
        CameraSwitcher.Register(CM_vcam1);
        CameraSwitcher.Register(CM_vcam2); 
        CameraSwitcher.SwitchCamera(CM_vcam1);
    }

    private void OnDisable()
    {
        CameraSwitcher.Unregister(CM_vcam1);
        CameraSwitcher.Unregister(CM_vcam2);
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("Camera switch requested");

            if (CameraSwitcher.IsActiveCamera(CM_vcam1))
            {
                print("Switch to CM_vcam2");
                CameraSwitcher.SwitchCamera(CM_vcam2);
            }
            else if (CameraSwitcher.IsActiveCamera(CM_vcam2))
            {
                print("Switch to CM_vcam1");
                CameraSwitcher.SwitchCamera(CM_vcam1);
            }


        } 
    }
}

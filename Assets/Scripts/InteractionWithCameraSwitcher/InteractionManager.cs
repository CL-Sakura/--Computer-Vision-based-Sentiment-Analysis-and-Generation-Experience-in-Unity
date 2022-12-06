using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using StarterAssets;


public class InteractionManager : MonoBehaviour
{

    

    [Header("Camera Switcher")]
    [SerializeField] private CinemachineVirtualCamera PlayerCamera;
    [SerializeField] private CinemachineVirtualCamera CanvasCamera;
    [SerializeField] private bool  cursorLocked = true;

    [Header("Interaction Item")]
    [SerializeField] private Camera MainCamera;
    [SerializeField] private float interactionDistance = 2f;

    [SerializeField] private GameObject interactionUI;
    [SerializeField] private TextMeshProUGUI interactionText;


    private void OnEnable()
    {
        CameraSwitcher.Register(PlayerCamera);
        CameraSwitcher.Register(CanvasCamera);
        CameraSwitcher.SwitchCamera(PlayerCamera);
    }

    private void OnDisable()
    {
        CameraSwitcher.Unregister(PlayerCamera);
        CameraSwitcher.Unregister(CanvasCamera);
    }



    public void Update()
    {
        InteractionRay();
    }


    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; 
    }

    void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void InteractionRay()
    {
        Ray ray = MainCamera.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        bool hitSomething = false;

        //�Ƿ�׼��ѡ�У�ѡ������ʾ
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                hitSomething = true;
                interactionText.text = interactable.GetDescription();

                //�鿴��������ʱ����E�����н�����ת����ͷ�Լ�����Interact()����
                if (Input.GetKeyDown(KeyCode.E))
                {                   
                    if (CameraSwitcher.IsActiveCamera(PlayerCamera))
                    {
                        CameraSwitcher.SwitchCamera(CanvasCamera);
                        // �������
                        UnlockMouse();
                    }

                    if (CameraSwitcher.IsActiveCamera(CanvasCamera))
                    {
                        interactable.Interact();
                    }

                    
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CameraSwitcher.IsActiveCamera(CanvasCamera))
            {
                CameraSwitcher.SwitchCamera(PlayerCamera);
                // �������
                LockMouse();
            }
        }



        interactionUI.SetActive(hitSomething);


    }





}

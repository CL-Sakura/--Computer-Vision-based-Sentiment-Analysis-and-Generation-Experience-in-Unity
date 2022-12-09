using Cinemachine;
using TMPro;
using UnityEngine;

public class WebServiceInteractionManager : MonoBehaviour
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

    [SerializeField] private GameObject canvasUI;
    private bool isWebEButtonHit = false;

    private bool hitMediaPlayer;
    

    
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
        canvasUI.SetActive(isWebEButtonHit);
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

        hitMediaPlayer = false;

        //是否被准星选中，选中则显示
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            IWebInteractable interactable = hit.collider.GetComponent<IWebInteractable>();
            if (interactable != null)
            {
                hitMediaPlayer = true;
                interactionText.text = interactable.GetDescription();

                //查看交互对象时按下E键进行交互：转换镜头以及调用Interact()方法
                if (Input.GetKeyDown(KeyCode.E))
                {                   
                    if (CameraSwitcher.IsActiveCamera(PlayerCamera))
                    {
                        CameraSwitcher.SwitchCamera(CanvasCamera);
                        // 解锁鼠标
                        UnlockMouse();
                        
                        //解锁UI
                        isWebEButtonHit = true;
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
                // 锁定鼠标
                LockMouse();
                // 锁定UI
                isWebEButtonHit = false;
            }
        }



        interactionUI.SetActive(hitMediaPlayer);


    }

}

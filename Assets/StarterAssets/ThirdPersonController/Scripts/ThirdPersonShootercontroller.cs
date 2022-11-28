using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;

public class ThirdPersonShootercontroller : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    private StarterAssetsInputs starterAssetsInputs;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayermask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfBulletProjectile;
    [SerializeField] private Transform spawnBulletPosition;
   /* [SerializeField] private Transform vfxHitBlue;
    [SerializeField] private Transform vfxHitYellow;*/
    private ThirdPersonController thirdPersonController;
    private Animator animator;
    public GameObject Gun;
    public GameObject AimPanel;
    Vector3 mouseWorldPosition = Vector3.zero;
    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
       
        Vector2 screenCentrePoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCentrePoint);
        Transform hitTransform = null;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayermask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;

        }
        if (starterAssetsInputs.aim )
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);
            animator.SetLayerWeight(1,Mathf .Lerp (animator .GetLayerWeight (1),1f,Time .deltaTime*10f ));
            Gun.SetActive(true);
            AimPanel.SetActive(true);
            Vector3 worldAimTarget = mouseWorldPosition;
           // Ray lookAtray = new Ray()
           
             worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 40f);
            // Debug.Log("Aiming");
            if (starterAssetsInputs.Shoot)
            {
               /* if (hitTransform != null)
                {
                    //hit Something
                    if (hitTransform.GetComponent<BulletTarget>() != null)
                    {
                        Instantiate(vfxHitBlue, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(vfxHitYellow, transform.position, Quaternion.identity);
                    }
                }*/
                Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
                Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
                starterAssetsInputs.Shoot = false;
            }
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
            Gun.SetActive(false);
            AimPanel.SetActive(false);
        }

       
    }
   /* public void Aim()
        {

        aimVirtualCamera.gameObject.SetActive(true);
        thirdPersonController.SetSensitivity(aimSensitivity);
        thirdPersonController.SetRotateOnMove(false);
        animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
        Gun.SetActive(true);
        Vector3 worldAimTarget = mouseWorldPosition;
        // Ray lookAtray = new Ray()

        worldAimTarget.y = transform.position.y;
        Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 40f);
    }*/
}

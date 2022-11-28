using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAt : MonoBehaviour
{
    Animator animator;
    Camera mainCamera;
    public Transform Target;
    
    [Range(0, 1f)]
    public float Weight = .8f;
    [Range(0, 1f)]
    public float BodyWeight = .8f;
    [Range(0, 1f)]
    public float HeadWeight = .8f;
    [Range(0, 1f)]
    public float EyesWeight = .8f;
    [Range(0, 1f)]
    public float ClampWeight = .8f;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        animator.SetLookAtWeight(Weight, BodyWeight, HeadWeight, EyesWeight, ClampWeight);
        Ray lookAtRay = new Ray(transform.position, mainCamera.transform.forward);
        Vector3 lookAtPosition = lookAtRay.GetPoint(20);
        Target.position = transform.position;
        animator.SetLookAtPosition(lookAtPosition);
    }
}

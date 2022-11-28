using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKAiming : MonoBehaviour
{
    Animator animator;

    public Transform Target;
    [Range(0, 1f)]
    public float IKWeight = 1;

    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    private void OnAnimatorIK(int layerIndex)
    {
     /*   animator.SetIKPositionWeight(AvatarIKGoal.RightHand, IKWeight);
        animator.SetIKPosition(AvatarIKGoal.RightHand, Target.position);*/
       
    }

}

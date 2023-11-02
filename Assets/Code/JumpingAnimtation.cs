using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingAnimtation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void OnJump()
    {
        var jump = Input.GetKeyDown(KeyCode.Space);
        animator.SetBool("jumping", !jump);
    }
}

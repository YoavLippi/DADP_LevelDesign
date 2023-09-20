using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component is missing on the GameObject.");
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (animator != null)
            {
                animator.SetTrigger("Attack");
            }
        }
    }
    
    
}

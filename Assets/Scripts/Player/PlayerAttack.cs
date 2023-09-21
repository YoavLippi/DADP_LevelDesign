using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    public bool midanimation;
    public KnifeAttack knife;

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
        if (Input.GetButtonDown("Fire1"))
        {
            if (animator != null)
            {
                //this is NOT the cooldown
                if (!knife.attacking)
                {
                    animator.SetTrigger("Attack");
                    StartCoroutine(attack());
                }
            }
        }
    }

    private IEnumerator attack()
    {
        knife.attacking = true;
        yield return new WaitForSeconds(0.7f);
        knife.attacking = false;
    }
}

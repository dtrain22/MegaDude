using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private bool isShooting;
    public Animator animator;

    // Update is called once per frame
    private void FixedUpdate()
    {
        Debug.Log(GetComponent<PlayerMove>().isJumping);
        if (GetComponent<Weapon>().isShooting)
        {
            animator.SetBool("IsShooting", true);
        }
        else
        {
            animator.SetBool("IsShooting", false);
        }


        if (GetComponent<PlayerMove>().isJumping)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
    }
}

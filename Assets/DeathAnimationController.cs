using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimationController : MonoBehaviour
{
    private Animator anim;

    private bool isDead;
    private Collider2D collider;

    private void Start()
    {
        anim = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    public void Die()
    {
        isDead = !isDead;
        collider.enabled = false;
        if (gameObject.tag == "CircleObs")
        {
            anim.SetBool("IsCircle", true);
        }
        if (gameObject.tag == "Obs")
        {
            anim.SetBool("IsCircle", false);
        }   
        anim.SetBool("IsDead", isDead);
    }
}

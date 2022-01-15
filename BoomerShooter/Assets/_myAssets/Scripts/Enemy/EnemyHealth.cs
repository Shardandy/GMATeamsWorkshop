using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int lifepoint = 10;
    public AudioClip deathClip;

    private Animator animator;


    /***********************************************/


    void Start() {
        animator = GetComponentInChildren<Animator>();
    }


    /***********************************************/


    public void TakeDamage (int damage) {

        lifepoint -= damage;
        if(lifepoint <= 0) {
            if(deathClip) AudioSource.PlayClipAtPoint(deathClip, transform.position);
            animator.SetTrigger("is_death");
            
            GetComponent<Collider>().enabled = false;
            transform.parent.GetComponent<EnemyController>().enabled = false;
            Destroy(transform.parent.gameObject, 3f);
        }

    }

    

}

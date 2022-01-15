using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour {

    public GameObject door;
    public GameObject nokeyLabel;

    private Animator animator;


    private void Start() {
        animator = GetComponentInChildren<Animator>();
    }


    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Player") {
            bool key = other.GetComponent<PlayerController>().bossKey;
            if(key == true) {
                animator.SetBool("is_open", true);
            } else {
                nokeyLabel.SetActive(true);
            }
        }
    }


    private void OnTriggerExit(Collider other) {
        if (other.transform.tag == "Player") {
            nokeyLabel.SetActive(false);
        }
    }

}

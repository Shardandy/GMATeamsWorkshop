using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour {

    public GameObject door;
    public Text toggleMessage;


    private bool isOpen;
    private bool isActive;
    private Animator animator;


    private void Start() {
        animator = GetComponentInChildren<Animator>(); 
    }


    private void Update() {

        if (Input.GetKeyDown(KeyCode.E) && isActive) {

            if (isOpen) {
                isOpen = false;
                toggleMessage.text = "Click E to open";
                animator.SetBool("is_open", false);
            } else {
                isOpen = true;
                toggleMessage.text = "Click E to close";
                animator.SetBool("is_open", true);
            }

        }

    }



    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Player") {
            toggleMessage.gameObject.SetActive(true);
            isActive = true;
        }
    }


    private void OnTriggerExit(Collider other) {
        if (other.transform.tag == "Player") {
            toggleMessage.gameObject.SetActive(false);
            isActive = false;
        }
    }




}

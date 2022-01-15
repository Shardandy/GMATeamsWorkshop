using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour {

    public string targetTag = "Player";
    private GameObject target;


    void Start() {
        target = GameObject.FindGameObjectWithTag(targetTag);
    }


    private void Update() { 
        if(target != null) {
            Vector3 lookPos = target.transform.position - transform.position;
            lookPos.y = 0;

            if(lookPos != Vector3.zero) {
                Quaternion rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = rotation;
            }
            
        }
    }

}

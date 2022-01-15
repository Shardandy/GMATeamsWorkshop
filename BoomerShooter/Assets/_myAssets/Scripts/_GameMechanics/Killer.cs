using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour {

    public int damage = 10;
    public AudioClip clip;


    private void OnTriggerEnter(Collider other){
        if(other.transform.tag == "Player") {
            other.GetComponent<PlayerController>().TakeDamage(damage);
            AudioSource.PlayClipAtPoint(clip, transform.position);
            Destroy(transform.parent.gameObject);
        }
    }


}

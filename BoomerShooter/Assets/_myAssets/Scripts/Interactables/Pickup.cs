using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public enum PickupType { Health, RevolverAmmo, ShotgunAmmo, BossKey }


    public int value = 10;
    public PickupType type = PickupType.Health;
    public AudioClip clip;

    private GameObject player;



    private void OnValidate() {
        SetGraphics();
    }


    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update() {
        transform.LookAt(player.transform);    
    }


    private void OnTriggerEnter(Collider other) {
     
        if(other.transform.tag == "Player") {
            other.GetComponent<PlayerController>().UpdateStats(type, value);

            AudioSource.PlayClipAtPoint(clip, transform.position);
            Destroy(gameObject);
        }

    }



    /************************************/


    void SetGraphics () {
        for(int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        transform.GetChild((int)type).gameObject.SetActive(true);
    }



}

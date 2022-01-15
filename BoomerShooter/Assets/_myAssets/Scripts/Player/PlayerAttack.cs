using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {


    [Header("Settings")]
    public int damage = 10;
    public float range = 3;
    public int ammo = 0;
    public bool infiniteAmmo = false;

    [Header("Elements")]
    public GameObject impactPrefab;
    public Text ammoLabel;

    private PlayerController player;
    private AudioSource _audiosouce;
    private Animator _animator;


    /***************************************************/


    private void Start() {
        player = GetComponentInParent<PlayerController>();
        _animator = GetComponentInChildren<Animator>();
        _audiosouce = GetComponentInChildren<AudioSource>();
    }


    void Update() {
        if(Input.GetButtonDown("Fire1")) {

            if(infiniteAmmo == true) {
                Fire();
            } else {

                if(ammo > 0) {
                    ammo -= 1;
                    ammoLabel.text = "Ammo: " + ammo.ToString();
                    Fire();
                } else {
                    player.EquipWeapon();
                }

            }

        }    
    }


    /***************************************************/


    void Fire () {
        int variante = Random.Range(0, 2);
        _animator.SetInteger("variante", variante);
        _animator.SetTrigger("is_attacking");
        _audiosouce.Play();

        RaycastHit hit;
        Transform raycastOrigin = Camera.main.transform;
        bool raggio = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, range);
        if (raggio == true) {
            if (hit.transform.tag == "Enemy") {
                EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
                enemy.TakeDamage(damage);
            }

            GameObject impact = Instantiate(impactPrefab);
            impact.transform.position = (hit.point + hit.normal * 0.0001f);
            impact.transform.rotation = Quaternion.LookRotation(hit.normal);
            impact.transform.SetParent(hit.transform, true);
            Destroy(impact, 1f);
        }

    }


}

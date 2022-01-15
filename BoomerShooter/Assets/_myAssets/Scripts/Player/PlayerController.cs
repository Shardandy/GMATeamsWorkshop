using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour {


    [Header("Settings")]
    public int lifepoint = 100;


    [Header("Elements")]
    public PlayerAttack hands;
    public PlayerAttack revolver;
    public PlayerAttack shotgun;

    [Header("HUD")]
    public Text lifepointLabel;
    public Image lifepointBar;
    public Image bosskeyIcon;

    [HideInInspector] public bool bossKey;

    private AudioSource _audiosouce;
    private Animator _animator;
    private CharacterController _character;
    private FirstPersonController _fpsController;
    private GameController gameController;


    /**************************************************************/


    void Start() {
        _animator = GetComponentInChildren<Animator>();
        _audiosouce = GetComponentInChildren<AudioSource>();
        _character = GetComponent<CharacterController>();
        _fpsController = GetComponent<FirstPersonController>();

        EquipWeapon();
        lifepointLabel.text = lifepoint.ToString();
        bosskeyIcon.gameObject.SetActive(false);

        GameObject game_controller_obj = GameObject.FindGameObjectWithTag("GameController");
        gameController = game_controller_obj.GetComponent<GameController>();
    }


    private void Update() {
        
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            SwitchWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            SwitchWeapon(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            SwitchWeapon(3);
        }

    }


    /**************************************************************/


    public void LockPlayer () {
        _fpsController.enabled = false;
        _character.enabled = false;
    }


    public void UnlockPlayer () {
        _fpsController.enabled = true;
        _character.enabled = true;
    }


    #region /********************** Stats *********************************/



    public void TakeDamage(int damage) {
        _animator.SetTrigger("is_hitted");
        lifepoint -= damage;
        lifepoint = lifepoint = Mathf.Clamp(lifepoint, 0, 100);
        lifepointLabel.text = lifepoint.ToString();
        lifepointBar.fillAmount = (float)lifepoint / 100; ;

        if (lifepoint <= 0) {
            Death();
        }

    }


    public void UpdateStats (Pickup.PickupType type, int value) {
        _animator.SetTrigger("is_buffed");

        switch(type) {

            case Pickup.PickupType.Health:
                lifepoint += value;
                lifepoint = Mathf.Clamp(lifepoint, 0, 100);
                lifepointLabel.text = lifepoint.ToString();
                lifepointBar.fillAmount = lifepoint / 100;
                break;
            case Pickup.PickupType.RevolverAmmo:
                revolver.ammo += value;
                revolver.ammoLabel.text = "Ammo: " + revolver.ammo.ToString();
                EquipWeapon();
                break;
            case Pickup.PickupType.ShotgunAmmo:
                shotgun.ammo += value;
                shotgun.ammoLabel.text = "Ammo: " + shotgun.ammo.ToString();
                EquipWeapon();
                break;
            case Pickup.PickupType.BossKey:
                bossKey = true;
                bosskeyIcon.gameObject.SetActive(true);
                break;


        }
    }


    #endregion


    #region /********************** Weapons *********************************/


    public void EquipWeapon () {

        hands.gameObject.SetActive(true);
        revolver.gameObject.SetActive(false);
        shotgun.gameObject.SetActive(false);

        if(revolver.ammo > 0) {
            hands.gameObject.SetActive(false);
            revolver.gameObject.SetActive(true);
        }

        if(shotgun.ammo > 0) {
            hands.gameObject.SetActive(false);
            revolver.gameObject.SetActive(false);
            shotgun.gameObject.SetActive(true);
        }


    }


    public void SwitchWeapon(int index) {

        hands.gameObject.SetActive(false);
        revolver.gameObject.SetActive(false);
        shotgun.gameObject.SetActive(false);


        switch(index) {
            case 1:
                hands.gameObject.SetActive(true);
                break;
            case 2:
                if(revolver.ammo > 0) {
                    revolver.gameObject.SetActive(true);
                } else {
                    hands.gameObject.SetActive(true);
                }
                break;
            case 3:
                if (shotgun.ammo > 0) {
                    shotgun.gameObject.SetActive(true);
                } else {
                    hands.gameObject.SetActive(true);
                }
                break;
        }

    }


    #endregion


    #region /********************** Game mechanics *********************************/


    public void Death() {
        SwitchWeapon(0);
        _animator.SetBool("is_dead", true);
        LockPlayer();
        gameController.GameOver();
    }


    public void LevelEnd() {
        SwitchWeapon(0);
        LockPlayer();
        gameController.EndLevel();
    }


    #endregion


}

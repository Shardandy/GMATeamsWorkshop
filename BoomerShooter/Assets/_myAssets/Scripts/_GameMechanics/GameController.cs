using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {


    public Timer timer;
    public GameObject gameoverPanel;
    public GameObject levelEndPanel;
    public GameObject fadePanel;



    /***************************************/


    #region /********************** GUI *********************************/

    public void ShowGameoverPanel() {
        gameoverPanel.SetActive(true);
    }

    public void ShowLevelEndPanel() {
        levelEndPanel.SetActive(true);
    }


    public void ShowFadePanel() {
        fadePanel.SetActive(true);
    }

    #endregion


    public void GameOver () {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        BloccaTimer();
        BloccaNemici();
        Invoke("ShowGameoverPanel", 3f);
    }


    public void EndLevel () {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        BloccaTimer();
        BloccaNemici();
        Invoke("ShowLevelEndPanel", 3f);
    }


    public void BloccaTimer() {
        timer.BloccaTimer();
    }

    public void BloccaNemici () {
        GameObject[] enemiesList = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemiesList) {
            enemy.GetComponentInParent<EnemyController>().enabled = false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    public void CaricaScena(string scene_name) {
        SceneManager.LoadScene(scene_name);
    }


    public void ProssimoLivello () {
        int index = SceneManager.GetActiveScene().buildIndex +1;
        SceneManager.LoadScene(index);
    }


    public void RipetiLivello () {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }


    public void RitornaAlMainMenu () {
        SceneManager.LoadScene("MainMenu");
    }



}

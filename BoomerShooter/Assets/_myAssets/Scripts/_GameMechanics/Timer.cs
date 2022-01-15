using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float tempoGioco = 90;
    public Text labelTempo;
    public GameObject graficaGameover;
    public GameObject graficaFineLivello;

    private float tempoCorrente = 0;
    
    void Start() {
        tempoCorrente = tempoGioco;
        labelTempo.text = tempoCorrente.ToString();
        Invoke("AggiornaTempo", 1f);
    }


    void AggiornaTempo () {

        tempoCorrente -= 1;
        labelTempo.text = tempoCorrente.ToString();

        if(tempoCorrente <= 0) {
            //graficaFineLivello.SetActive(false);
            //graficaGameover.SetActive(true);

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerController>().Death();

        }  else {
            Invoke("AggiornaTempo", 1f);
        }

    }

    public void BloccaTimer () {
        if(IsInvoking("AggiornaTempo")) {
            CancelInvoke("AggiornaTempo");
        }
    }



}

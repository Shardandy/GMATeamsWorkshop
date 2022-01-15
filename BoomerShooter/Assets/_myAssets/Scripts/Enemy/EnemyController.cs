using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour {

    [Header("Settings")]
    public float sight = 10;
    public float wanderingSpeed = 3f;
    public float chaseSpeed = 5f;
    
    [Header("Path")]
    public bool randomPath;
    public Transform pathPointContainer;

    private Vector3 destination;
    private GameObject player;
    private int pathIndex = 0;

    /***********************************************/


    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        destination = transform.position;
    }

    
    void Update() {

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= sight) {
            ChasePlayer();
        } else {
            Wandering();
        }
        
    }


    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sight);
    }



    /***********************************************/


    void Wandering () {
        float distance = Vector3.Distance(transform.position, destination);
        if (distance > 0.1f) {
            transform.position = Vector3.MoveTowards(transform.position, destination, wanderingSpeed * Time.deltaTime);
        } else {
            if(IsInvoking("SetNextDestination") == false) {
                float delay = Random.Range(1, 5);
                Invoke("SetNextDestination", delay);
            }
        }
    }


    void ChasePlayer() {
        CancelInvoke("SetNextDestination");
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, chaseSpeed * Time.deltaTime);
    }


    void SetNextDestination() {
        
        if(randomPath) {

            pathIndex = (int) Random.Range(1, pathPointContainer.childCount);
            destination = pathPointContainer.GetChild(pathIndex).position;
            pathPointContainer.GetChild(pathIndex).SetAsFirstSibling();

        } else {
            destination = pathPointContainer.GetChild(pathIndex).position;
            pathIndex += 1;
            if (pathIndex >= pathPointContainer.childCount) {
                pathIndex = 0;
            }
        }

    }



}

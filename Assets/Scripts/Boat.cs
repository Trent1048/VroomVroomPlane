using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour {
    public AudioSource chaChing;

    void OnTriggerEnter(Collider other){
        Score.updateScore(3);
        chaChing.Play();
        Destroy(transform.gameObject);
    }
}
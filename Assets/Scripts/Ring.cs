using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour {
    public AudioSource chaChing;

    void OnTriggerEnter(Collider other){
        if(other.GetType() == typeof(MeshCollider)){
            Destroy(gameObject);
        }
    }

    void OnTriggerExit(Collider other){
        chaChing.Play();
        Score.updateScore(1);
        Destroy(gameObject);
    }
}
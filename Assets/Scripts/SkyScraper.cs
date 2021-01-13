using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyScraper : MonoBehaviour {
    public AudioSource chaChing;

    void Start(){
        transform.Rotate(-90, -90, -90);
    }

    void OnTriggerEnter(Collider other){
        if(other.GetType() != typeof(MeshCollider)){
            Score.updateScore(3);
        }
        chaChing.Play();
        Destroy(gameObject);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlaneController : MonoBehaviour {

    public int moveSpeed;
    public GameObject player;
    private Rigidbody body;
    public bool trackPlayer = false;
    public AudioSource chaChing;

    void Start() {
        if (this.GetComponent<Rigidbody>() != null){
            body = this.GetComponent<Rigidbody>();
        }
        transform.LookAt(player.transform);
    }

    void Update() {
        if(trackPlayer){
            transform.LookAt(player.transform);
        }
        body.velocity = transform.forward * moveSpeed;
    }

    void OnTriggerEnter(Collider other){
        if(other.GetType() != typeof(MeshCollider)){
            Score.updateScore(5);
            chaChing.Play();
        }
        Destroy(gameObject);
    }
}

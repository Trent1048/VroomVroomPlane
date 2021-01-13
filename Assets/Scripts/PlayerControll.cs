using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour {
    public float initMoveSpeed;
    public float initPitchSpeed;
    public float initRollSpeed;
    public float initYawSpeed;
    private float moveSpeed;
    private float pitchSpeed;
    private float rollSpeed;
    private float yawSpeed;
    public GameObject Explosion;
    public AudioSource vroom;
    public AudioSource boom;
    private bool moving = true;
    private const float SCORE_MULTIPLIER = 10f;

    private Rigidbody body;
    void Start() {
        if (this.GetComponent<Rigidbody>() != null){
            body = this.GetComponent<Rigidbody>();
        }
        vroom.loop = true;
        updateSpeed();
    }

    void Update() {
        vroom.transform.position = transform.position;
        if(moving){
            updateSpeed();
            body.velocity = transform.forward * moveSpeed;
            if (Input.GetKey(KeyCode.W)){
                transform.Rotate(Vector3.left * Time.deltaTime * pitchSpeed);
            } else if (Input.GetKey(KeyCode.S)){
                transform.Rotate(Vector3.right * Time.deltaTime * pitchSpeed);
            }

            if (Input.GetKey(KeyCode.Q)){
                transform.Rotate(Vector3.forward * Time.deltaTime * rollSpeed);
            } else if (Input.GetKey(KeyCode.E)){
                transform.Rotate(Vector3.back * Time.deltaTime * rollSpeed);
            }

            if (Input.GetKey(KeyCode.A)){
                transform.Rotate(Vector3.down * Time.deltaTime * yawSpeed);
            } else if (Input.GetKey(KeyCode.D)){
                transform.Rotate(Vector3.up * Time.deltaTime * yawSpeed);
            }

        } else {
            body.velocity = Vector3.zero;
        }
    }

    private void updateSpeed(){
        moveSpeed = initMoveSpeed + Mathf.Sqrt((initMoveSpeed * ((Score.getScore() + 1) / SCORE_MULTIPLIER)));
        pitchSpeed = initPitchSpeed + Mathf.Sqrt((initPitchSpeed * ((Score.getScore() + 1) / SCORE_MULTIPLIER)));
        rollSpeed = initRollSpeed + Mathf.Sqrt((initRollSpeed * ((Score.getScore() + 1) / SCORE_MULTIPLIER)));
        yawSpeed = initYawSpeed + Mathf.Sqrt((initYawSpeed * ((Score.getScore() + 1) / SCORE_MULTIPLIER)));
    }

    private void OnCollisionEnter(Collision other){
        GameObject boomBoom = Instantiate(Explosion, transform);
        boom.Play();
        boomBoom.SetActive(true);
        moving = false;
        StartCoroutine(Crash());
    }

    private IEnumerator Crash(){
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Main Menu");
    }
}

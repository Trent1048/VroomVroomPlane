using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour {
    public Transform followMe;
    public Vector2 orbitOffset;
    
    void Start() {
        
    }

    void FixedUpdate() {
        Vector3 lerpV = followMe.position + new Vector3(-followMe.forward.x * orbitOffset.x, orbitOffset.y, -followMe.forward.z * orbitOffset.x);
        transform.position = Vector3.Lerp(transform.position, lerpV, Time.deltaTime * 5);
        transform.LookAt(followMe.position);
    }
}

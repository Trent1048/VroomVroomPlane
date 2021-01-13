using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureGenerator : MonoBehaviour {
    public GameObject ring;
    public GameObject plane;
    public GameObject boat;
    public GameObject otherPlane;
    public GameObject skyScraper;

    private const int generationDist = 300;

    private void GenerateRing() {
        GameObject pointsRing = Instantiate(ring, new Vector3(plane.transform.position.x + Random.Range(-generationDist, generationDist), Random.Range(10, 70), plane.transform.position.z + Random.Range(-generationDist, generationDist)), new Quaternion(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)));
        pointsRing.SetActive(true);
    }

    private void GenerateBoat() {
        GameObject boatyBoat = Instantiate(boat, new Vector3(plane.transform.position.x + Random.Range(-generationDist, generationDist), 4.59f, plane.transform.position.z + Random.Range(-generationDist, generationDist)), new Quaternion(0,Random.Range(-1f, 1f),0,0));
        boatyBoat.SetActive(true);
    }

    private void GeneratePlane() {
        GameObject enemyPlane = Instantiate(otherPlane, new Vector3(plane.transform.position.x + Random.Range(-generationDist, generationDist), Random.Range(20, 70), plane.transform.position.z + Random.Range(-generationDist, generationDist)), new Quaternion(0,0,0,0));
        enemyPlane.SetActive(true);
    }

    private void GenerateSkyScraper() { 
        GameObject tallBuilding = Instantiate(skyScraper, new Vector3(plane.transform.position.x + Random.Range(-generationDist, generationDist), 13f, plane.transform.position.z + Random.Range(-generationDist, generationDist)), new Quaternion(0,0,0,0));
        tallBuilding.SetActive(true);
    }

    private bool spawned = false;
    private float time = 0f;

    void Update() {
        time += Time.deltaTime;

        if((int)time % 20 == 0){
            GenerateRing();
            spawned = true;
        }
        if((int)time % 60 == 0){
            GenerateBoat();
            spawned = true;
        }
        if((int)time % 40 == 0){
            GeneratePlane();
            spawned = true;
        }
        if((int)time % 100 == 0){
            GenerateSkyScraper();
            spawned = true;
        }

        if(spawned){
            time++;
            spawned = false;
        }
    }
}
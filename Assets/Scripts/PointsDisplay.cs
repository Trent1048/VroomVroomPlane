using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsDisplay : MonoBehaviour {

    public Text pointsText;

    void Update(){
        pointsText.text = "POINTS: " + Score.getScore();
    }
}

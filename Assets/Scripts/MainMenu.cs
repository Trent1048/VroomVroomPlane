using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public RawImage background;
    public GameObject instruction;
    private bool instructionsShown = false;

    void Start(){
        Canvas canvas = FindObjectOfType<Canvas>();
        background.GetComponent<RectTransform>().sizeDelta = new Vector2(canvas.GetComponent<RectTransform>().rect.width, canvas.GetComponent<RectTransform>().rect.height);
    }

    public void play(){
        SceneManager.LoadScene("game");
        Score.resetScore();
    }

    public void instructions(){
        instructionsShown = !instructionsShown;
        instruction.SetActive(instructionsShown);
    }

    public void quit(){
        Application.Quit();
    }
}

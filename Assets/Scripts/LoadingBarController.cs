using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBarController : MonoBehaviour {

    public GameObject loadingScreenObj;
    public Slider loadingBar;

    void Start(){
        StartCoroutine(LoadingScreen());
    }

    IEnumerator LoadingScreen(){
        loadingScreenObj.SetActive(true);
        for(int time = 1; time <= 6; time ++){
            yield return new WaitForSeconds(0.5f);
            loadingBar.value = (time + 1) / 6.0f;
        }
        loadingScreenObj.SetActive(false);
    }
}

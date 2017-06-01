using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuBehavior : MonoBehaviour {

	void Start () {
        Time.timeScale = 1;
    }


    public void StartDishGame() {
        SceneManager.LoadScene("Demo_DishWashTimed");
    }

    public void StartSplineActivity() {
        SceneManager.LoadScene("Demo_SplineActivity");
        //SceneManager.LoadScene("__scenemanager_test_scene");
    }

    public void StartBlockPinchGame() {
        SceneManager.LoadScene("Demo_BlockPinch");
    }
}

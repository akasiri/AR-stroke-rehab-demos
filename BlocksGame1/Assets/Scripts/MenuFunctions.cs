using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartTutorial () {
        SceneManager.LoadScene("Tutorial");
    }

    public void StartTimedPlay () {
        SceneManager.LoadScene("TimedPlay");
    }
}

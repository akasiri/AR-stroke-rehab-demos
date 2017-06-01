using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public GameObject finishScreen;
    public GameObject plateManager;

    public GameObject timerText;
    public GameObject finishText;

    public int timeRemaining = 100;

    private float exactTimeRemaining;
    private string message;

    private int totalTime;

	// Use this for initialization
	void Start () {
        message = "Time Remaining: ";
        exactTimeRemaining = (float) timeRemaining;

        totalTime = timeRemaining;
    }
	
	// Update is called once per frame
	void Update () {
        if (timeRemaining <= 0) {
            finishText.GetComponent<Text>().text = "Hooray!\n" + plateManager.GetComponent<PlateManager>().platesWashed + " dishes washed in " + totalTime + " seconds.";

            finishScreen.SetActive(true);
            plateManager.SetActive(false);
        }
        else {
            exactTimeRemaining -= Time.deltaTime;
            timeRemaining = (int)exactTimeRemaining;

            timerText.gameObject.GetComponent<Text>().text = message + timeRemaining;
        }
    }
}

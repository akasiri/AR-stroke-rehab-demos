using UnityEngine;
using System.Collections;

public class UpdateGrabSprite : MonoBehaviour {

    public Sprite handOpen;
    public Sprite handClosed;

    private int timer = -1;

    void Update () {

        if (timer > 0) {
            timer -= 1;
        }
        else if (timer == 0) {
            GetComponent<SpriteRenderer>().sprite = handOpen;
            timer -= 1;
        }
    }

    public void OnGrabBegin () {
        GetComponent<SpriteRenderer>().sprite = handClosed;

        timer = 100;
    }

    public void OnGrabEnd () { 
        GetComponent<SpriteRenderer>().sprite = handOpen;
    }
}

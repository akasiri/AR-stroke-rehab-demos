using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poker : MonoBehaviour {

    public bool poking;

    // switches to false when below near
    // switches to true when above far
    public float near = 0.25f;
    public float far = 1.75f;

    void Start() {
    }

    void Update() {
        if (transform.position.z <= near) {
            poking = false;
            //GetComponent<SpriteRenderer>().color = Color.red;
        }

        else if (transform.position.z >= far) {
            poking = true;
            //GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
}

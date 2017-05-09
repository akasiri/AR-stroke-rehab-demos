using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyFeedingCursor : MonoBehaviour {

    void Update() {
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag == "Baby") {
            coll.gameObject.GetComponent<BabyStateManager>().StartHighlight();    
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.tag == "Baby") {
            coll.gameObject.GetComponent<BabyStateManager>().StopHighlight();
        }
    }

    void OnTriggerStay2D(Collider2D coll) {
        if (coll.tag == "Baby") {
            coll.GetComponent<BabyStateManager>().SetDistance(transform.position.z);
        }
    }

}

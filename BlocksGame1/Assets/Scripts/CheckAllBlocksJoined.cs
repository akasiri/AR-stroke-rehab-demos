using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAllBlocksJoined : MonoBehaviour {

    public GameObject displayWinState;

	void Update () {
        if (transform.childCount <= 1) {
            // game is over, reached win state

            if (displayWinState != null) {
                displayWinState.SetActive(true);
            }
        }
	}
}
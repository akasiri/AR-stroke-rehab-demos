// Depracated, use ExitSceneOnEsc

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOnEsc : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
	}
}

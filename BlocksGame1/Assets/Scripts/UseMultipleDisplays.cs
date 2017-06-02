using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMultipleDisplays : MonoBehaviour {

	void Start () {
        for (int i = 0; i < Display.displays.Length; i++) {
            if (!Display.displays[i].active) {
                Display.displays[i].Activate();
            }
        }
    }
}

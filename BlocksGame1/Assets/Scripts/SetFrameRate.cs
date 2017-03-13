using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFrameRate : MonoBehaviour {

    public int frameRate = 60;

	void Start () {
        Application.targetFrameRate = frameRate;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSizeWithHeight : MonoBehaviour {

    public float scaleFactor = 2f;

    private Vector3 startingScale;
    private float startingPosition;

	void Start () {
        startingScale = transform.localScale;
        startingPosition = transform.position.y + (2 * System.Math.Abs(transform.position.y));
	}
	
	void Update () {

        float scale = scaleFactor * ((startingPosition - transform.position.y) / startingPosition);

        if (scale < 0.8f) {
            scale = 0.8f;
        }

        transform.localScale = startingScale * scale;
	}
}

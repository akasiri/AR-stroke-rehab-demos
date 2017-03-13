/*
 * Code transcribed from Sebastian Lague's YouTube video: "Unity Touchscreen Input Tutorial"
 * Doesn't work with desktop touchscreens
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMonitor : MonoBehaviour {

    public Camera cam;
    public LayerMask touchInputMask;

    //private List<GameObject> touchList = new List<GameObject>();
    //private GameObject[] touchesOld;

    void OnEnable() {

    }

    void OnDisable() {

    }
	
	void Update () {
		if (Input.touchCount > 0) {

            Debug.Log("Touch registered!!!");

            //touchesOld = new GameObject[touchList.Count];
            //touchList.CopyTo(touchesOld);
            //touchList.Clear();

            foreach (Touch touch in Input.touches) {

                Ray ray = cam.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, touchInputMask)) {

                    GameObject recipient = hit.transform.gameObject;
                    //touchList.Add(recipient);

                    if (touch.phase == TouchPhase.Began) {
                        recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Ended) {
                        recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
                        recipient.SendMessage("OnTouch", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Canceled) {
                        recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                        //recipient.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }

            /* The video had this, but to be honest, I don't know if it is really necessary. 
             * 
             * The purpose of this code is to address touches that end without ever reaching the 
             * Ended or Canceled phases. I don't know if this will really happen though. In the
             * video the example that Sebstain uses is if the user slides their finger off the side 
             * of the screen, but I think that will still trigger an Ended phase.
             */
            //foreach (GameObject g in touchesOld) {
            //    if (!touchList.Contains(g)) {
            //        g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
            //    }
            //}
        }
	}
}

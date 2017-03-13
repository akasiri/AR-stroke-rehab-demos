using System;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;
using UnityEngine.UI;

namespace TouchScript.Behaviors {
    public class Joinable : MonoBehaviour {

        public AudioSource joinSFX;

        public float distanceToJoin = 100f;
        public float scaleFactor = 0.5f;

        private List<TransformGesture> gestures = new List<TransformGesture>();

        void OnEnable () {
            Gesture[] g = GetComponents<Gesture>();
            for (int i = 0; i < g.Length; i++) {
                TransformGesture transformGesture = g[i] as TransformGesture;
                if (transformGesture == null) continue;
                this.gestures.Add(transformGesture);
            }
        }

        void OnDisable () {
            this.gestures.Clear();
        }

        void OnCollisionStay (Collision coll) {
            if (coll.gameObject.tag == "Block") {

                bool checker = false;

                // tie breaker for which object checks to join and preforms the join.
                // first checks position.x, then if tie, position.z
                if (transform.position.x < coll.transform.position.x) {
                    checker = true;
                }
                else if (transform.position.x == coll.transform.position.x) {
                    if (transform.position.z < coll.transform.position.z) {
                        checker = true;
                    }
                }

                if (checker) {

                    // for each touch in each gesture in each colliding object...
                    // (there should only be one gesture and one touch point per colliding, but they are designed to potentially hold more)
                    for (int thisGestCounter = 0; thisGestCounter < this.gestures.Count; thisGestCounter++) {
                        IList<TouchPoint> thisTouches = this.gestures[thisGestCounter].ActiveTouches;
                        for (int i = 0; i < thisTouches.Count; i++) {
                            TouchPoint thisTouch = thisTouches[i];

                            for (int collGestCounter = 0; collGestCounter < coll.gameObject.GetComponent<Joinable>().gestures.Count; collGestCounter++) {
                                IList<TouchPoint> collTouches = coll.gameObject.GetComponent<Joinable>().gestures[collGestCounter].ActiveTouches;
                                for (int j = 0; j < collTouches.Count; j++) {
                                    TouchPoint collTouch = collTouches[j];

                                    // compare the distance between the touches and see if they are close enough to warrant joining
                                    if (Math.Pow(collTouch.Position.x - thisTouch.Position.x, 2) +
                                            Math.Pow(collTouch.Position.y - thisTouch.Position.y, 2)
                                            < Math.Pow(distanceToJoin, 2)) {

                                        GameObject child = Instantiate(gameObject, transform.position, transform.rotation);
                                        child.transform.parent = this.transform.parent;

                                        if (child.GetComponent<Joinable>().joinSFX != null) {
                                            child.GetComponent<Joinable>().joinSFX.Play();
                                        }


                                        // Add a little of the smaller scale to the bigger scale
                                        Vector3 smallerScale;
                                        Vector3 largerScale;

                                        if (this.transform.localScale.magnitude > coll.transform.localScale.magnitude) {
                                            smallerScale = coll.transform.localScale;
                                            largerScale = this.transform.localScale;
                                        }
                                        else {
                                            smallerScale = this.transform.localScale;
                                            largerScale = coll.transform.localScale;
                                        }

                                        child.transform.localScale = largerScale + (smallerScale * scaleFactor);


                                        // Average colors
                                        float avgRed = this.GetComponent<Renderer>().material.color.r +
                                            coll.gameObject.GetComponent<Renderer>().material.color.r / 2f;
                                        float avgGreen = this.GetComponent<Renderer>().material.color.g +
                                            coll.gameObject.GetComponent<Renderer>().material.color.g / 2f;
                                        float avgBlue = this.GetComponent<Renderer>().material.color.b +
                                            coll.gameObject.GetComponent<Renderer>().material.color.b / 2f;

                                        child.GetComponent<Renderer>().material.color = new Color(avgRed, avgGreen, avgBlue);


                                        // delete parent objects
                                        coll.gameObject.SetActive(false);
                                        UnityEngine.Object.Destroy(coll.gameObject);

                                        this.gameObject.SetActive(false);
                                        UnityEngine.Object.Destroy(this.gameObject);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

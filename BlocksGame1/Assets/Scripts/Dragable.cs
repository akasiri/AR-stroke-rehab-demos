using System;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

namespace TouchScript.Behaviors {
    public class Dragable : MonoBehaviour {

        private List<TransformGesture> gestures = new List<TransformGesture>();

        void OnEnable() {
            Gesture[] g = GetComponents<Gesture>();
            for (int i = 0; i < g.Length; i++) {
                TransformGesture transformGesture = g[i] as TransformGesture;
                if (transformGesture == null) continue;

                this.gestures.Add(transformGesture);
                transformGesture.Transformed += transformHandler;
            }
        }

        void OnDisable() {
            for (int i = 0; i < gestures.Count; i++) {
                TransformGesture transformGesture = gestures[i];
                transformGesture.Transformed -= transformHandler;
            }
            this.gestures.Clear();
        }

        #region Event handlers       
        private void transformHandler(object sender, EventArgs e) {
            TransformGesture gesture = sender as TransformGesture;
            gesture.ApplyTransform(transform);
        }
        #endregion
    }
}

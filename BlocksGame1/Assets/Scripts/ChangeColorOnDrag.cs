using System;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

namespace TouchScript.Behaviors {
    public class ChangeColorOnDrag : MonoBehaviour {
        private List<TransformGesture> gestures = new List<TransformGesture>();

        void OnEnable () {
            var g = GetComponents<Gesture>();
            for (var i = 0; i < g.Length; i++) {
                var transformGesture = g[i] as TransformGesture;
                if (transformGesture == null) continue;

                gestures.Add(transformGesture);
                transformGesture.Transformed += transformHandler;
            }
        }

        void OnDisable () {
            for (var i = 0; i < gestures.Count; i++) {
                var transformGesture = gestures[i];
                transformGesture.Transformed -= transformHandler;
            }
            gestures.Clear();
        }

        #region Event handlers       
        private void transformHandler(object sender, EventArgs e) {
            float r = UnityEngine.Random.Range(0f, 1f);
            float g = UnityEngine.Random.Range(0f, 1f);
            float b = UnityEngine.Random.Range(0f, 1f);

            GetComponent<Renderer>().material.SetColor("_Color", new Color(r,g,b));
        }
        #endregion
    }
}

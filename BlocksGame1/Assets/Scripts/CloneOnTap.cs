using System;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

namespace TouchScript.Behaviors {
    public class CloneOnTap : MonoBehaviour {
        private List<TapGesture> gestures = new List<TapGesture>();

        void OnEnable() {
            var g = GetComponents<Gesture>();
            for (var i = 0; i < g.Length; i++) {
                var tapGesture = g[i] as TapGesture;
                if (tapGesture == null) continue;

                gestures.Add(tapGesture);
                tapGesture.Tapped += tapHandler;
            }
        }

        void OnDisable() {
            for (var i = 0; i < gestures.Count; i++) {
                var tapGesture = gestures[i];
                tapGesture.Tapped -= tapHandler;
            }
            gestures.Clear();
        }

        #region Event handlers       
        private void tapHandler(object sender, EventArgs e) { 
            GameObject clone = Instantiate(gameObject, transform.position, transform.rotation);
            clone.transform.parent = this.transform.parent;

            clone.GetComponent<Renderer>().material.color = new Color(
                clone.GetComponent<Renderer>().material.color.r,
                clone.GetComponent<Renderer>().material.color.g,
                clone.GetComponent<Renderer>().material.color.b);
        }
        #endregion
    }
}

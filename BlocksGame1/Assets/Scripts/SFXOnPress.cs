using System;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

namespace TouchScript.Behaviors {
    public class SFXOnPress : MonoBehaviour {

        public AudioSource tapSFX;

        private List<PressGesture> gestures = new List<PressGesture>();

        void OnEnable() {
            Gesture[] g = GetComponents<Gesture>();
            for (int i = 0; i < g.Length; i++) {
                PressGesture gesture = g[i] as PressGesture;
                if (gesture == null) continue;

                gestures.Add(gesture);
                gesture.Pressed += pressHandler;
            }
        }

        void OnDisable() {
            for (int i = 0; i < gestures.Count; i++) {
                PressGesture gesture = gestures[i];
                gesture.Pressed -= pressHandler;
            }
            gestures.Clear();
        }

        #region Event handlers       
        private void pressHandler(object sender, EventArgs e) {
            if (tapSFX != null) {
                tapSFX.Play();
            }
        }
        #endregion
    }
}

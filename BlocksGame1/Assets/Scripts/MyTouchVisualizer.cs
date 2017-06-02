using System.Collections.Generic;
using TouchScript.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace TouchScript.Behaviors {
    public class MyTouchVisualizer : MonoBehaviour {
        public int sourceScreenWidth = 1920;
        public int sourceScreenHeight = 1080;

        public int targetScreenWidth = 800;
        public int targetScreenHeight = 600;

        public int padding = 5;

        public GameObject marker;
        public GameObject markerHolder;
        public GameObject touchCoordHolder;

        public Text touchCoordDisplay;

        private void OnEnable() {
            if (TouchManager.Instance != null) {
                TouchManager.Instance.TouchesMoved += touchesMovedHandler;
            }
        }

        private void OnDisable() {
            if (TouchManager.Instance != null) {
                TouchManager.Instance.TouchesMoved -= touchesMovedHandler;
            }
        }

        #region Event handlers
        private void touchesMovedHandler(object sender, TouchEventArgs e) {
            for (var i = 0; i < e.Touches.Count; i++) {

                Vector3 tpos = e.Touches[i].Position;

                touchCoordDisplay.text = "Touch Coord: (" + tpos.x + ", " + tpos.y + ")";

                GameObject newMarker = Instantiate(marker);
                newMarker.transform.parent = markerHolder.transform;

                // sets the min and max boundaries with padding
                if (tpos.x < 0 + padding) {
                    tpos = new Vector3(padding, tpos.y, tpos.z);
                }
                else if (tpos.x > sourceScreenWidth - padding) {
                    tpos = new Vector3(sourceScreenWidth - padding, tpos.y, tpos.z);
                }

                if (tpos.y < 0 + padding) {
                    tpos = new Vector3(tpos.x, padding, tpos.z);
                }
                if (tpos.y > sourceScreenHeight - padding) {
                    tpos = new Vector3(tpos.x, sourceScreenHeight - padding, tpos.z);
                }

                // anchors set the relative postition within the parent GameObject in Canvases
                newMarker.GetComponent<RectTransform>().anchorMin = new Vector2(tpos.x / sourceScreenWidth, tpos.y / sourceScreenHeight);
                newMarker.GetComponent<RectTransform>().anchorMax = new Vector2(tpos.x / sourceScreenWidth, tpos.y / sourceScreenHeight);

                newMarker.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 0f, 0f);
            }
        }
        #endregion
    }
}
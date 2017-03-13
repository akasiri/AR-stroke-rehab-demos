using System.Collections.Generic;
using TouchScript.Utils;
using UnityEngine;

namespace TouchScript.Behaviors {
    public class MyTouchVisualizer : MonoBehaviour {
        public int targetScreenWidth = 1366;
        public int targetScreenHeight = 768;

        public GameObject marker;

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
            var count = e.Touches.Count;
            for (var i = 0; i < count; i++) {
                GameObject newMarker = Instantiate(marker);
                newMarker.transform.parent = this.transform;

                Vector3 tpos = e.Touches[i].Position;
                newMarker.transform.position = new Vector3(-tpos.x + targetScreenWidth, -tpos.y + targetScreenHeight, 0);
            }
        }
        #endregion
    }
}
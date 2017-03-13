using System;
using System.Collections.Generic;
using TouchScript.Gestures;
using TouchScript.Hit;
using UnityEngine;

namespace TouchScript.Behaviors {
    public class DrawOnTexture : MonoBehaviour {

        public int brushSize = 10;

        private Texture2D texture;

        void Start() {
            texture = Instantiate(GetComponent<Renderer>().material.mainTexture) as Texture2D;
            GetComponent<Renderer>().material.mainTexture = texture;
        }

        private List<TransformGesture> gestures = new List<TransformGesture>();

        void OnEnable() {
            var g = GetComponents<Gesture>();
            for (var i = 0; i < g.Length; i++) {
                var transformGesture = g[i] as TransformGesture;
                if (transformGesture == null) continue;

                gestures.Add(transformGesture);
                transformGesture.Transformed += transformHandler;
            }
        }

        void OnDisable() {
            for (var i = 0; i < gestures.Count; i++) {
                var transformGesture = gestures[i];
                transformGesture.Transformed -= transformHandler;
            }
            gestures.Clear();
        }

        #region Event Handlers
        private void transformHandler(object sender, EventArgs e) {
            TransformGesture gesture = sender as TransformGesture;

            TouchHit touchHit;
            gesture.GetTargetHitResult(out touchHit);
            Vector2 textureHit = touchHit.RaycastHit.textureCoord;

            // establish brush boundaries
            int centerX = (int) (textureHit.x * texture.width);
            int xmin = centerX - brushSize >= 0 ? centerX - brushSize : 0;
            int xmax = centerX + brushSize < texture.width ? centerX + brushSize : texture.width;

            int centerY = (int) (textureHit.y * texture.height);
            int ymin = centerY - brushSize >= 0 ? centerY - brushSize : 0;
            int ymax = centerY + brushSize < texture.height ? centerY + brushSize : texture.height;

            // paint pixels within the field of the brush
            for (int i = xmin; i <= xmax; i++) {
                for (int j = (int) ymin; j <= ymax; j++) { 
                    if (texture.GetPixel(i, j) == new Color(55f/255f, 27f/255f, 5f/255f)) {
                        texture.SetPixel(i, j, Color.red);
                    }
                    else if (texture.GetPixel(i, j) == Color.red) {
                        texture.SetPixel(i, j, Color.red);
                    }
                    else {
                        texture.SetPixel(i, j, Color.cyan);
                    }
                }
            }

            texture.Apply();
        }
        #endregion
    }
}
//Source: https://www.youtube.com/watch?v=sHE5ubsP-E8
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class WhiteboardMarker : MonoBehaviour
{
    public Transform tip;
    public int penSize = 5;
    private Renderer r;
    private Color[] colors;
    private float tipHeight;

    private RaycastHit touch;
    private Whiteboard whiteboard;
    private Vector2 touchPos, lastTouchPos;
    private bool touchedLastFrame;
    //private Quaternion lastTouchRot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        r = tip.GetComponent<Renderer>();
        colors = Enumerable.Repeat(r.material.color, penSize*penSize).ToArray();
        tipHeight = (tip.localScale.y / 2);
    }

    // Update is called once per frame
    void Update()
    {
        Draw();
    }

    private void Draw() {
        if (Physics.Raycast(tip.position, transform.up, out touch, tipHeight)) {

            if (touch.transform.CompareTag("Whiteboard")) {

                if (whiteboard == null) {
                    whiteboard = touch.transform.GetComponent<Whiteboard>();
                }

                touchPos = new Vector2(touch.textureCoord.x, touch.textureCoord.y);

                var x = (int)(touchPos.x * whiteboard.textureSize.x - (penSize / 2));
                var y = (int)(touchPos.y * whiteboard.textureSize.y - (penSize / 2));

                if (y < 0 || y > whiteboard.textureSize.y || x < 0 || x > whiteboard.textureSize.x) {
                    return;
                }

                if (touchedLastFrame) {
                    
                    whiteboard.texture.SetPixels(x, y, penSize, penSize, colors);

                    for (float f = 0.01f; f < 1.00f; f += 0.01f) {

                        var lerpX = (int)Mathf.Lerp(lastTouchPos.x, x, f);
                        var lerpY = (int)Mathf.Lerp(lastTouchPos.y, y, f);
                        whiteboard.texture.SetPixels(lerpX, lerpY, penSize, penSize, colors);

                    }

                    //transform.rotation = lastTouchRot;

                    whiteboard.texture.Apply();
                }

                lastTouchPos = new Vector2(x, y);
                //lastTouchRot = transform.rotation;
                touchedLastFrame = true;
                return;
            }
        }

        whiteboard = null;
        touchedLastFrame = false;
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaterController : MonoBehaviour
{
    public Transform top, bottom, surface;
    private float objectHeight, surfaceHeight;
    private float tiltDegrees;
    private float emptyPercent, tiltThreshold;
    ParticleSystemTrigger particleSystemTrigger;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        particleSystemTrigger = gameObject.GetComponent<ParticleSystemTrigger>();
        tiltDegrees = particleSystemTrigger.getDegrees();
        emptyPercent = tiltDegrees / 90;
        objectHeight = top.localPosition.y - bottom.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        tiltDegrees = particleSystemTrigger.getDegrees();
        emptyPercent = tiltDegrees / 90;
        surfaceHeight = objectHeight - surface.localPosition.y;
        tiltThreshold  = surfaceHeight / objectHeight;
    }

    public void Fill() {
        if ((surface.localPosition.y + 0.001f) <= top.localPosition.y) {
            surface.localPosition += new Vector3(0, 0.001f, 0);
        }
    }

    public void Empty() {
        if ((surface.localPosition.y - 0.001f) >= bottom.localPosition.y
            && emptyPercent > tiltThreshold) {
            surface.localPosition -= new Vector3(0, 0.001f, 0);
        }
    }

    public bool isEmpty() {
        return (surface.localPosition.y - bottom.localPosition.y) < 0.001f;
    }
}

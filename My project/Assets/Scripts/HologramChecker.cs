using System;
using TMPro;
using UnityEngine;

public class HologramChecker : MonoBehaviour
{

    public Collider[] hologramColliders;
    public GameObject target;
    public float overlapThreshold = 0.80f;
    private Collider[] targetColliders;
    public TextMeshProUGUI ObjectText;

    void Start()
    {
        hologramColliders = GetComponentsInChildren<Collider>();

        if (hologramColliders == null)
        {
            Debug.LogError("No collider detected on " + hologramColliders);
        }
    }

    void Update()
    {
        if (target == null || hologramColliders == null) return;

        targetColliders = target.GetComponentsInChildren<Collider>();
        if (targetColliders.Length == 0) return;

        int insideCount = 0;

        // Check how many target colliders overlap with hologram colliders
        foreach (Collider targetCol in targetColliders)
        {
            foreach (Collider holoCol in hologramColliders)
            {
                if (holoCol.bounds.Intersects(targetCol.bounds)) // Check overlap
                {
                    insideCount++;
                    break; // No need to check other hologram colliders for this one
                }
            }
        }

        float overlapRatio = (float)insideCount / targetColliders.Length;

        Boolean isInside = overlapRatio >= overlapThreshold;
        if (isInside) {
            // ADD LOGIC ON WHAT TO DO WHEN OBJECT IS MOSTLY INSIDE
            //Debug.Log("Object is at least 80% inside the hologram");
        }
        ObjectText.text = target.name + " in place: " + isInside + ", Percentage: " + Mathf.Round(overlapRatio * 100) + "%";
    }
}
using System;
using TMPro;
using UnityEngine;

public class SingularColliderHologramChecker : MonoBehaviour
{
    public GameObject target;

    public float overlapThreshold = 0.99f;

    private Collider hologramCollider;
    private Collider[] targetColliders;
    public TextMeshProUGUI orangeText;

    void Start()
    {
        hologramCollider = GetComponent<Collider>();

        if (hologramCollider == null)
        {
            Debug.LogError("No collider found on the hologram! Please add a BoxCollider or similar.");
        }

        if (target != null)
        {
            targetColliders = target.GetComponentsInChildren<Collider>();
        }
    }

    void Update()
    {
        if (target == null || hologramCollider == null || targetColliders == null) return;

        int insideCount = 0;
        int totaltargetColliders = targetColliders.Length;

        foreach (Collider targetCol in targetColliders)
        {
            if (hologramCollider.bounds.Intersects(targetCol.bounds))
            {
                insideCount++;
            }
        }

        // Calculate the correct ratio (only considering the target object)
        float overlapRatio = (totaltargetColliders > 0) ? (float)insideCount / totaltargetColliders : 0;

        //Debug.Log("Object is " + (overlapRatio * 100) + "% inside the hologram");
        Boolean ratio = overlapRatio >= overlapThreshold;
        if (ratio)
        {
            //Debug.Log("Object is " + overlapRatio * 100 + "% inside the hologram");
        }
        orangeText.text = "Object in place: \n" + ratio + "\n Percentage: " + overlapRatio * 100 + "%";
    }
}
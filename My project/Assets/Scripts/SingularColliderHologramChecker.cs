using System;
using TMPro;
using UnityEngine;

public class SingularColliderHologramChecker : MonoBehaviour
{
    public GameObject fruit;

    public float overlapThreshold = 0.99f;

    private Collider hologramCollider;
    private Collider[] fruitColliders;
    public TextMeshProUGUI orangeText;

    void Start()
    {
        hologramCollider = GetComponent<Collider>();

        if (hologramCollider == null)
        {
            Debug.LogError("No collider found on the hologram! Please add a BoxCollider or similar.");
        }

        if (fruit != null)
        {
            fruitColliders = fruit.GetComponentsInChildren<Collider>();
        }
    }

    void Update()
    {
        if (fruit == null || hologramCollider == null || fruitColliders == null) return;

        int insideCount = 0;
        int totalFruitColliders = fruitColliders.Length;

        foreach (Collider fruitCol in fruitColliders)
        {
            if (hologramCollider.bounds.Intersects(fruitCol.bounds))
            {
                insideCount++;
            }
        }

        // Calculate the correct ratio (only considering the target object)
        float overlapRatio = (totalFruitColliders > 0) ? (float)insideCount / totalFruitColliders : 0;

        //Debug.Log("Object is " + (overlapRatio * 100) + "% inside the hologram");
        Boolean ratio = overlapRatio >= overlapThreshold;
        if (ratio)
        {
            //Debug.Log("Object is " + overlapRatio * 100 + "% inside the hologram");
        }
        orangeText.text = "Orange in place: \n" + ratio + "\n Percentage: " + overlapRatio * 100 + "%";
    }
}

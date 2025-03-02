using UnityEngine;
using TMPro;

public class HeightUpdater : MonoBehaviour
{
    public float offSet = 0.85f;
    public float blockHeight = 0.1f;
    private TextMeshProUGUI text;
    private GameObject[] objects;
    private float maxY, height;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
        objects = GameObject.FindGameObjectsWithTag("Stack");
    }

    // Update is called once per frame
    void Update()
    {
        maxY = float.MinValue;

        foreach (GameObject go in objects) {
            if (go.transform.position[1] > maxY) {
                maxY = go.transform.position[1];
            }
        }

        height = maxY - offSet + blockHeight;

        text.text = string.Format("Height: {0:0.00} m", height);
    }
}

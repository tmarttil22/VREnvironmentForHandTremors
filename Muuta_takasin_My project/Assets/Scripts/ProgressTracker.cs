using UnityEngine;

public class ProgressTracker : MonoBehaviour
{


    public GameObject drawTask;
    public GameObject sortTask;

    public GameObject serveTask;

    public GameObject fillDishwasher;

    public GameObject emptyDishwasher;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;
using TMPro;

public class TaskCompletionHandler : MonoBehaviour
{
    public string setText = "RENAME_THIS";
    private bool isCompleted = false;
    private TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAsCompleted () {
        isCompleted = true;
        text.text = string.Format(setText);
    }

    public bool GetIsCompleted() {
        return isCompleted;
    }
}

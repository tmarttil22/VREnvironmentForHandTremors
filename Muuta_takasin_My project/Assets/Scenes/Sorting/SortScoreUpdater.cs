using UnityEngine;
using TMPro;

public class SortScoreUpdater : MonoBehaviour
{
    public GameObject ScoreHandlerObject;
    private CheckSorting checkSorting;
    private TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkSorting = ScoreHandlerObject.GetComponent<CheckSorting>();
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = string.Format("{0}/7", checkSorting.GetCorrectCount());
    }
}

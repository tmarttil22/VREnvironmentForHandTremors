using UnityEngine;
using TMPro;
public class KitchenSinkLogic : MonoBehaviour
{
   
    public GameObject ScoreHandlerObject;
    private CheckDirtyDishes checkDirtyDishes;
    private TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkDirtyDishes = ScoreHandlerObject.GetComponent<CheckDirtyDishes>();
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
          text.text = string.Format("{0}/4", checkDirtyDishes.checkProgress());
    }
}

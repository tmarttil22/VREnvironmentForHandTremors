using UnityEngine;
using TMPro;
public class DishWasherLogic : MonoBehaviour
{
    private TaskCompletionHandler taskCompletionHandler;
    public GameObject taskCompletionObject;
    private CheckDishes checkDishes;
    private CheckDirtyDishes checkDirtyDishes;
    private TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        taskCompletionHandler = taskCompletionObject.GetComponent<TaskCompletionHandler>();
        checkDishes = taskCompletionObject.GetComponent<CheckDishes>();
        checkDirtyDishes = taskCompletionObject.GetComponent<CheckDirtyDishes>();
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = string.Format("{0}/9\n{0}/4", checkDishes.checkProgress(),checkDirtyDishes.checkProgress());
        checkCompletion();
    }


    void checkCompletion(){
        if(checkDishes.CheckCompletion() && checkDirtyDishes.CheckCompletion()){
            taskCompletionHandler.SetAsCompleted();
        }
       
        }
    
}

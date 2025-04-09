using UnityEngine;

public class SortHandler : MonoBehaviour
{
    public GameObject correctObject;

    private bool isCorrect = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetIsCorrect() {
        return isCorrect;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == correctObject)
        {
            isCorrect = true;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (!isCorrect) {
            if (collision.gameObject == correctObject)
            {
                isCorrect = true;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        isCorrect = false;
    }
}

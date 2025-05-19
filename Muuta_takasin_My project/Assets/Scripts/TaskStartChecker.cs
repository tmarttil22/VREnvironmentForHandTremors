using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class TaskStartChecker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    Vector3 startPosition;
    public bool objectHasMoved;
    
    bool startPosAcquired;
    bool continuousCoroutineStarted = false;

    float startDelay = 3f; // set delay after which the gameobject start positions are saved
    float checkInterval = 1f; //interval for checking movement 
    void Start()
    {
        StartCoroutine(getStartPosition());//get start position of the object
        objectHasMoved = false;
        startPosAcquired = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startPosAcquired&&!continuousCoroutineStarted){
            StartCoroutine(movementCheck());
            continuousCoroutineStarted = true;  
        }
    }


    public bool isMoved(){//checks if object has moved from its original position
        if(startPosition!=transform.position){
            return true;
        }
        return false;
    }

    IEnumerator movementCheck(){
        while(!objectHasMoved){
        if(isMoved()){
            objectHasMoved = true;
        }
        yield return new WaitForSeconds(checkInterval); //wait for defined time
        }
        yield break; //break coroutine when movement detected
    }

    IEnumerator getStartPosition(){
        yield return new WaitForSeconds(startDelay);
        startPosition = transform.position;
        startPosAcquired = true;
        yield break;//break coroutine when position collected 
    }
}

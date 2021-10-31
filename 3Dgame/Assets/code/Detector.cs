using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    // Start is called before the first frame update
    public Root3 myRoot;

    void Start()
    {
        myRoot = gameObject.GetComponentInParent<Root3>();
    }
    public void OnTriggerEnter(Collider other){
        if(other.tag == "enemy"){
            myRoot.detected.Add(other.GetComponent<Root3>());
        }
    }

    public void OnTriggerExit(Collider other){
        //myRoot.detected.Remove(other.GetComponent<Root3>();
    }
    // Update is called once per frame
    void Update()
    {
        //f(myRoot.enemies.Count >0){
        //    myRoot.enemies.Clear();
        //}
        //foreach (Root3 detectedObject in myRoot.detected){
        //    if (detectedObject == null){
        //        myRoot.enemies.Remove(detectedObject);
        //    }
        //    if (detectedObject.tag == "enemy"){
        //        myRoot.enemies.Add(detectedObject)
        //    }
        //}
        //going battle
        //if(myRoot.currentState != Root3.STATE.Moving){
        //    if(myRoot.enemies.Count > 0){
         //       myRoot.ChangeState(Root3.STATE.Combat);
        //    }
        //    else{
         //       if(myRoot.currentState == Root3.STATE.Combat){
         //           myRoot.ChangeState(Root3.STATE.Idle);
         //       }
         //   }
        //}
    }
}

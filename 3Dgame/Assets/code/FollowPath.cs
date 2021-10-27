using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{   
    public GameObject wpManager;
    GameObject[] wps;
    UnityEngine.AI.NavMeshAgent agent;
    
    void Start()
    {
        wps = wpManager.GetComponent<WPManager>().waypoints;
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    
    public void GoToHeil(){
        agent.SetDestination(wps[4].transform.position);
    }
    public void GoToRuin(){
        agent.SetDestination(wps[0].transform.position);
    }

    public 
    // Update is called once per frame
    void LateUpdate()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public Root3 myRoot, targetRoot;
    public List<Root3> enimies;
    public bool atkReady;
    public NavMeshAgent myAgent;
    public float rotateSpeedWhenAtk;
    float velocityRoto;

    void Start()
    {
        Transform _startpos = gameObject.GetComponent<Transform>();
        myAgent = GetComponent<NavMeshAgent>();
        Invoke("ReadAction",myRoot.atkSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        enimies.Clear();
        foreach(Root3 detectedObject in myRoot.detected){
            if (detectedObject != null){
                if(detectedObject.tag == "enemy") enimies.Add(detectedObject);
            }
        }
        if(enimies.Count > 0){
            targetRoot = enimies[0];
            foreach(var enemy in enimies){
                float dist1 = Vector3.Distance(transform.position, targetRoot.transform.position);
                float dist2 = Vector3.Distance(transform.position, enemy.transform.position);
                if(dist1>dist2) targetRoot = enemy;
            }
            if(myRoot.currentState != Root3.STATE.Moving){
                myRoot.ChangeState(Root3.STATE.Combat);
                if(Vector3.Distance(transform.position, targetRoot.transform.position) > myRoot.reach){
                    myAgent.SetDestination(targetRoot.transform.position);
                    myAgent.isStopped = false;
                }
                else{
                    myAgent.isStopped = true;
                    Quaternion rotationToLookAt = Quaternion.LookRotation(targetRoot.transform.position - transform.position);
                    float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref velocityRoto, rotateSpeedWhenAtk* Time.deltaTime);
                    transform.eulerAngles = new Vector3(0,rotationY, 0);
                    if(atkReady){
                        atkReady = false;
                        Invoke("ReadyAction", myRoot.atkSpeed);
                        //shoot code
                        myRoot.shoot(targetRoot.transform);
                        int dmg = myRoot.atk + Random.Range(-myRoot.atkVar, myRoot.atkVar + 1);
                        targetRoot.DamageTaken(dmg);
                    }
                }
            }
        }
        else if(myRoot.currentState == Root3.STATE.Combat){
            myRoot.ChangeState(Root3.STATE.Idle);
        }
        
    }
    void ReadyAction(){
        atkReady = true;

    }
}

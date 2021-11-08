using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Root3 : MonoBehaviour
{
    public enum STATE {Idle, Moving, Combat, Following};
    public enum target {enemy, ai};
    [Header("State")]
    public STATE currentState;
    public TextMesh myStateText;
    [Header("Stats")]
    public target target1;
    public int hp = 50;
    public int def = 5;
    public int atk = 10;
    public int atkVar = 2;
    public float atkSpeed = 2.5f;
    public float reach = 20;
    public int attack_radius = 10;

    [Header("Detection")]
    public List<Root3> detected;

    [Header("Other")]
    //public GameObject gun;
    public Transform Fire_pos;
    public float bullet_force = 50f;
    public GameObject Bulletprefab; 
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void status(){
        if(this.tag == "ai"){
            if((agent.destination.x - agent.nextPosition.x)<1f && (agent.destination.z - agent.nextPosition.z) <1f){
            currentState = STATE.Idle;
            }
            else{
                currentState = STATE.Moving;
                agent.isStopped = false;
            }
        }
    }
    public void DamageTaken(int damage){
        if((damage-def)>=0){
            hp = hp - (damage - def);
        }
        if(hp<=0){
            Destroy(gameObject);
        }
    }
    public void ChangeState(STATE state){
        currentState = state;
        if(myStateText != null) myStateText.text = state.ToString();
    }
    public void shoot(Transform enemy_pos){
        GameObject newbullet = Instantiate(Bulletprefab, Fire_pos.position, Quaternion.identity);
        newbullet.GetComponent<Transform>().LookAt(enemy_pos);
		newbullet.GetComponent<Rigidbody>().AddForce((enemy_pos.position - Fire_pos.position)*bullet_force);
		//AudioSource.PlayClipAtPoint(audioClip, transform.position);
    }
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        status();
    }
    void OnTriggerEnter(Collider other){
        if (target1 == target.enemy){
            if(other.tag == "enemy"){
            detected.Add(other.GetComponent<Root3>());
            print("add");
            }
        }
        else{
            if(other.tag == "ai"){
            detected.Add(other.GetComponent<Root3>());
            print("add");
            }
        }
    }
    void OnTriggerExit(Collider other){
            detected.Remove(other.GetComponent<Root3>());
    }
}
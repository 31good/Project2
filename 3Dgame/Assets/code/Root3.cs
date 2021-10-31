using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Root3 : MonoBehaviour
{
    public enum STATE {Idle, Moving, Combat, Following};
    [Header("State")]
    public STATE currentState;
    public TextMesh myStateText;
    [Header("Stats")]
    public int hp = 50;
    public int def = 5;
    public int atk = 10;
    public int atkVar = 2;
    public float atkSpeed = 2.5f;
    public float reach = 3;
    public int attack_radius = 10;

    [Header("Detection")]
    public List<Root3> detected;

    [Header("Other")]
    public GameObject gun;
    public Transform Fire_pos;
    public float bullet_force = 50f;
    public Transform attack_speed;
    public GameObject Bulletprefab; 
    // Start is called before the first frame update
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
    public void OnTriggerEnter(Collider other){
        if(other.tag == "enemy"){
            detected.Add(other.GetComponent<Root3>());
        }
    }
    public void OnTriggerExit(Collider other){
            detected.Remove(other.GetComponent<Root3>());
    }
    public void shoot(Transform enemy_pos){
        GameObject newbullet = Instantiate(Bulletprefab, Fire_pos.position, Quaternion.identity);
		newbullet.GetComponent<Rigidbody>().AddForce((enemy_pos.position - Fire_pos.position)*bullet_force);
		//AudioSource.PlayClipAtPoint(audioClip, transform.position);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
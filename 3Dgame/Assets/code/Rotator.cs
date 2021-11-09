using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    public string way;
    // Update is called once per frame
    public float distance = 2.5f;
    public GameObject player;
    void Update()
    {
        if (way == "x") { transform.Rotate(new Vector3(45, 0, 0) * Time.deltaTime); }
        if (way == "z") { transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime); }
        if (way == "y") { transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime); }
        float dist1 = Vector3.Distance(transform.position, player.transform.position);
        print(dist1);
        if (dist1 <= distance)
        {
            gameObject.SetActive(false);
        }
    }


}

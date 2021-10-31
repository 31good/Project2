using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //camera move speed
    public float panSpeed = 20f;
    //camera detect boarder
    public float BoarderThick=10f;
    //camera limit
    public Vector2 panLimit;
    //zoom speed
    public float scrollSpeed=20f;
    //zoom limit
    public float minY=20f;
    public float maxY=20f;
    // Update is called once per frame
    void Update()
    {
        //camera move detection
        Vector3 position=transform.position;
        if(Input.GetKey("w")||Input.mousePosition.y>=Screen.height-BoarderThick){
            position.z+=panSpeed*Time.deltaTime;
        }
        if(Input.GetKey("s")||Input.mousePosition.y<=BoarderThick){
            position.z-=panSpeed*Time.deltaTime;
        }
        if(Input.GetKey("d")||Input.mousePosition.x>=Screen.width-BoarderThick){
            position.x+=panSpeed*Time.deltaTime;
        }
        if(Input.GetKey("a")||Input.mousePosition.x<=BoarderThick){
            position.x-=panSpeed*Time.deltaTime;
        }
        //camera zoom detection
        float scroll=Input.GetAxis("Mouse ScrollWheel");
        position.y-=scroll*scrollSpeed*100f*Time.deltaTime;
        //limit
        position.x=Mathf.Clamp(position.x,-panLimit.x,panLimit.x);
        position.y=Mathf.Clamp(position.y,minY,maxY);
        position.z=Mathf.Clamp(position.z,-panLimit.y,panLimit.y);
        transform.position=position;

    }
}

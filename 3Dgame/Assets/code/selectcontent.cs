using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectcontent : MonoBehaviour
{
    public List<GameObject> _Charactors;
    private bool _IsDrawRectangle = false;
    private Vector3 _MouseStart = Vector3.zero;

    void start(){

    }

    void Update(){
        if (Input.GetMouseButtonDown(0)){
            _IsDrawRectangle = true;
            _MouseStart = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0)){
            _IsDrawRectangle = false;
        }
        if(Input.GetMouseButton(0)){
            
        }
    }
}

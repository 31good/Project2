using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureRecognition_ZH : MonoBehaviour
{
    public Vector2 _MousePos;
    public GestureState _GestureStateBe;
    private float _MinGestureDistance = 20.0f;
    private bool _IsInvaild;
    public static GestureRecognition_ZH _GestureRecognition;

    void Update()
    {
        GestureOnClick();
        _GestureRecognition = this;
    }

    public void GestureOnClick()
    {

        _GestureStateBe = GestureState.Null;

        if (Input.GetMouseButtonDown(0))
        {

            _MousePos = Input.mousePosition;
  
            _IsInvaild = true;

        }
        if (Input.GetMouseButton(0))
        {
            Vector2 _Dis = (Vector2)Input.mousePosition - _MousePos;
            Debug.DrawLine(_MousePos, (Vector2)Input.mousePosition, Color.cyan);

            if (_Dis.magnitude > _MinGestureDistance)
            {
    
                if (Mathf.Abs(_Dis.x) > Mathf.Abs(_Dis.y) && _IsInvaild)
                {
                    if (_Dis.x > 0)
                    {
                        
                        _GestureStateBe = GestureState.Right;
                    }
                    else if (_Dis.x < 0)
                    {
                        _GestureStateBe = GestureState.Lift;
                    }
                }
                else if (Mathf.Abs(_Dis.x) < Mathf.Abs(_Dis.y) && _IsInvaild)
                {
                    if (_Dis.y > 0)
                    {

                        _GestureStateBe = GestureState.Up;
                    }
                    else if (_Dis.y < 0)
                    {
                        _GestureStateBe = GestureState.Down;
                    }
                }

                CallEvent();
                _IsInvaild = false;
            }
        }
    }

    //呼叫事件
    public void CallEvent()
    {
        switch (_GestureStateBe)
        {
            case GestureState.Null:

                print("Null");

                break;

            case GestureState.Up:

                print("Up");


                break;

            case GestureState.Down:

                print("Down");

                break;

            case GestureState.Lift:

                print("Lift");

                break;

            case GestureState.Right:

                print("Right");

                break;

            default:
                break;
        }
    }
    public enum GestureState
    {
        Null,
        Up,
        Down,
        Lift,
        Right
    }
}

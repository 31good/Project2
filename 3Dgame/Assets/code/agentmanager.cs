using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agentmanager : MonoBehaviour
{
    RaycastHit hit;
    int layer;
    List<UnitController> selected = new List<UnitController>();
    bool isDragging = false;
    Vector3 mousePosition;
    //GameObject [] agents;
    // Start is called before the first frame update
    private void OnGUI()
    {
        if (isDragging)
        {
            var rect = ScreenHelper.GetScreenRect(mousePosition, Input.mousePosition);
            ScreenHelper.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.1f));
            ScreenHelper.DrawScreenRectBorder(rect, 1, Color.green);
        }
    }

    /*
    void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("ai");
    }
    */
    // Update is called once per frame
    void Update()
    {
        //print(isDragging);
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            mousePosition = Input.mousePosition;
            DeselectUnit();
            /*if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.transform.CompareTag("ai"))
                {
                    SelectUnit(hit.transform.GetComponent<UnitController>(), Input.GetKey(KeyCode.LeftShift));
                    //print("true");
                }
                else
                {
                    isDragging = true;
                    //DeselectUnit();
                }
                /*foreach(GameObject a in agents){
                    a.GetComponent<AIControl>().agent.SetDestination(hit.point);
                }
            }*/
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging)
            {
                foreach (var ai in GameObject.FindGameObjectsWithTag("ai"))
                {
                    if (IsWithinSelect(ai.transform))
                    {
                        SelectUnit(ai.gameObject.GetComponent<UnitController>(), true);
                    }
                }
                isDragging = false;
            }
            //isDragging = false;
        }

        if (Input.GetMouseButtonDown(1) && selected.Count > 0)
        {
            int layer = 1 << 10;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, layer))
            {
                //if (hit.transform.CompareTag("ground"))
                //{
                foreach (var ai in selected)
                {
                    ai.MoveUnit(hit.point);
                }
                //}
            }
        }
    }

    private void SelectUnit(UnitController unit, bool isMultiSelect = false)
    {
        if (!isMultiSelect) { DeselectUnit(); }
        selected.Add(unit);
        //print("true"+(selected.Count));
        unit.SetSelected(true);
    }

    private void DeselectUnit()
    {
        for (int i = 0; i < selected.Count; i++)
        {
            selected[i].SetSelected(false);
        }
        selected.Clear();
    }

    private bool IsWithinSelect(Transform transform)
    {
        if (!isDragging) { return false; }
        var camera = Camera.main;
        var Bounds = ScreenHelper.GetViewportBounds(camera, mousePosition, Input.mousePosition);
        return Bounds.Contains(camera.WorldToViewportPoint(transform.position));
    }
}

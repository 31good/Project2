using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class UnitController : MonoBehaviour
{
    private NavMeshAgent navAgent;
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }
    public void MoveUnit(Vector3 dest)
    {
        navAgent.destination = dest;
    }

    public void SetSelected(bool isSelected)
    {
        //TODO: 被选中底下有光
        //transform.Find("highligh").gameObject.SetActive(isSelected);
    }
}

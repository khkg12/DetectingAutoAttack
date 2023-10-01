using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{    
    private NavMeshAgent agent;
    [SerializeField] private Transform targetTrans;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();   
    }
 
    void Update()
    {
        agent.SetDestination(targetTrans.position);
    }
}

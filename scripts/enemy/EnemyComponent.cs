using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyComponent : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public float lookdist = 10f;
    void Start()
    {
        
    }

    
    void Update()
    {
        float dist = Vector3.Distance(target.position, transform.position);
        if(dist <= lookdist)
        {
            agent.SetDestination(target.position);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookdist);

    }

}

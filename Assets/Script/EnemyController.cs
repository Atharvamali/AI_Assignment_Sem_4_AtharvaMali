using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    
    public float stopRadius = 3f;
    Transform target;
    NavMeshAgent agent;
    EnemyNavmesh navmesh;

    Animator Animator;
    
     void Start()
     {
        target = PlayerManager.instance.Player.transform;
        agent = GetComponent<NavMeshAgent>();
        navmesh = GetComponent<EnemyNavmesh>();
        Animator = GetComponent<Animator>();
     }

     void Update()
     {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= navmesh.lookRadius)
        {
            Animator.SetBool("Move", true);
        }
        if (distance <= stopRadius)
        {
            navmesh.enabled = false;
            
            Animator.SetBool("Attack", true);
        }
        else
        {
            navmesh.enabled = true;
            Animator.SetBool("Attack", false);
        }
        
        

    }
  
    private void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, stopRadius);
    }
}
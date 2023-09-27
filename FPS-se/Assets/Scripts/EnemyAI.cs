using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target; //bedzie potrzebna aktualna pozycja Gracza wiec z transform i nazywamy zmienną na razie target
    [SerializeField] float chaseRange = 5f; // bede porównywać zasięg enemy do odległości targetu od enemy
    
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity; // Jeżeli byłoby tylko float distanceToTarget; to enemy myślałby że target jest przy nim dosłownie w nim i to by później tworzylo bugi
    void Start()
    {
       navMeshAgent = GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position); //przez każdą klatke będzie mierzony dystans do gracza
        
        if(distanceToTarget <= chaseRange)
        {
            navMeshAgent.SetDestination(target.position);
        }
    }
}

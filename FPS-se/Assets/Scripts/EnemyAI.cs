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
    
    bool isProvoked = false; 


    void Start()
    {
       navMeshAgent = GetComponent<NavMeshAgent>(); 
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position); //przez każdą klatke będzie mierzony dystans do gracza
        
        if(isProvoked) // Jest albo sprowokowany strzałem
        {
            EngageTarget();
        }
        else if(distanceToTarget <= chaseRange) //Albo za bliskim podejściem gracza
        { 
            isProvoked = true;
        }

    }

    private void EngageTarget() //Sprowokowany strzałem
    {
        if(distanceToTarget >= navMeshAgent.stoppingDistance) //Jeżeli gracz jest daleko to zacznij gonić gracza
        {
            ChaseTarget();
        }

        if(distanceToTarget <= navMeshAgent.stoppingDistance) //Jeżeli gracz jest dostatecznie blisko zacznij atakować
        {
            AttackTarget();
        }

    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        Debug.Log(name + " IS ATTACKING " + target.name + "  >:()");
    }

    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange); //drawSphere potrzebuje(gdzie się znajduje srodek, jaki jest promień)
    }



}

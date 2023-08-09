using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    EnemyHealth health;
    GameObject player;

    [Header("Chase Player Elements")]
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    float turnSpeed = 5f;
    
    [Header("Audio Elements")]
    [SerializeField] AudioSource enemyCrawlSFX;

    [Header("Random Patrol Elements")]
    [SerializeField] private float searchRange;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        else if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
        else
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (RandomPoint(target.position, searchRange, out Vector3 point))
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                    ChaseTarget(point);
                }
            }
        }

    }

    public void OnDamageTaken()
    {
        isProvoked = true;
        
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget(target.position);
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget(Vector3 endpoint)
    {
        GetComponent<Animator>().SetTrigger("Walk Forward");
        navMeshAgent.SetDestination(endpoint);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Walk Forward", false);
        GetComponent<Animator>().SetTrigger("Stab Attack");
        //Debug.Log(name + " has seeked and is destroying" + target.name);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}

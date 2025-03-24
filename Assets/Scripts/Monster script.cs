using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RandomMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public float range;

    public Transform centrePoint;

    Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("Walk", true);
        //if it's at the point
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            StartCoroutine(PatrolDelay());
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            anim.SetBool("Walk", false);
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    IEnumerator PatrolDelay()
    {
        anim.SetBool("Walk", false);
        yield return new WaitForSeconds(Random.Range(5f, 15f));
        
        Vector3 point;
        if (RandomPoint(centrePoint.position, range, out point))
        {
            Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
            agent.SetDestination(point);
        }
    }
}

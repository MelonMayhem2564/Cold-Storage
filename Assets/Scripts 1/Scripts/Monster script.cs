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

    bool reachedPoint;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();


        StartCoroutine(PatrolDelay());
        anim.SetBool("Walk", true);
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }

    IEnumerator PatrolDelay()
    {
        while (true)
        {

            //if it's at the point
            if (agent.remainingDistance > agent.stoppingDistance )
            {
                
                
                //yield return null;
            }

            //nav agent has reached destination point

            

            Vector3 point;

            for (int i = 0; i < 10000; i++)
            {
                if (RandomPoint(centrePoint.position, range, out point))
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 3.0f);
                    agent.SetDestination(point);
                    print("moving to random point " + point + "  after " + i + "  attempts");
                    anim.SetBool("Walk", true);

                    // found a valid point
                    while (true )
                    {
                        print("remaining=" + agent.remainingDistance);
                        if( agent.remainingDistance <= agent.stoppingDistance )
                        {
                            anim.SetBool("Walk", false);
                            yield return new WaitForSeconds(5.5f);
                            //reached point
                            break;
                        }
                        else
                        {
                            anim.SetBool("Walk", true);
                            yield return null;
                        }

                    }


                   break;
                }
            }
            yield return null;

        }

    }
}

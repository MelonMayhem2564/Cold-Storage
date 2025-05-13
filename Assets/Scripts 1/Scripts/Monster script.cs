using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RandomMovement : MonoBehaviour
{

    enum EnemyStates
    {
        Idle,
        Walk,
        Wait,
        Run
    }


    public NavMeshAgent agent;
    public float range;

    float waitDelay;

    public Transform centrePoint;
    public Transform player;


    Vector3 point; //random point on navmesh

    public GameObject endPoint; //debug sphere


    Animator anim;
    EnemyFOV fovScript;

    EnemyStates enemyState;

    bool reachedPoint;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();


        //StartCoroutine(PatrolDelay());
        anim.SetBool("Walk", true);
        anim.SetBool("Run", false);

        fovScript = GetComponent<EnemyFOV>();

        player = GameObject.Find("Player").transform;

        enemyState = EnemyStates.Idle;
        waitDelay = 0;

    }

    void Update()
    {
        if (enemyState == EnemyStates.Idle)
        {
            Idle();
        }
        if (enemyState == EnemyStates.Walk)
        {
            Walk();
        }

        if (enemyState == EnemyStates.Wait)
        {
            Wait();
        }


        if (enemyState == EnemyStates.Run)
        {
            Run();
        }

    }

    void Idle()
    { 
        //search for a valid point on navmesh

        if (RandomPoint(centrePoint.position, range, out point))
        {
            //found a valid point
            agent.SetDestination(point);
            endPoint.transform.position = point;

            print("moving to random point " + point);
            anim.SetBool("Walk", true);
            enemyState = EnemyStates.Walk;
        }
        else
        {
            print("*** COULD NOT FIND A RANDOM POINT ***");
        }
    }


    void Walk()
    {

        //check enemy has reached dest

        print("remaining=" + agent.remainingDistance);
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            anim.SetBool("Walk", false);
            waitDelay = 5;
            enemyState = EnemyStates.Wait;
        }
    }

    void Run()
    {

    }

    void Wait()
    {
        waitDelay -= Time.deltaTime;
        if( waitDelay <= 0)
        {
            enemyState = EnemyStates.Idle;
        }
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
        bool isMovingToPoint=false;
        while (true)
        {
            if (isMovingToPoint)
            {
                //check for enemy reaching a point

                print("remaining=" + agent.remainingDistance);
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    isMovingToPoint = false;
                    anim.SetBool("Walk", false);
                    yield return new WaitForSeconds(5.5f);


                    //reached point
                    break;
                }
                yield return null;
            }


            if (fovScript != null && fovScript.playerVisible == true)
            {
                //do run specific code

                //agent.SetDestination(player.position);
                //anim.SetBool("Run", true);

                //yield return null;

            }


            for (int i = 0; i < 10000; i++)
            {
                if (RandomPoint(centrePoint.position, range, out point))
                {
                    agent.SetDestination(point);
                    endPoint.transform.position = point;

                    if (agent.isOnNavMesh == true)
                    {

                        // found a valid point

                        Debug.DrawRay(point, Vector3.up, Color.blue, 3.0f);
                        //agent.SetDestination(point);
                        print("moving to random point " + point + "  after " + i + "  attempts");
                        anim.SetBool("Walk", true);
                        isMovingToPoint = true;
                        yield return null;
                    }



/*

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
                        }

                    }
*/


                   break;
                }
            }
            yield return null;

        }

    }
}

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
    public GameObject Player;

    [SerializeField]
    private Scenecontroller sceneController;

    Animator anim;
    EnemyFOV fovScript;

    EnemyStates enemyState;

    bool reachedPoint;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        Player = GameObject.Find("Player");

        //StartCoroutine(PatrolDelay());

        fovScript = GetComponent<EnemyFOV>();

        player = GameObject.Find("Player").transform;

        enemyState = EnemyStates.Idle;
        waitDelay = 0;

    }

    void Update()
    {

        print("state=" + enemyState);

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

            print("moving to random point ");
            anim.SetBool("Walk", true);
            enemyState = EnemyStates.Walk;
        }
        else
        {
            print("*** COULD NOT FIND A RANDOM POINT ***");
            anim.SetBool("Walk", false);
        }

        if (fovScript.playerVisible == true)
        {
            enemyState = EnemyStates.Run;
        }
    }


    void Walk()
    {

        //check enemy has reached dest

        //print("remaining=" + agent.remainingDistance);
        if (agent.pathPending == false )
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                anim.SetBool("Walk", false);
                waitDelay = 2;
                enemyState = EnemyStates.Wait;
                print("reached point");
            }
        }

        if (fovScript.playerVisible == true)
        {
            enemyState = EnemyStates.Run;
        }
    }

    void Run()
    {
        agent.speed = 5;
        agent.SetDestination (player.position);
        anim.SetBool("Run", true);

        if (fovScript.playerVisible == false)
        {
            anim.SetBool("Run", false);
            enemyState = EnemyStates.Idle;
        }
    }

    void Wait()
    {
        waitDelay -= Time.deltaTime;
        if( waitDelay <= 0)
        {
            enemyState = EnemyStates.Idle;
        }

        if (fovScript.playerVisible == true)
        {
            enemyState = EnemyStates.Run;
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

}

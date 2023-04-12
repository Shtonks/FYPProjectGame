using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Roaming,
        ChaseTarget
    }


    public float nextWaypointDist = 3f;     // Determines how tightly the AI must stick to its path
    public float roamingTargetDist = 3f;    // Determines closeness needed to final waypoint
    public float playerTargetRange = 10f;   // Enemy detection range
    public float playerLocTolerance = 2f;   // Determines size of dist between old player pos and current allowed before updating path to player
    public float speed = 200f;
    public float minRoamDist = 10f;
    public float maxRoamDist = 20f;

    public float rotationSpeed;

    public Transform player;
    private Vector2 target;

    private Path path;
    private int currentWaypoint = 0;
    private State state;
    private Vector2 startPos;

    EnemyShipController shipController;
    Seeker seeker;
    Rigidbody2D rb;

    private void Awake()
    {
        state = State.Roaming;
        target = GetRoamingPos();
        startPos = transform.position;
    }

    private void Start()
    {
        shipController = GetComponent<EnemyShipController>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        UpdatePathToRoam();
    }

    void UpdatePathToPlayer()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, player.position, OnPathComplete);
    }

    void UpdatePathToRoam()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            default:
            case State.Roaming:
                //Debug.Log("Inside roam state");
                MoveTo();
                // When we reach this dist, calc new roamPos
                if (Vector2.Distance(transform.position, target) < roamingTargetDist)
                {
                    //Debug.Log("Target: " + target);
                    target = GetRoamingPos();
                    UpdatePathToRoam();
                }

                FindTarget();
                break;
            case State.ChaseTarget:
                MoveTo();
                // When the player pos is too far from there last recoirded location, redo the path
                if (Vector2.Distance(player.position, target) > playerLocTolerance)
                {
                    target = player.position;
                    UpdatePathToRoam();
                }
                TargetOutOfRange();
                break;
        }
    }

    private void MoveTo()
    {
        if (path == null)
        {
            //Debug.Log("NULL PATH");
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            //Debug.Log("NO MORE WAYPOINTS");
            target = GetRoamingPos();
            UpdatePathToRoam();
            return;
        }

        //Debug.Log("current weaypint" + currentWaypoint);

        Vector2 dir = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = dir * speed * Time.deltaTime;

        rb.AddForce(force);
        //RotateInDirectionOfInput(dir);

        float dist = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (dist < nextWaypointDist)
            currentWaypoint++;
    }

    // private void RotateInDirectionOfInput(Vector2 movementInput) {
    //     Quaternion targetRot = Quaternion.LookRotation(transform.forward, movementInput);
    //     Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);

    //     rb.MoveRotation(rotation);
    // }

    private Vector3 GetRoamingPos()
    {
        return startPos + GetRandomDir() * Random.Range(minRoamDist, maxRoamDist);
    }

    // Generate random normalized direction
    private static Vector2 GetRandomDir()
    {
        return new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    private void FindTarget()
    {
        if (Vector2.Distance(rb.position, player.position) < playerTargetRange)
        {
            state = State.ChaseTarget;
        }
    }

    private void TargetOutOfRange()
    {
        if (Vector2.Distance(rb.position, player.position) > playerTargetRange)
        {
            state = State.Roaming;
        }
    }
}

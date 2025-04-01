using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NpcRun : MonoBehaviour
{
    [SerializeField] Transform target;
    private NavMeshAgent agent;
    private bool isPlayerClose = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckIfClose();   
    }
    void Update()
    {
        Vector3 distanceToPlayer = target.position - transform.position;
        Vector3 oppositeDirection = transform.position - distanceToPlayer;

        if (!isPlayerClose)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            agent.SetDestination(oppositeDirection);
        }
    }

    public void CheckIfClose()
    {
        isPlayerClose = !isPlayerClose;

    }
}

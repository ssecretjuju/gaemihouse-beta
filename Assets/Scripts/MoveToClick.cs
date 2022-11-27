using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToClick : MonoBehaviour
{
    private Camera camera;

    private bool isMove;
    private Vector3 destination;

    NavMeshAgent agent;

    private void Awake()
    {
        camera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                agent.SetDestination(hit.point);
            }
        }

        Move();
    }

    private void SetDestination(Vector3 dest)
    {
        destination = dest;
        isMove = true;
    }

    private void Move()
    {
        if (isMove)
        {
            if (Vector3.Distance(destination, transform.position) <= 0.1f)
            {
                isMove = false;
                return;
            }

            var dir = destination - transform.position;
            transform.position += dir.normalized * Time.deltaTime * 5f;
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Units : MonoBehaviour
{
    private GameObject Soilder;
    public Vector3 GoPosition;
    private NavMeshAgent agent;
    private NavMeshPath path;
    public Vector3 CurrentVelocity;

    public GameObject Target;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.Log("No nav MeshAgent");
        }
    }

    public void SetPosition(Vector3 newPosition)
    {
        GoPosition = newPosition;
        agent.SetDestination(GoPosition);
        Target.transform.position = GoPosition;
        // Debug.Log("Hey2");
    }



    void Update()
    {
        if (GoPosition != null)
        {
            //Debug.Log("Hey1");
            CurrentVelocity = GetComponent<Rigidbody>().linearVelocity;
            
        }



    }






    }
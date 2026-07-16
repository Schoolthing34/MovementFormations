using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcAi : MonoBehaviour
{

    private NavMeshAgent agent;
    [SerializeField]
    private GameObject Target;


    // Start is called before the first frame update
    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
        if(agent == null )
        {
            Debug.Log("No nav MeshAgent");
        }
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Target.transform.position);
    }
}

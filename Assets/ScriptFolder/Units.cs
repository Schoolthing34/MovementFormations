using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Units : MonoBehaviour
{
   // private GameObject Soilder;
    public Vector3 GoPosition;
    private NavMeshAgent agent;
    public int speed;
    public GameObject MovingUnitVisual;
   // private NavMeshPath path;
   // public Vector3 CurrentVelocity;

    public GameObject Target;
    void Start()
    {
       
    }
    public void SetCurrentPosition(Vector3 NewPosition)
    {
        this.transform.position = NewPosition;
    }
    public void SetMovementPosition(Vector3 newPosition)
    {
        //Debug.Log("So we got in here"+newPosition);
        GoPosition = newPosition;
       // Debug.Log("So we got in here1");
        
       // Debug.Log("So we got in here2");
        Target.transform.position = GoPosition;
        
       // agent.SetDestination(GoPosition);
      //  agent.CalculatePath(Target.transform.position, agent.path);
        // Debug.Log("So we got in here3");
        // Debug.Log("Hey2");
    }



    void Update()
    {
        if (GoPosition != null)
        {
            //i dont know why this works but it seems i cant move the capsues somthign is stopping them from moving 
            this.transform.position = Vector3.MoveTowards(transform.position, GoPosition, speed * Time.deltaTime);
           // Debug.Log("wE SHOULD BE MOVING");

        }



    }






    }
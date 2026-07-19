using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Units : MonoBehaviour
{
   // private GameObject Soilder;
    public Vector3 GoPosition;
    private NavMeshAgent agent;
    public int speed;
   // private NavMeshPath path;
   // public Vector3 CurrentVelocity;

    public GameObject Target;
    void Start()
    {
       
    }

    public void SetPosition(Vector3 newPosition)
    {
        //Debug.Log("So we got in here"+newPosition);
        GoPosition = newPosition;
       // Debug.Log("So we got in here1");
        
       // Debug.Log("So we got in here2");
        Target.transform.position = GoPosition;
        Debug.Log(agent);
       // agent.SetDestination(GoPosition);
      //  agent.CalculatePath(Target.transform.position, agent.path);
        // Debug.Log("So we got in here3");
        // Debug.Log("Hey2");
    }



    void Update()
    {
        if (GoPosition != null)
        {
            //Debug.Log("Hey1");
            // CurrentVelocity = GetComponent<Rigidbody>().linearVelocity;
            // Calculate direction to the target
                Vector3 direction = (GoPosition - transform.position).normalized;

                // Move the enemy towards the target
                transform.position += direction * speed * Time.deltaTime;

               
                if (direction != Vector3.zero)
                {
                    Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direction);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 100f);
               }
            

        }



    }






    }
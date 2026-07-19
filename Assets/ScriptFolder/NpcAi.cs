using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitFormationAndMovementScript : MonoBehaviour
{

    private NavMeshAgent agent;
    [SerializeField]
    private GameObject Target;
    NavMeshPath path;
    public Units[] units;
    public int UnitAmount;
    public float Spacing;
    public float UnitSize;
    private float middle;

    // Start is called before the first frame update
    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
        if(agent == null )
        {
            Debug.Log("No nav MeshAgent");
        }

        UnitAmount = units.Length;
        if(UnitAmount%2==0)
        {
            middle = (float)(( UnitAmount / 2) + 0.5);
            middle -= 1;
            Debug.Log(middle);
        }
        else
        {
            middle=UnitAmount/2;
            Debug.Log(middle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Target.transform.position);
        agent.CalculatePath(Target.transform.position,agent.path);
       path= agent.path;
        //Debug.Log(path.corners[0]);
        
        for(int i=0;i<units.Length;i++)
        {
            if(i<middle)
            {
               
                float XPosOffset = (middle - i) * UnitSize;
                Vector3 NewPosition = path.corners[0]-new Vector3(XPosOffset,0,0);
                Debug.Log(NewPosition);
                units[i].SetPosition(NewPosition);
            }
            else if(i==middle)
            {

                Vector3 NewPosition = path.corners[0];

                units[i].SetPosition(NewPosition);
            }
            else if(i>middle)
            {

                float XPosOffset = (i-middle ) * UnitSize;
                Vector3 NewPosition = path.corners[0] + new Vector3(XPosOffset, 0, 0);

                units[i].SetPosition(NewPosition);


            }

           
        }
    }
}

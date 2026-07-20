using System;
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
    public GameObject UnitModle;

    // Start is called before the first frame update
    void Start()
    {
        if (UnitAmount <= 0)
        {
            Debug.LogError("Units must be at least one guy");
        }
        if(UnitModle==null)
        {
            Debug.LogError(" You need to have a moddle");
        }
           
        agent= GetComponent<NavMeshAgent>();
        if(agent == null )
        {
            Debug.LogError("No nav MeshAgent");
        }
        units=new Units[UnitAmount];

        SpawnUnits();

       
        if(UnitAmount%2==0)
        {
            middle = (float)(( UnitAmount / 2) + 0.5);
            middle -= 1;
           // Debug.Log(middle);
        }
        else
        {
            middle=UnitAmount/2;
           // Debug.Log(middle);
        }

    }

    private void SpawnUnits()
    {


        for (int i = 0; i < units.Length; i++)
        {
            ///we need to spawn people based on position
            ///the width is more important than legnth if width is 5 and we have 7 then 5 then 2 in a row
            GameObject NewUnit = Instantiate(UnitModle);
            units[i]= NewUnit.GetComponent<Units>();
            if (i < middle)
            {

                float XPosOffset = (middle - i) * UnitSize;
                Vector3 NewPosition = this.transform.position - new Vector3(XPosOffset, 0, 0);
                Debug.Log(NewPosition + " i= " + i);
                units[i].SetCurrentPosition(NewPosition);
            }
            else if (i == middle)
            {

                Vector3 NewPosition = this.transform.position;
                Debug.Log(NewPosition+" i= "+i);
                units[i].SetCurrentPosition(NewPosition);
            }
            else if (i > middle)
            {

                float XPosOffset = (i - middle) * UnitSize;
                Vector3 NewPosition = this.transform.position + new Vector3(XPosOffset, 0, 0);
                Debug.Log(NewPosition + " i= " + i);
                units[i].SetCurrentPosition(NewPosition);


            }
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
                //Debug.Log(NewPosition);
                units[i].SetMovementPosition(NewPosition);
            }
            else if(i==middle)
            {

                Vector3 NewPosition = path.corners[0];

                units[i].SetMovementPosition(NewPosition);
            }
            else if(i>middle)
            {

                float XPosOffset = (i-middle ) * UnitSize;
                Vector3 NewPosition = path.corners[0] + new Vector3(XPosOffset, 0, 0);

                units[i].SetMovementPosition(NewPosition);


            }

           
        }
    }
}

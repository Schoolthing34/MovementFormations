using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public GameObject ClickedObject = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check for mouse click 
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    //Our custom method. 
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                   if(raycastHit.transform.gameObject.tag=="Terrain")
                    {
                        if(ClickedObject != null)
                        {
                            Vector3 newPosition = raycastHit.point;
                            ClickedObject.GetComponent<UnitMovementManagement>().moveToPosition(newPosition);
                        }
                    }
                }
            }

        }
    }


    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if(gameObject.tag=="Unit")
        {
            Debug.Log(gameObject);

            gameObject.GetComponent<UnitMovementManagement>().Clicked();
            ClickedObject = gameObject;
        }
        else
        {
            if(ClickedObject!=null)
            ClickedObject.GetComponent<UnitMovementManagement>().Unclicked();
            ClickedObject = null;
        }
      
    }







    }

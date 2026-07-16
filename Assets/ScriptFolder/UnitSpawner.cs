using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{


    //spawn area
    [SerializeField]
    private int Xarea;
    [SerializeField]
    private int Yarea;
    [SerializeField]
    private GameObject Unit;

    public int UnitAmount;
    public int rowAmount;
    public int columnAmount;
    public float UnitSpacing;
    // Start is called before the first frame update
    void Start()
    {
        if(Unit==null)
        {
            Debug.LogError("Hey this unity has noone to spawn");
        }

        //for future reference spawn unit not inside objects
        for(int i=0;i<rowAmount;i++)
        {
            for (int j = 0; j < columnAmount; j++)
            {

                Vector3 position = new Vector3();
                GameObject TempUnit=Instantiate(Unit,this.transform);
                TempUnit.transform.position = position;
            }

        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

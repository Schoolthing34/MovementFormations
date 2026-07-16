using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovementManagement: MonoBehaviour
{

    private Vector3 Direction;
    private float speed = 10;
    public Vector3 movingPos;
    public bool clicked = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position!=movingPos)
        {
            this.transform.position += Direction.normalized * speed * Time.deltaTime;
        }
    }

    public void moveToPosition(Vector3 MovementPosition)
    {
        Debug.Log(MovementPosition);
        movingPos = MovementPosition;
        Direction = (movingPos - this.transform.position).normalized;
    }
    public void Clicked()
    {
        clicked = true;

    }

    public void Unclicked()
    {


        clicked = false;
    }

}

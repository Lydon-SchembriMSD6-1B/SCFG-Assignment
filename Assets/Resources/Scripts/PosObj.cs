using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class positionRecord

{


    //the place where I've been
    Vector3 position;
    //at which point was I there?
    int positionOrder;



    public GameObject ObstacleObject;




//==
//1.Equals(1) = true

    //this method exists in every object in C sharp


    public override bool Equals(System.Object obj)
    {
        if (obj == null)
            return false;
        positionRecord p = obj as positionRecord;
        if ((System.Object)p == null)
            return false;
        return position == p.position;
    }


    public bool Equals(positionRecord o)
    {
        if (o == null)
            return false;

        
            //the distance between any food spawned
            return Vector3.Distance(this.position,o.position) < 2f;
       
       
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }




    public Vector3 Position { get => position; set => position = value; }
    public int PositionOrder { get => positionOrder; set => positionOrder = value; }
    
}

public class PosObj : MonoBehaviour
{
}

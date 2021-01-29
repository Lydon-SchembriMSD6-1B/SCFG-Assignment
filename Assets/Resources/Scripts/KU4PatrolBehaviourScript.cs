using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KU4PatrolBehaviourScript : MonoBehaviour
{
    public List<Transform> waypoints;

    public Transform objectToMove;


    IEnumerator Patrol()
    {
        while (true)
        {
            foreach (Transform mytransform in waypoints)
            {
                while (Vector3.Distance(objectToMove.position, mytransform.position) > 0.1f)
                {
                    //1 unit towards the first one
                    objectToMove.position = Vector3.MoveTowards(objectToMove.position,
                    mytransform.position, 1f);

                    yield return new WaitForSeconds(0.1f);
                }

                yield return null;
            }

            yield return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Patrol());
    }

    // Update is called once per frame
    void Update()
    {

           
        
    }
}

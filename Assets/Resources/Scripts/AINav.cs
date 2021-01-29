using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pathfinding;


public class AINav : MonoBehaviour
{
    //script responsible for path generation
    Seeker seeker;

    //stores path
    Path pathToFollow;

    //select target
    public Transform target;

    //grid graph object
    GameObject GridGraphParent;


    public List<Transform> obstacleNodes;


   //first frame
    void Start()
    {

        seeker = GetComponent<Seeker>();

        Debug.Log(this.name);

        //seeker inside object


        //find gridgraph
        GridGraphParent = GameObject.Find("AStarGrid");
        //scan graph
        GridGraphParent.GetComponent<AstarPath>().Scan();

        //initially generate
        pathToFollow = seeker.StartPath(transform.position, target.position);

        //move green box in a loop
        //StartCoroutine(moveTarget());

        //update the graph in a loop
        StartCoroutine(updateGraph());

        //move the red robot towards the green enemy
        StartCoroutine(moveTowardsEnemy(this.transform));
    }


    

    //the code that is going to move my target.
    IEnumerator moveTarget()
    {
        //create a new list of positions.
        List<Vector3> positions = new List<Vector3>();
        //target's current position (the top position)
        positions.Add(target.position);

        //adding another position (the bottom position)
        positions.Add(new Vector3(target.position.x, -target.position.y));

        StartCoroutine(moveTarget(target.transform, positions, true));



        yield return null;

    }



    IEnumerator updateGraph()
    {
        while (true)
        {

           
            GridGraphParent.GetComponent<AstarPath>().Scan();


            yield return null;

        }

    }

    IEnumerator moveTarget(Transform t, List<Vector3> points, bool loop)
    {
        if (loop)
        {
            //runs on a loop
            while (true)
            {
                List<Vector3> forwardpoints = points;

                foreach (Vector3 position in forwardpoints)
                {
                    while (Vector3.Distance(t.position, position) > 0.5f)
                    {
                        t.position = Vector3.MoveTowards(t.position, position, 1f);
                        Debug.Log(position);/**/
                        yield return new WaitForSeconds(0.2f);
                    }
                }
                //reverse points
                forwardpoints.Reverse();
                yield return null;

            }
        }
        else
        {
            foreach (Vector3 position in points)
            {
                while (Vector3.Distance(t.position, position) > 0.5f)
                {
                    t.position = Vector3.MoveTowards(t.position, position, 1f);
                    /**/
                    yield return new WaitForSeconds(0.2f);
                }
            }
            yield return null;
        }


    }


    IEnumerator moveTowardsEnemy(Transform t)
    {

        while (true)
        {

            List<Vector3> posns = pathToFollow.vectorPath;
            Debug.Log("Positions Count: " + posns.Count);

            for (int counter = 0; counter < posns.Count; counter++)
            {
                // Debug.Log("Distance: " + Vector3.Distance(t.position, posns[counter]));
                if (posns[counter] != null)
                {
                    while (Vector3.Distance(t.position, posns[counter]) >= 0.5f)
                    {
                        t.position = Vector3.MoveTowards(t.position, posns[counter], 1f);
                        //since the enemy is moving, I need to make sure that I am following him
                        pathToFollow = seeker.StartPath(t.position, target.position);
                        //wait until the path is generated
                        yield return seeker.IsDone();
                        //if the path is different, update the path that I need to follow
                        posns = pathToFollow.vectorPath;

                        //  Debug.Log("@:" + t.position + " " + target.position + " " + posns[counter]);
                        yield return new WaitForSeconds(0.2f);
                    }

                }
                //keep looking for a path because if we have arrived the enemy will anyway move away
                //This code allows us to keep chasing
                pathToFollow = seeker.StartPath(t.position, target.position);
                yield return seeker.IsDone();
                posns = pathToFollow.vectorPath;
                //yield return null;

            }
            yield return null;
        }
    }
    //A* pathfinding pro implements this functionality using a specific feature. Explain what this feature is (You may write your answer as a comment in your code).

    //This Pro feature is called Local Avoidance, this feature is based on Reciprocal Velocity Obstacles. It adjusts the output from context aware streering actions to avoid collision with nearby agents.

}

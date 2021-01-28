using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{

    // public GameObject AI;
    // public GameObject[] AIbots;

    //a reference to PointGraphObject
    GameObject GridGraphParent;

    positionRecord ObstaclePos;

    GameObject ObstacleObj;

    GameObject AIObj;

    // Start is called before the first frame update
    void Start()
    {
        ObstaclePos = new positionRecord();

        AIObj = Resources.Load<GameObject>("Prefabs/AI");

        ObstacleObj = Resources.Load<GameObject>("Prefabs/Obstacle");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartButton()
    {
        //AIbots = GameObject.FindGameObjectsWithTag("AI");

        foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("AI"))
        {
            AINav ObstacleComponent = gameObj.GetComponent<AINav>();


            if (ObstacleComponent != null)
            {
                ObstacleComponent.enabled = true;
            }
        }
    }


    public void ScanButton()
    {

        //find gridgraph
        //find gridgraph
        GridGraphParent = GameObject.Find("AStarGrid");
        //scan graph
        GridGraphParent.GetComponent<AstarPath>().Scan();
        Debug.Log("Scan Started via Button Click ");
    }

    public void AIButton()
    {
        ObstaclePos = new positionRecord();

        float randomX = Mathf.Floor(Random.Range(-49f, 49f));

        float randomY = Mathf.Floor(Random.Range(-49f, 49f));

        Vector3 randomLocation = new Vector3(randomX, randomY);

        //don't allow the food to be spawned on other food

        ObstaclePos.Position = randomLocation;


        ObstaclePos.ObstacleObject = Instantiate(AIObj, randomLocation, Quaternion.Euler(0f, 0f, 0f));
    }

    public void ObstacleButton()
    {
        ObstaclePos = new positionRecord();

        float randomX = Mathf.Floor(Random.Range(-49f, 49f));

        float randomY = Mathf.Floor(Random.Range(-49f, 49f));

        Vector3 randomLocation = new Vector3(randomX, randomY);

        //don't allow the food to be spawned on other food

        ObstaclePos.Position = randomLocation;


        ObstaclePos.ObstacleObject = Instantiate(ObstacleObj, randomLocation, Quaternion.Euler(0f, 0f, 0f));
    }
}

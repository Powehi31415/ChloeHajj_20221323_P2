using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour
{
    public List<GameObject> Obstacles = new List<GameObject>();
    float LastPosition = 0;
    float ObstacleCounter = 0;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            RandomGenerator();
        }
    }

    public void RandomGenerator()
    {
        int rand = Random.Range(0 , Obstacles.Count);
        ObstacleCounter++;
        CreateObstacles(Obstacles[rand]);
    }

    void CreateObstacles(GameObject obstacle)
    {
        GameObject obs = Instantiate(obstacle);
        float offset = 12;

        Vector3 pos = new Vector3(0, offset * ObstacleCounter);
        obs.transform.position = pos;

        obs.transform.SetParent(this.transform);
        LastPosition = obs.transform.position.y;
    }

}

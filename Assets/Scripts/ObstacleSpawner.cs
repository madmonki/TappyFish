using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    float timer;
    public float maxY;
    public float minY;
    float randomY;
    public float maxTime;

    public void InstantiateObstacle()
    {
        randomY = Random.Range(minY, maxY);
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x, randomY);
    }

    void Start()
    {
        // InstantiateObstacle();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= maxTime) {
            InstantiateObstacle();
            timer = 0;
        }
    }
}

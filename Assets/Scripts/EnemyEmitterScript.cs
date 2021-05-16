using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEmitterScript : MonoBehaviour
{
    public GameObject prefabEnemy;
    public float launchDelayEnemy;

    float nextLaunchTime;

    void Update()
    {
        if (!GameController.isStarted)
            return;

        if (Time.time > nextLaunchTime)
        {           
            Instantiate(prefabEnemy, transform.position, Quaternion.identity);
            nextLaunchTime = Time.time + launchDelayEnemy;
        }
    }
}

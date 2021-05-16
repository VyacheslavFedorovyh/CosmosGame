using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEmitterScript : MonoBehaviour
{
    public List<GameObject> prefabAsteroids = new List<GameObject>();
    public float launchDelayAsteroid;

    float nextLaunchTime;

    void Update()
    {
        if (!GameController.isStarted)
            return;

        if (Time.time > nextLaunchTime)
		{
            int prefabIndex = Random.Range(0, prefabAsteroids.Count-1);
            var shiftX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
			var position = transform.position + new Vector3(shiftX, 0, 0);
			Instantiate(prefabAsteroids[prefabIndex], position, Quaternion.identity);

			nextLaunchTime = Time.time + launchDelayAsteroid;
		}
    }
}

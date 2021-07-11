using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{	
	float nextRocketTime;

	public float speed;
	public float titl;
	public float shotDelay;

	public GameObject enemyExplosion;

	[SerializeField] private GameObject _rocket;
	public List<GameObject> rocketGunPositions;

	[Tooltip("Game Boundary Enemy")]
	public float xMin, xMax, zMin, zMax;

	private Transform enemyTransform;
	private Transform playerTransform;

	private void Start()
	{
		enemyTransform = transform;
		playerTransform = GameObject.FindWithTag("Player").transform;
	}

	void Update()
	{
		if (!GameController.isStarted)
			return;

		if (enemyTransform.position.z > zMax)
		{
			enemyTransform.LookAt(playerTransform);
			enemyTransform.position += enemyTransform.forward * speed * Time.deltaTime;
		}

		if (Time.time > nextRocketTime)
		{
			foreach (var rocketGunPosition in rocketGunPositions)
			{
				GameObject rocket = Instantiate(_rocket, rocketGunPosition.transform.position, rocketGunPosition.transform.rotation);
				rocket.GetComponent<Rigidbody>().velocity = enemyTransform.forward * speed * 1.5f;
				nextRocketTime = Time.time + shotDelay;
			}			
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
			return;

		if (other.tag == "LaserShot" || other.tag == "Player")
		{
			Instantiate(enemyExplosion, other.transform.position, Quaternion.identity);

			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}

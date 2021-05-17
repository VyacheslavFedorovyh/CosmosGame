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

	public GameObject rocket;
	public GameObject rocketGunLeft;
	public GameObject rocketGunRight;

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
		//else 
		//{
		//	float correcX = Mathf.Clamp(enemy.position.x, xMin, xMax);
		//	enemy.position = new Vector3(correcX, 0, zMin);
		//}

		//var playerPosition = GameObject.FindWithTag("Player").transform.position;

		//float moveHorizontal = Input.GetAxis("Horizontal");
		//float moveVertical = Input.GetAxis("Vertical");

		//enemy.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

		//float correcX = Mathf.Clamp(enemy.position.x, xMin, xMax);
		//float correcZ = zMin;

		//enemy.position = new Vector3(correcX, 0, correcZ);

		//enemy.rotation = Quaternion.Euler(enemy.velocity.z * titl, 0, -enemy.velocity.x * titl);

		if (Time.time > nextRocketTime)
		{			
			var i = Instantiate(rocket, rocketGunLeft.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
			Instantiate(rocket, rocketGunRight.transform.position, Quaternion.identity).GetComponent<Rigidbody>().velocity = enemyTransform.forward * speed * 1.5f;
			i.velocity = enemyTransform.forward * speed * 1.5f;

			nextRocketTime = Time.time + shotDelay;
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

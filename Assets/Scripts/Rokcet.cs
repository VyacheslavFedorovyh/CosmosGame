using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rokcet : MonoBehaviour
{
	[SerializeField] private GameObject asteroidExplosion;
	[SerializeField] private GameObject playerExplosion;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
			return;

		if (other.tag == "LaserShot")
			GameController.score += 10;

		if (other.tag == "Player")
			Instantiate(playerExplosion, other.transform.position, Quaternion.identity);

		Instantiate(asteroidExplosion, transform.position, Quaternion.identity);

		Destroy(other.gameObject);
		Destroy(gameObject);
	}

}

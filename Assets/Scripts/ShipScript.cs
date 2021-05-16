using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    Rigidbody ship;
    float nextShatTime;

    public float speed;
    public float titl;
    public float shotDelay;

    [Tooltip("Game Boundary Ship")]
    public float xMin, xMax, zMin, zMax;

    public GameObject laserShot;
    public GameObject laserGunLeft;
    public GameObject laserGunRight;

    public GameObject laserShotMini;
    public GameObject laserMiniGunLeft;
    public GameObject laserMiniGunRight;

    void Start()
    {
        ship = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!GameController.isStarted)
            return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

		float correcX = Mathf.Clamp(ship.position.x, xMin, xMax);
		float correcZ = Mathf.Clamp(ship.position.z, zMin, zMax);

		ship.position = new Vector3(correcX, 0, correcZ);

        ship.rotation = Quaternion.Euler(ship.velocity.z * titl, 0, -ship.velocity.x * titl);


        if (Time.time > nextShatTime && Input.GetButton("Fire1"))
        {
            Instantiate(laserShot, laserGunLeft.transform.position, Quaternion.identity);
            Instantiate(laserShot, laserGunRight.transform.position, Quaternion.identity);
            nextShatTime = Time.time + shotDelay;

            if (GameController.score > 100)
                GameController.score -= 10;
        }

        if (Time.time > nextShatTime && Input.GetButton("Fire2"))
        {        
            Instantiate(laserShotMini, laserMiniGunLeft.transform.position, Quaternion.Euler(new Vector3(0, -45, 0))).GetComponent<Rigidbody>().velocity = new Vector3(-45, 0, 65);
            Instantiate(laserShotMini, laserMiniGunRight.transform.position, Quaternion.Euler(new Vector3(0, 45, 0))).GetComponent<Rigidbody>().velocity = new Vector3(45, 0, 65);

            nextShatTime = Time.time + shotDelay * 5;

            if (GameController.score > 100)
                GameController.score -= 10;
        }
    }
}

using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerControler : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shots;
	public Transform shotSpawn;

	public float fireRate;
	private float nextFire;

	void Update()
	{
		if(Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shots, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play();
		}
	}

	void FixedUpdate()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector3 moviment = new Vector3(horizontal, 0.0f, vertical);

		GetComponent<Rigidbody>().velocity = moviment * speed;

		GetComponent<Rigidbody>().position = new Vector3 
		(
				Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
				0.0f,
				Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax) 
		);

		GetComponent<Rigidbody>().rotation = 
			Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}

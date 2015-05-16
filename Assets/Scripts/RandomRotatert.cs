using UnityEngine;
using System.Collections;

public class RandomRotatert : MonoBehaviour {

	public float tunble;

	void Start()
	{
		GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tunble;
	}
}

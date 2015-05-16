using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {
	// Use this for initialization
	void Start () 
	{
		Destroy(gameObject, 2);
	}
}

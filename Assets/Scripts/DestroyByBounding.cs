using UnityEngine;
using System.Collections;

public class DestroyByBounding : MonoBehaviour {

	void OnTriggerExit(Collider other) {
		Destroy(other.gameObject);
	}
}

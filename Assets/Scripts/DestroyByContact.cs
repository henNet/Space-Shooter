using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameControler gameControler;

	void Start()
	{
		GameObject gameControlerObject = GameObject.FindWithTag("GameController");

		if (gameControlerObject != null){
			gameControler = gameControlerObject.GetComponent<GameControler> ();
		} else {
				Debug.Log ("Can't find gameControler in script!!\n");
		}
	}

	void OnTriggerEnter(Collider other) {
		
		if(other.tag == "Bounding")
			return;

		Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameControler.GameOver();
		}

		gameControler.AddScore(scoreValue);

		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControler : MonoBehaviour {

	public GameObject harzard;
	public Vector3 spawnValues;
	public int harzardCount;
	public float spawnWait;
	public float startWait;

	public Text scoreCount;
	public Text restart;
	public Text gameOver;
	public Text message;
	public Text exitGame;

	private bool is_restart;
	private bool is_gameover;
	private bool is_exit;
	private int score;

	void Start()
	{
		score = 0;
		is_restart = false;
		is_gameover = false;
		is_exit = false;

		restart.text = "";
		gameOver.text = "";
		message.text = "";
		exitGame.text = "";

		UpdateScore();
		StartCoroutine(SpawnWaves());
	}

	void Update()
	{
		if (is_restart) 
		{
			if(Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);

			}
		}

		if(is_exit)
			if(Input.GetKeyDown(KeyCode.E))
				Application.Quit();
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		while (true) 
		{
			for (int i = 0; i < harzardCount; i++) 
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 
				spawnValues.y, spawnValues.z);

				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (harzard, spawnPosition, spawnRotation);

				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds(2);

			if(is_gameover)
			{
				restart.text = "Press 'R' to Restart";
				exitGame.text = "Press 'E' to Exit Game";
                is_restart = true;
				is_exit = true;
				break;
			}
		}
	}

	public void AddScore(int newscoreValue)
	{
		score += newscoreValue;
		UpdateScore();
	}

	void UpdateScore()
	{
		scoreCount.text = "Score: " + score;
	}

	public void GameOver()
	{
		gameOver.text = "Game Over";
		is_gameover = true;

		if (score <= 500)
			message.text = "You are too bad!";
		else if (score > 500 && score < 1000)
			message.text = "Congratulations! You're good!";
		else if (score >= 1000)
			message.text = "Fantastic! You're the king of space!";
	}
}

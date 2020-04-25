using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

    public PlayerController player;

	public GameObject enemy;
    public GameObject retry;
    public int enemyCount;
	private bool gameOver;
	private bool restart;
	public int score;
	//public bool ToucheSol;
	
	public Text scoreText;

	public float spawnWait;
	public float startWait;
	public float waveWait;

	void Start () {
        Screen.SetResolution(640, 480, false);
        gameOver = false;
		restart = false;
		score = 0;
		UpdateScore();
        spawnWait = 1.2f;
		StartCoroutine(SpawnWaves());
		//Anti-crash measures DISENGAGED.
	}
/*
	void Update()
	{
		if (restart)
		{
			if (Input.GetKeyDown(KeyCode.R))	
			{
				SceneManager.LoadScene("Game");
			}
		}

		if (Input.GetKeyDown(KeyCode.S) == true)
		{
			Instantiate(enemy);
		}
	}
*/

	void Update()
	{
		if (restart)
		{
			if(Input.touchCount > 0)
			{
				
				Touch touch = Input.GetTouch(0);
				Vector3 touch_Pos = Camera.main.ScreenToWorldPoint(touch.position);

				if(touch_Pos.x > 0)
				{

					SceneManager.LoadScene("Game");

				}
			}

			if(Input.touchCount > 0){

				Touch touch1 = Input.GetTouch(0);
				Vector3 touch_Pos1 = Camera.main.ScreenToWorldPoint(touch1.position);

				if(touch_Pos1.x < 0)
				{
					Instantiate(enemy);

				}
			}
		}
	}
			
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		while (true)
		{
			for (int i = 0; i < enemyCount; i++)
			{
				Instantiate(enemy);
				yield return new WaitForSeconds(spawnWait);
			}
			if (gameOver)
			{
				restart = true;
                retry.SetActive(true);
				break;
			}
            spawnWait = spawnWait - 0.05f;
            Debug.Log("Faster...");
            yield return null;
		}
		yield return new WaitForSeconds(waveWait);
	}

	public void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore();
	}

	public void GameOver()
	{
		gameOver = true;
	}
}

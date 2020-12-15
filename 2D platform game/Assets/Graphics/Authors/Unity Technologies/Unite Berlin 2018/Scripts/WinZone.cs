// This script is responsible for detecting collision with the player and letting the 
// Game Manager know

using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
	int playerLayer;    //The layer the player game object is on
	public GameObject endCreditsMenu;
	private float timeElapsed;
	private float delayBeforeLoading = 10f;
	private bool loadAfterEndOfGame = false;

	void Start()
	{
		//Get the integer representation of the "Player" layer
		playerLayer = LayerMask.NameToLayer("Player");
	}

	void Update()
	{
		//Load start menu after showing credits after 10 seconds
		if(loadAfterEndOfGame)
		{
			timeElapsed += Time.deltaTime;

			if(timeElapsed >= delayBeforeLoading)
			{
				endCreditsMenu.SetActive(false);
				loadAfterEndOfGame = false;
				SceneManager.LoadScene("StartMenu");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		//If the collision wasn't with the player, exit
		if (collision.gameObject.layer != playerLayer)
			return;

		//Write "Player Won" to the console and tell the Game Manager that the player
		//won
		Debug.Log("Player Won!");
		GameManager.PlayerWon();
		endCreditsMenu.SetActive(true);
		loadAfterEndOfGame = true;
	}
}

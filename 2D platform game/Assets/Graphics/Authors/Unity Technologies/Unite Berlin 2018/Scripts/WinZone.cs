﻿// This script is responsible for detecting collision with the player and letting the 
// Game Manager know

using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class WinZone : MonoBehaviour
{
	int playerLayer;    //The layer the player game object is on
	public GameObject endCreditsMenu;
	public GameObject endCreditsSubtitlesMenu;
	private float timeElapsed;
	private float delayBeforeLoadingMainMenu = 26.0f;
	private float delayBeforeLoadingCreditsSubtitles = 6.0f;
	private bool loadAfterEndOfGame = false;
	public CinemachineVirtualCamera virtualCamera;
	public GameObject player;
	public TimeManager timeManager;

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

			if(timeElapsed >= delayBeforeLoadingCreditsSubtitles)
			{
				endCreditsMenu.SetActive(false);
				endCreditsSubtitlesMenu.SetActive(true);
			}
			
			if(AudioManager.CreditsAudioIsStillPlaying()==false)
			{
				loadAfterEndOfGame = false;
				PlayerPrefs.SetInt("ActualProgresInGame", 0);
				PlayerPrefs.SetInt("TheHighestLevelReachedByThePlayer", 0);
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
		AudioManager.StartCreditsAudio();
		loadAfterEndOfGame = true;
		DisableCameraFollow();
		player.SetActive(false);
		timeManager.TurnOffSlowMotion();
	}

	void DisableCameraFollow()
	{
		virtualCamera.Follow = null;
	}
}

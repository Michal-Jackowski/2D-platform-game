using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StoneTurnOffSound : MonoBehaviour
{
    public GameObject stone;
    int playerLayer;    //The layer the player game object is on

    void Start()
    {
        //Get the integer representation of the "Player" layer
		playerLayer = LayerMask.NameToLayer("Player");
    }

    void OnTriggerEnter2D(Collider2D collision)
	{
        //If the collision wasn't with the player, stop playing audio
		if (collision.gameObject.layer != playerLayer)
        {
            AudioManager.StopRockFallAudio();
            //AudioManager.StopMusicAudio();
            //AudioManager.StartLevelAudio();
        }
			
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StoneImpactSoundEffect : MonoBehaviour
{
    public AudioSource rollingStoneSound;
    int playerLayer;    //The layer the player game object is on

    void Start()
    {
        //Get the integer representation of the "Player" layer
		playerLayer = LayerMask.NameToLayer("Player");
    }

    void OnTriggerEnter2D(Collider2D collision)
	{
        //If the collision wasn't with the player, play audio
		if (collision.gameObject.layer != playerLayer)
        {
            rollingStoneSound.enabled = false;
            AudioManager.PlayRockImpactAudio();
        }
	}
}

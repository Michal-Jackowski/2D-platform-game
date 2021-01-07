﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StoneActivator : MonoBehaviour
{
    int playerLayer;    //The layer the player game object is on
    public GameObject stone;
    public CinemachineImpulseListener cinemachineImpulseListener;

    void Start()
    {
        //Get the integer representation of the "Player" layer
		playerLayer = LayerMask.NameToLayer("Player");
    }

    void OnTriggerEnter2D(Collider2D collision)
	{
		//If the collision wasn't with the player, exit
		if (collision.gameObject.layer != playerLayer)
			return;

        stone.SetActive(true);
        cinemachineImpulseListener.enabled = true;
        AudioManager.PlayRockFallAudio();
	}
}
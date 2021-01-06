using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeLayer : MonoBehaviour
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
        //If the collision wasn't with the player, change layer because object isn't trap anymore
		if (collision.gameObject.layer != playerLayer)
            stone.layer = 10;
	}
}

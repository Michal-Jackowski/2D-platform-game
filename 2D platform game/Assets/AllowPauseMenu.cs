using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowPauseMenu : MonoBehaviour
{
    int playerLayer;    //The layer the player game object is on
    public GameObject allowPauseMenu;

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

        allowPauseMenu.SetActive(false);
	}
}
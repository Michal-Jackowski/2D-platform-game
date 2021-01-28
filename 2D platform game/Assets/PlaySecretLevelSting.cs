using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySecretLevelSting : MonoBehaviour
{
    int playerLayer;    //The layer the player game object is on
    public BoxCollider2D secretLevelStingTrigger;
    public GameObject secretLevelTriggerObject;


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

        AudioManager.PlaySecretLevelDiscovered();
        secretLevelTriggerObject.SetActive(false);
	}
}

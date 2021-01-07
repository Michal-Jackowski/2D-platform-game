using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMoveBoxSoundEffect : MonoBehaviour
{
    public Rigidbody2D boxRigidbody;
    int playerLayer;    //The layer the player game object is on
    bool CanStop = false;

    void Start()
    {
        //Get the integer representation of the "Player" layer
		playerLayer = LayerMask.NameToLayer("Player");
    }

    void Update()
    {
        if (boxRigidbody.velocity.magnitude <= 0.01f && CanStop)
        {
            AudioManager.StopBoxPushAudio();
            CanStop = false;
        }
        //Debug.Log(boxRigidbody.velocity.magnitude);
    }

    void OnTriggerEnter2D(Collider2D collision)
	{
		//If the collision was with the player, play sound effect
		if (collision.gameObject.layer == playerLayer && boxRigidbody.velocity.magnitude > 0f)
        {
            //Debug.Log(boxRigidbody.velocity.magnitude);
            AudioManager.PlayBoxPushAudio();
        }
	}

    void OnTriggerExit2D(Collider2D collision)
    {
        CanStop = true;
    }
}

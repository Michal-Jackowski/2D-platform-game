using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionActivator : MonoBehaviour
{
    int playerLayer;    //The layer the player game object is on
    public GameObject platform;
    public TimeManager timeManager;
    public static bool isSlowMotionActive = false;

    void Start()
    {
        //Get the integer representation of the "Player" layer
		playerLayer = LayerMask.NameToLayer("Player");
        isSlowMotionActive = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
	{
		//If the collision wasn't with the player, exit
		if (collision.gameObject.layer != playerLayer)
			return;

        isSlowMotionActive = true;
        platform.SetActive(false);
        timeManager.TurnOnSlowMotion();
        AudioManager.StopMusicAudio();
        AudioManager.PlayFlatLineAudio();
	}
}
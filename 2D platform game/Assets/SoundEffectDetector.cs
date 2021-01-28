using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectDetector : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            Debug.Log("Play grass sound effect!");
        }
		else
		{
			Debug.Log("No collision!");
		}
    }
}

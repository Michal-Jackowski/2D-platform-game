using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SectorNumberOneEnterTrigger : MonoBehaviour
{
    public CinemachineImpulseListener cinemachineImpulseListener;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //Debug.Log("Sector one passed!");
            // Number is equal to one of the sectors
            PlayerPrefs.SetInt("ActualProgresInGame", 1);
            ComparingTheHighestLevelAchieved.SetHighestLevel();
            cinemachineImpulseListener.enabled = false;
        }
    }
}

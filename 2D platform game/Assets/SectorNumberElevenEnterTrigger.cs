using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorNumberElevenEnterTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //Debug.Log("Sector eleven passed!");
            // Number is equal to one of the sectors
            PlayerPrefs.SetInt("ActualProgresInGame", 11);
            ComparingTheHighestLevelAchieved.SetHighestLevel();
        }
    }
}

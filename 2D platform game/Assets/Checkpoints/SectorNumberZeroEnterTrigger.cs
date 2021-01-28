using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorNumberZeroEnterTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //Debug.Log("Sector zero passed!");
            // Number is equal to one of the sectors
            PlayerPrefs.SetInt("ActualProgresInGame", 0);
            ComparingTheHighestLevelAchieved.SetHighestLevel();
        }
    }
}

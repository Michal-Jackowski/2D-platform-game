using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComparingTheHighestLevelAchieved : MonoBehaviour
{
    static public void SetHighestLevel()
    {
        if(PlayerPrefs.GetInt("ActualProgresInGame") > PlayerPrefs.GetInt("TheHighestLevelReachedByThePlayer"))
        {
            PlayerPrefs.SetInt("TheHighestLevelReachedByThePlayer", PlayerPrefs.GetInt("ActualProgresInGame"));
        }
    }
}

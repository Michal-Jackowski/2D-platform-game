using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public int level = 0;
    public int health = 0;

    public void SavePlayerPosition()
    {
        SaveSystem.SavePlayerPosition(this);
    }

    public void LoadPlayerPosition()
    {
        PlayerPositionData data = SaveSystem.LoadPlayerPosition();

        level = data.level;
        health = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}

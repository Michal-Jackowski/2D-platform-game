using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerPositionData
{
    public int level;
    public int health;
    public float[] position;

    public PlayerPositionData(PlayerPosition playerPosition)
    {
        level = playerPosition.level;
        health = playerPosition.health;

        position = new float[3];
        position[0] = playerPosition.transform.position.x;
        position[1] = playerPosition.transform.position.y;
        position[2] = playerPosition.transform.position.z;
    }
}

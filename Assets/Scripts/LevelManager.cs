using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject CurrentCheckpoint;
    private int death = 0;
    public void RespawnPlayer()
    {
        FindObjectOfType<Move>().transform.position = CurrentCheckpoint.transform.position;
        death++;
        Debug.Log("Game Over, Deaths: " + death);
    }
}


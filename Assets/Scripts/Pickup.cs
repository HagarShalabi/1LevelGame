using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//acorns are coins for the squirel!! 
public class Pickup : MonoBehaviour
{
    int totalCoin = 0;
    int coinValue = 1;
 public void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().coinCollected += coinValue;
            Destroy(this.gameObject);
        }
    }
}

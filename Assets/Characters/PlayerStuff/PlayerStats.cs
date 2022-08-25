using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int health = 3;
    public int lives = 3;

    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;

    private SpriteRenderer sr;

    public bool ImmuneFlag = false;
    private float immuneTime = 0f;
    public float immuneDuration = 1.5f;

   public int coinCollected = 0;
    public void CollectCoin(int coinValue)
    {
        this.coinCollected += coinValue;
        Debug.Log("Acorn Eaten!");
    }
    /*
    public Text scoreUI;
    public Slider healthUI;*/
    void Start()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        //scoreUI = this.gameObject.GetComponent<Text>();
        //healthUI = this.gameObject.GetComponent<Slider>();
    }
    void SpriteFlicker()
    {
        if (this.flickerTime < this.flickerDuration)
            this.flickerTime = this.flickerTime+Time.deltaTime;
        else if (this.flickerTime >= this.flickerDuration)
        {
            sr.enabled = !(sr.enabled);
            this.flickerTime = 0;

        }
    }
   void PlayHitReaction()
    {
        this.ImmuneFlag = true;
        this.immuneTime = 0f;
    }
    public void TakeDamage(int damage)
    {
        if (this.ImmuneFlag == false)
        {
            this.health-=damage;
            if (this.health < 0)
                this.health = 0;
            else if(this.lives>0 && this.health == 0)
            {
                FindObjectOfType<LevelManager>().RespawnPlayer();
                this.health = 3;
                this.lives--;
            }
            else if (this.lives==0 && this.health==0)
            {
                Debug.Log("Gameover");
                Destroy(this.gameObject);
            }
            Debug.Log("Health: " + this.health.ToString());
            Debug.Log("Lives: " + this.lives.ToString());
        }
        PlayHitReaction();
    }
    void Update()
    {
        if (this.ImmuneFlag == true)
        {
            SpriteFlicker();
            immuneTime= immuneTime+Time.deltaTime;
            if (immuneTime >= immuneDuration)
            {
                this.ImmuneFlag = false;
                this.sr.enabled = true;
                Debug.Log("Immunity ended");
            }
        }
       /* scoreUI.text = "" + coinCollected;
        healthUI.value = health;*/
    }
}


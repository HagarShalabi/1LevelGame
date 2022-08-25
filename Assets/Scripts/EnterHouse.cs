using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHouse : MonoBehaviour
{
    private SpriteRenderer lever;
    public Sprite exploded;

    // Start is called before the first frame update
    void Start()
    {
        lever = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && other.GetContact(0).point.y < transform.position.y)
        {
            lever.sprite = exploded;
            Object.Destroy(gameObject, .2f);
            Debug.Log("Arrived Safely.Thanks for Playing!");
        }
    }
}

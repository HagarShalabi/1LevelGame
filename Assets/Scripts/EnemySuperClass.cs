using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySuperClass : MonoBehaviour
{
    public bool faceRightFlag = false;
    public float maxSpeed;
    public int damage;
    public void Flip()
    {
        faceRightFlag = !faceRightFlag;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

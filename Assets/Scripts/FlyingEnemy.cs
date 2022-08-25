using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float HSpeed;
    public float vSpeed;
    public float Amp;
    private Vector3 tPosition;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        tPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tPosition.x += HSpeed;
        tPosition.y = Mathf.Sin(Time.realtimeSinceStartup * vSpeed) * Amp;
        transform.position = tPosition;
    }
}

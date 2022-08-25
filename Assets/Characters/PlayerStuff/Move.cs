using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //VARIABLES
    public float moveSpeed, jumpHeight;
    public bool faceRight;
    public KeyCode Space, L, R;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;
    private Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        faceRight = true;
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // JUMP
        if ((Input.GetKeyDown(Space)) && grounded)
        {
            //JUMP FUNCTION
            jump();
        }
        anime.SetBool("Ground", grounded);

        //LEFT
        if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (faceRight)
            {
                //FLIP FUNCTION
                flip();
            }
        }

        //RIGHT
        if (Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (!faceRight)
            {
                //FLIP FUNCTION
                flip();
            }
        }
        anime.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x)); 
    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
 
    void jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
    void flip()
    {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        faceRight = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;

    private Transform trans;
    private Rigidbody2D r2D;
    private SpriteRenderer SPR;
    private Animator anime;

    void Start()
    {
        Debug.Log("BILAL IS A CHAMPION!");
        trans = GetComponent<Transform>();
        r2D = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        SPR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            r2D.velocity = new Vector2(r2D.velocity.x, jumpForce);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            r2D.velocity = new Vector2(moveSpeed, r2D.velocity.y);
            anime.SetBool("Run", true);
            SPR.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            r2D.velocity = new Vector2(-moveSpeed, r2D.velocity.y);
            anime.SetBool("Run", true);
            SPR.flipX = true;
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.name == "key")
        if (collision.gameObject.CompareTag("Collectable"))
        {
            Object.Destroy(collision.gameObject);
        }
    }*/
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Object.Destroy(other.gameObject);
        }
    }*/
}

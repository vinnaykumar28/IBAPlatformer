using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMov : MonoBehaviour
{
    public float moveSpeed = 5f;

    private bool rightCheck = true;

    private Rigidbody2D r2D;
    private SpriteRenderer SPR;


    // Start is called before the first frame update
    void Start()
    {
        r2D = GetComponent<Rigidbody2D>();
        SPR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rightCheck){
            //r2D.velocity = new Vector2(r2D.velocity.x, jumpForce);
        }
    }
}

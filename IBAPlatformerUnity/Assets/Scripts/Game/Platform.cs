using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool leftRight = true;
    public bool start = true;

    private Rigidbody2D r2D;

    void Start() {
        r2D = GetComponent<Rigidbody2D>();

        if(start){
            if(leftRight){
                r2D.velocity = new Vector2(moveSpeed, r2D.velocity.y);
            }
            else{
                r2D.velocity = new Vector2(r2D.velocity.x, moveSpeed);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //check if platform should move left-right or up-down
        if(leftRight){
            if (other.gameObject.CompareTag("cRight"))
            {
                r2D.velocity = new Vector2(moveSpeed, r2D.velocity.y);
            }   
            else if (other.gameObject.CompareTag("cLeft"))
            {
                r2D.velocity = new Vector2(-moveSpeed, r2D.velocity.y);

            }
        }
        else {
            if (other.gameObject.CompareTag("cRight"))
            {
                r2D.velocity = new Vector2(r2D.velocity.x, moveSpeed);
            }   
            else if (other.gameObject.CompareTag("cLeft"))
            {
                r2D.velocity = new Vector2(r2D.velocity.x, -moveSpeed);
            }
        }

    }

    public void startMoving(){
        if(leftRight){
            r2D.velocity = new Vector2(moveSpeed, r2D.velocity.y);
        }
        else{
            r2D.velocity = new Vector2(r2D.velocity.x, moveSpeed);
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	private Rigidbody2D r2D;
	public float moveSpeed = 5f;

	private bool rCheck = false;
	private bool lCheck = false;

	// Use this for initialization
	void Start () {
		r2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void moveLeft(){
		if(!lCheck){
			if(rCheck) rCheck = false;
			r2D.velocity = new Vector2(-moveSpeed, r2D.velocity.y);
		}
	}

	public void moveRight(){
		if(!rCheck){
			if(lCheck) lCheck = false;
			r2D.velocity = new Vector2(moveSpeed, r2D.velocity.y);
		}
	}

	public void CancelLeftRight(){        
        r2D.velocity = new Vector2(0, r2D.velocity.y);
    }

	//Prevent paddle from going out of gamezone.
	private void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.CompareTag("cLeft"))
        {
			lCheck = true;
            CancelLeftRight();
        }   
		else if (other.gameObject.CompareTag("cRight"))
        {
			rCheck = true;
            CancelLeftRight();
        }  
	}
}

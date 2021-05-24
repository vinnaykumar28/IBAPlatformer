using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	private Rigidbody2D r2D;
	public float moveSpeed = 5f;

	// Use this for initialization
	void Start () {
		r2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//MoveWithMouse ();
	}

	void MoveWithMouse () {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
		this.transform.position = paddlePos;
	}

	public void moveLeft(){
		Debug.Log("Left!");
		r2D.velocity = new Vector2(-moveSpeed, r2D.velocity.y);
	}

	public void moveRight(){
		Debug.Log("Right!");
		r2D.velocity = new Vector2(moveSpeed, r2D.velocity.y);
	}

	public void CancelLeftRight(){        
        r2D.velocity = new Vector2(0, r2D.velocity.y);
    }
}

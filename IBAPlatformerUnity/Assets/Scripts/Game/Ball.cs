using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	private Rigidbody2D ballrigidbody2D;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		ballrigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
		}	
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

		if (hasStarted && (collision.gameObject.tag != "Breakable")) {
			ballrigidbody2D.velocity += tweak;
		}
	}

	public void startBall(){
		hasStarted = true;
		ballrigidbody2D.velocity = new Vector2 (2f, 10f);
	}
}

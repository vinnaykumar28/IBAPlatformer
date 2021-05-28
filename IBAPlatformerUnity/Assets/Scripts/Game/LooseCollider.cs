using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LooseCollider : MonoBehaviour {
	public Ball ball;
	public Button startButton;

	void OnTriggerEnter2D (Collider2D trigger) {
		//Reload level is lose
		//SceneManager.LoadScene(6);
		ball.restartBall();
		startButton.interactable = true;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour {

	public Sprite[] hitsprites;
	public static int breakableCount = 0;

	private int timesHeat;
	private bool isBreakable;

	// Use this for initialization
	void Start ()
	{
		isBreakable = (this.tag == "Breakable");
		// Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
		}

		timesHeat = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits () {
		timesHeat++;
		int maxHits = hitsprites.Length + 1;
		if (timesHeat >= maxHits) {
			breakableCount--;
			Destroy(gameObject);
			if (Brick.breakableCount <= 0) {
				PlayerController.returnToLevel(2);
				SceneManager.LoadScene(2);
			}
		} else {
			LoadSprites();
		}
	}


	void LoadSprites ()
	{
		int spriteIndex = timesHeat - 1;
		if (hitsprites [spriteIndex] != null) {
			this.GetComponent<SpriteRenderer> ().sprite = hitsprites [spriteIndex];
		} else {
			Debug.LogError ("Brick sprite missing");
		}
	}

}

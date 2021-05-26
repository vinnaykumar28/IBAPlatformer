using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseCollider : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D trigger) {
		SceneManager.LoadScene(6);
	}
}

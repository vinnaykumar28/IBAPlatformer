using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Distance : MonoBehaviour {

	public static int distance;
	public float t=0;
	public Text text;
	public bool isScoreReached = false;
	void Start () {
		distance = 0;
	}
	

	void Update () {
		t = t + Time.deltaTime;
		if(t>1)
		{
			t = 0;
			distance++;
		}
		text.text = distance.ToString ();
		if (distance == 15) {

			isScoreReached = true;
		}
	}
}

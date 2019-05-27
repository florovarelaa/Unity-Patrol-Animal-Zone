using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour {

	private float destroyTime;
	private Vector3 offSet;

	// Use this for initialization
	void Start () {
		offSet = new Vector3(0, -0.8f, 0);
		destroyTime = 0.7f;
		Destroy(gameObject, destroyTime);
		transform.localPosition += offSet;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

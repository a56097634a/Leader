using UnityEngine;
using System.Collections;

public class lastSwarmling : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Swarmling.mouseDown) {
			transform.position = World.lastSwarmling.transform.position;
			GetComponent<SpriteRenderer>().enabled = true;
		} else
			GetComponent<SpriteRenderer>().enabled = false;
	}
}

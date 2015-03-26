using UnityEngine;
using System.Collections;

public class Swarmling : MonoBehaviour {
	public static int initSwarmCount = 8;
	//color swarmlingColor = color(82, 68, 48);
	public static float swarmlingRadius = 5;
	public static float swarmlingMaxSpeed = 3.8f;
	public static float swarmlingDriftSpeed = 0.6f;
	public static float swarmlingMaxAccel = 0.3f;
	public static float swarmlingDamage = 0.05f;
	public static float avoidRadius = 80;
	public static float lineElbowRadius = 15;
	public static float elbowRadius = 40;
	public static float burnRadius = 100;
	public static float attractRadius = 2;
	private  float x, y, dx, dy, targetDistance;
	public Obstacle target;
	public Swarmling following;
	private bool unan = true;
	private int followCooldown = 0;


	// Use this for initialization

	private bool isFollow = false;
	Vector3  leaderPos;
	float speed = 10f;
	public static bool mouseDown = false;
	Vector3  currentFollowPos;
	Vector3  lastSwarmlingPos;
	GameObject currentFollow;
	float  bufferBetweenSwarmlings = 1.0f;

	void Start () {
		World.lastSwarmling = GameObject.Find ("Leader");
	}
	
	// Update is called once per frame
	void Update () {

		lastSwarmlingPos = World.lastSwarmling.transform.position;
		if (Input.GetMouseButtonDown (0))
			mouseDown = true;
		if (Input.GetMouseButtonUp (0))
			mouseDown = false;
		if (mouseDown && ((Vector3.Distance (transform.position, lastSwarmlingPos) < attractRadius)||isFollow)) {
			follow ();
		}
		if(isFollow && !mouseDown)
		{
			isFollow = false;
			World.lastSwarmling = GameObject.Find ("Leader");
		}
	}

	void follow(){
		if (!isFollow) {
			//if start to follow
			currentFollow = World.lastSwarmling;
			World.lastSwarmling = gameObject;
		}
		isFollow = true;
		currentFollowPos = currentFollow.transform.position;
		if (Vector3.Distance (transform.position, currentFollowPos) > bufferBetweenSwarmlings) {
			transform.position = Vector3.MoveTowards (transform.position, currentFollowPos, speed * Time.deltaTime);
		}
		Debug.Log (Rigidbody2D.

	}
}

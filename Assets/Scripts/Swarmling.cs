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
//	private bool unan = true;
//	private int followCooldown = 0;


	// Use this for initialization

	public bool isFollow = false;
	Vector3  leaderPos;
	float speed = 10f;
	public static bool mouseDown = false;
	Vector3  currentFollowPos;
	Vector3  lastSwarmlingPos;
	GameObject currentFollow;
	Swarmling follower;
	float  bufferBetweenSwarmlings = 1.0f;
	Rigidbody2D r;

	void Start () {
		World.lastSwarmling = GameObject.Find ("Leader");

		r = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
	}
	
	// Update is called once per frame
	void Update () {

		//check if mouse is down
		if (Input.GetMouseButtonDown (0))
			mouseDown = true;
		if (Input.GetMouseButtonUp (0))
			mouseDown = false;


		if (mouseDown && !isFollow)
			findFollow();

////todo
//		//update isFollow according to currentFollow
//		if (isFollow) {
//			//if currentFollow has been destroyed, detach me
//			if (currentFollow == null) isFollow = false;
//			//if currentFollow no more follow, detach me
//				else isFollow = currentFollow.isFollow;
//		}

		if (isFollow) {
			follow ();
		}

		if(isFollow && !mouseDown)
		{
			isFollow = false;
			World.lastSwarmling = GameObject.Find ("Leader");
		}

	}

	void findFollow(){


		lastSwarmlingPos = World.lastSwarmling.transform.position;
		
		//if lastSwarmling is near me, than follow it 
		if (Vector3.Distance (transform.position, lastSwarmlingPos) < attractRadius) {
			//start to follow
			currentFollow = World.lastSwarmling;
			World.lastSwarmling = gameObject;
			isFollow = true;

//			if(currentFollow != GameObject.Find ("Leader"))
//				currentFollow.follower = gameObject;
		}
	}

	void follow(){

		currentFollowPos = currentFollow.transform.position;

		if (Vector3.Distance (transform.position, currentFollowPos) > bufferBetweenSwarmlings) {

			//todo use addForce instead of moveTowards
			transform.position = Vector3.MoveTowards (transform.position, currentFollowPos, speed * Time.deltaTime);
//
//			Vector2 followVector = currentFollowPos - transform.position;
//			r.AddForce(followVector);
//			r.velocity = ( ( transform.right * followVector.x ) + ( transform.up * followVector.y ) ) / Time.deltaTime;
			Debug.Log (r.velocity);
		}
	}

	void OnDestroy() {
		//isFollow should be update for children

		if(isFollow)
    		World.lastSwarmling = currentFollow;


    }

}

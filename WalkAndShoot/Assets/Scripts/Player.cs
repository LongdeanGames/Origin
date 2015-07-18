using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	public KeyCode moveN;
	public KeyCode moveS;
	public KeyCode moveE;
	public KeyCode moveW;

	public KeyCode strafeL;
	public KeyCode strafeR;

	//Rigidbody2D
	Rigidbody2D rb2d;

	//Speed

	float playerSpeed = 2f;

	/*Key combinations*/
	KeyCode moveNW;
	KeyCode moveSW;
	KeyCode moveNE;
	KeyCode moveSE;

	float health;
	float speed;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
	} 
	
	// Update is called once per frame
	void Update () {

		float currentAnglef =  Mathf.Round (transform.eulerAngles.z) / 45f;
		int currentAngle = (int)currentAnglef;
		bool strafing = false;

		if (Input.GetKey (moveN) && Input.GetKey (moveE)) {
			rb2d.velocity = new Vector2 (1, 1) * playerSpeed;
		} else if (Input.GetKey (moveN) && Input.GetKey (moveW)) {
			rb2d.velocity = new Vector2 (-1, 1) * playerSpeed;
		} else if (Input.GetKey (moveS) && Input.GetKey (moveE)) {
			rb2d.velocity = new Vector2 (1, -1) * playerSpeed;
		} else if (Input.GetKey (moveS) && Input.GetKey (moveW)) {
			rb2d.velocity = new Vector2 (-1, -1) * playerSpeed;
		} 
		  else if (Input.GetKey (moveN)) {
			rb2d.velocity = Vector2.up * playerSpeed;
		} else if (Input.GetKey (moveS)) {
			rb2d.velocity = Vector2.down * playerSpeed;
		} else if (Input.GetKey (moveE)) {
			rb2d.velocity = Vector2.right * playerSpeed;
		} else if (Input.GetKey (moveW)) {
			rb2d.velocity = Vector2.left * playerSpeed;
		} 
		else if (Input.GetKey (strafeL)){
		  strafing = true;
		  switch(currentAngle){
			case 0:
				rb2d.velocity = Vector2.left * playerSpeed;
				break;
			case 1:
				rb2d.velocity = new Vector2 (-1, -1) * playerSpeed;
				break;
			case 2:
				rb2d.velocity = Vector2.down * playerSpeed;
				break;
			case 3:
				rb2d.velocity = new Vector2 (1, -1) * playerSpeed;
				break;
			case 4:
				rb2d.velocity = Vector2.right * playerSpeed;
				break;
			case 5:
				rb2d.velocity = new Vector2 (1, 1) * playerSpeed;
				break;
			case 6:
				rb2d.velocity = Vector2.up * playerSpeed;
				break;
			case 7:
				rb2d.velocity = new Vector2 (-1, 1) * playerSpeed;
				break;
			default:
				Debug.Log("ERROR! bad Angle"+ currentAngle );
				break;
			}
		}
		else if (Input.GetKey (strafeR)){
			strafing = true;
			switch(currentAngle){
			case 0:
				rb2d.velocity = Vector2.right * playerSpeed;
				break;
			case 1:
				rb2d.velocity = new Vector2 (1, 1) * playerSpeed;
				break;
			case 2:
				rb2d.velocity = Vector2.up * playerSpeed;
				break;
			case 3:
				rb2d.velocity = new Vector2 (-1, 1) * playerSpeed;
				break;
			case 4:
				rb2d.velocity = Vector2.left * playerSpeed;
				break;
			case 5:
				rb2d.velocity = new Vector2 (-1, -1) * playerSpeed;
				break;
			case 6:
				rb2d.velocity = Vector2.down * playerSpeed;
				break;
			case 7:
				rb2d.velocity = new Vector2 (1, -1) * playerSpeed;
				break;
			default:
				Debug.Log("ERROR! bad Angle"+ currentAngle );
				break;
			}
		}


		else {
			rb2d.velocity = Vector2.zero;		
		}
		if (rb2d.velocity != Vector2.zero && !strafing) {
			float angle = Mathf.Atan2(rb2d.velocity.x, rb2d.velocity.y) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
		}
		//Debug.Log("Current rotation z: "+transform.eulerAngles.z);

	}

	public void setHealth(float health){
		this.health = health;
	}
	public void setSpeed(float speed){
		this.speed = speed;
	}


}

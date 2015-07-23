using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	public KeyCode moveN;
	public KeyCode moveS;
	public KeyCode moveE;
	public KeyCode moveW;
	public KeyCode strafeL;
	public KeyCode strafeR;

	/*
	 * ATTACKING
	 */
	//Attack rate
	public float attackRate = 1f;
	//Attack, which attack
	bool[] attack = new bool[2];
	//Attack timer. The number of attacks
//	float[] attackTimer = new float[2];
	// timesPressed (Number of times the items the attack was pressed
//	int[] timesPressed = new int[2];

	/* MOVING */
	bool isMoving = false;


	//Rigidbody2D
	Rigidbody2D rb2d;
	//Animator
	Animator m_Anim;
	//Speed

	float playerSpeed = 4f;

	/*Key combinations*/
	KeyCode moveNW;
	KeyCode moveSW;
	KeyCode moveNE;
	KeyCode moveSE;
	bool facingRight = true;



	void flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	//When we attack what happens to the characters we are attacking?
	void updateAttack1(){

		if (Input.GetButtonDown ("Fire1")) {
			StartCoroutine (attackAnimation1 ("HomerAttack1"));
			//attack [0] = true;
			//attackTimer [0] = 0;
			//timesPressed [0]++;
			/*
			if (attack [0]) {
		
				attackTimer [0] += Time.deltaTime;
				if (attackTimer [0] > attackRate || timesPressed [0] >= 2) {
			
					attackTimer [0] = 0;
					attack [0] = false;
					timesPressed [0] = 0;

				}
			}
			*/

		} 
	}

	IEnumerator attackAnimation1(string hitAnim)
	{
		
		float time = 0f;
		RuntimeAnimatorController ac = m_Anim.runtimeAnimatorController;    //Get Animator controller
		for(int i = 0; i<ac.animationClips.Length; i++)                 //For all animations
		{
			if(ac.animationClips[i].name == hitAnim)        //If it has the same name as your clip
			{
				time = ac.animationClips[i].length;
			}
		}
		attack [0] = true;
		yield return new WaitForSeconds(time);
		attack [0] = false;
		yield break;
	}

	void updateMovement(){
		float currentAnglef =  Mathf.Round (transform.eulerAngles.z) / 45f;
		int currentAngle = (int)currentAnglef;
		//bool strafing = false;
		if (Input.GetKey (moveN) && Input.GetKey (moveE)) {
			rb2d.velocity = new Vector2 (1, 1) * playerSpeed;
			if (!facingRight)
				flip ();
		} else if (Input.GetKey (moveN) && Input.GetKey (moveW)) {
			rb2d.velocity = new Vector2 (-1, 1) * playerSpeed;
			if (facingRight)
				flip ();
		} else if (Input.GetKey (moveS) && Input.GetKey (moveE)) {
			rb2d.velocity = new Vector2 (1, -1) * playerSpeed;
			if (!facingRight)
				flip ();
		} else if (Input.GetKey (moveS) && Input.GetKey (moveW)) {
			rb2d.velocity = new Vector2 (-1, -1) * playerSpeed;
			if (facingRight)
				flip ();
		} else if (Input.GetKey (moveN)) {
			rb2d.velocity = Vector2.up * playerSpeed;
		} else if (Input.GetKey (moveS)) {
			rb2d.velocity = Vector2.down * playerSpeed;
		} else if (Input.GetKey (moveE)) {
			rb2d.velocity = Vector2.right * playerSpeed;
			if (!facingRight)
				flip ();
		} else if (Input.GetKey (moveW)) {
			rb2d.velocity = Vector2.left * playerSpeed;
			if (facingRight)
				flip ();
		} else if (Input.GetKey (strafeL)) {
			//strafing = true;
			switch (currentAngle) {
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
				Debug.Log ("ERROR! bad Angle" + currentAngle);
				break;
			}
		} else if (Input.GetKey (strafeR)) {
			//strafing = true;
			switch (currentAngle) {
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
				Debug.Log ("ERROR! bad Angle" + currentAngle);
				break;
			}
		} else {
			rb2d.velocity = Vector2.zero;
		}
		if (rb2d.velocity != Vector2.zero) {
			isMoving = true;
			
		} else {
			isMoving = false;
		}
		
		//Object rotation .. Not for platform game. Maybe for topDown versions.
		/*
		if (rb2d.velocity != Vector2.zero && !strafing) {
			float angle = Mathf.Round(Mathf.Atan2(rb2d.velocity.x, rb2d.velocity.y) * Mathf.Rad2Deg);
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
		}
		*/
	}

	private void Awake()
	{
		
		m_Anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {

	} 
	
	// Update is called once per frame
	void Update () {
		updateAttack1 ();
		updateMovement ();
		updateAnimator ();
//		Debug.Log (attack[0]);
	}

	void updateAnimator(){
	
		m_Anim.SetBool ("Walk", isMoving);
		m_Anim.SetBool ("Attack1", attack[0]);

	}
}

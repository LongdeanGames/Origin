using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public float health = 100;
	public float speed = 1;
	public string colour = "Red"; // replace with type object with animation details
	public Vector3  spawnLocation = new Vector3 (0f,0f,0f);
	public float spawnTime = 0f; //delay before the enemy appears.
	public Transform targetPlayer;

	//Rigidbody2D
	Rigidbody2D rb2d;
	//Animator
	Animator m_Anim;
	//HitBox
	BoxCollider2D tp_hitBox;

	//Movement
	bool isMoving = false;
	//Hit
	bool isHit = false;
	//Dead
	bool isDead = false;
	//Can Attack
	bool canAttack = false;


	bool facingRight = true;
	private bool _inCombat;

	public void enterCombat(){
		_inCombat = true;
	}
	public void exitCombat(){
		_inCombat = false;
	}
	public void damage(int damage){
		health = health - damage;
		Debug.Log ("Enemy damaged. Health is now "+health);
		StartCoroutine (hitAnimation1 ("BartHit"));
	}

	public void die(){

		if (health <= 0) {
			StartCoroutine(die("BartDie"));
			//Destroy (this);
		}
	
	}

	IEnumerator die(string hitAnim)
	{
		canAttack = false;
		float time = 0f;
		RuntimeAnimatorController ac = m_Anim.runtimeAnimatorController;    //Get Animator controller
		for(int i = 0; i<ac.animationClips.Length; i++)                 //For all animations
		{
			if(ac.animationClips[i].name == hitAnim)        //If it has the same name as your clip
			{
				time = ac.animationClips[i].length;
			}
		}
		isDead = true;
		yield return new WaitForSeconds(time);
		Destroy (gameObject);
		yield break;
	}


	IEnumerator hitAnimation1(string hitAnim)
	{

		canAttack = false;
		float time = 0f;
		RuntimeAnimatorController ac = m_Anim.runtimeAnimatorController;    //Get Animator controller
		for(int i = 0; i<ac.animationClips.Length; i++)                 //For all animations
		{
			if(ac.animationClips[i].name == hitAnim)        //If it has the same name as your clip
			{
				time = ac.animationClips[i].length;
			}
		}
		isHit = true;
		yield return new WaitForSeconds(time);
		isHit = false;
		yield break;
	}

	void flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void updateMoevement(){
		if (_inCombat) {
			rb2d.velocity = Vector2.zero;
			isMoving = false;
			canAttack = true;
			return;
		}
		Vector3 directionToPlayer = targetPlayer.position - transform.position;	
		
		if (directionToPlayer.x < 0 && facingRight) {
			flip ();
		} else if (directionToPlayer.x > 0 && !facingRight) {
			flip ();
		}
		rb2d.velocity = directionToPlayer * speed;
		rb2d.velocity = new Vector2(Mathf.Round (rb2d.velocity.x), Mathf.Round (rb2d.velocity.y));
		if (rb2d.velocity != Vector2.zero) {
			isMoving = true;
		} else {
			isMoving  = false;
		}
	}

	private void Awake()
	{
		
		m_Anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		transform.position = spawnLocation;
	}

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		updateMoevement ();
		setAnimiations ();
		die ();


	}
	void setAnimiations(){
		m_Anim.SetBool("Walk", isMoving);
		m_Anim.SetBool("Hit", isHit);
		m_Anim.SetBool("Die", isDead);
		m_Anim.SetBool("Attack", canAttack);
	
	}

}

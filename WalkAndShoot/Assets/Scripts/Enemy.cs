using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public float health = 1;
	public float speed = 1;
	public string colour = "Red"; // replace with type object with animation details
	public Vector3  spawnLocation = new Vector3 (0f,0f,0f);
	public float spawnTime = 0f; //delay before the enemy appears.
	public Transform targetPlayer;

	//Rigidbody2D
	Rigidbody2D rb2d;

	public Enemy (float health, float speed, string colour, Vector3 spawnLocaiton, float spawnTime)
	{
		this.health = health;
		this.speed = speed;
		this.colour = colour;
		this.spawnLocation = spawnLocation;
		this.spawnTime = spawnTime;
	}

	// Use this for initialization
	void Start ()
	{
		transform.position = spawnLocation;
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 directionToPlayer = targetPlayer.position - transform.position;	
		rb2d.velocity = directionToPlayer * speed;
		if (rb2d.velocity != Vector2.zero) {
			float angle = Mathf.Round(Mathf.Atan2(rb2d.velocity.x, rb2d.velocity.y) * Mathf.Rad2Deg);
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
		}
	}



}

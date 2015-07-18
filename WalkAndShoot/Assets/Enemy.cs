using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	float health;
	float speed;
	string colour;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setHealth(float health){
		this.health = health;
	}
	public void setSpeed(float speed){
		this.speed = speed;
	}



}

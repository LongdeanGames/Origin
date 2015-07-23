using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class attackBox : MonoBehaviour {

	BoxCollider2D col;

	void Start(){
		col = GetComponent<BoxCollider2D> ();
		Debug.Log("Trigger: " + col.isTrigger);
	}
	List<GameObject> enemies = new List<GameObject>();

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){
		Enemy enemy = (Enemy) other.GetComponent(typeof(Enemy));
		if (enemy != null) {
			enemy.enterCombat ();
			enemies.Add (other.gameObject);
		}
	} 
	void OnTriggerExit2D(Collider2D other){
		Enemy enemy = (Enemy) other.GetComponent(typeof(Enemy));
		if (enemy != null) {
			enemy.exitCombat ();
			enemies.Remove (other.gameObject);
		}

	} 
	void OnTriggerStay2D(Collider2D other){
	} 
	
	void OnCollisionEnter2D(Collision2D collision){
	} 

	void Update(){
		if (Input.GetButton ("Fire1")) {
			attack1();
		}
		/*
		if (Input.GetButtonUp ("Fire1")) {
			clearAttack();		
		}*/


	}
	void attack1(){
	
		//Debug.Log ("Number of targets: " + enemies.Count);
		foreach(GameObject go in enemies){
			if(go != null){
				Enemy enemy = (Enemy) go.GetComponent(typeof(Enemy));
			if(enemy != null)
				enemy.damage(10);
			else Destroy(go);
			}
		}
		//Get Objects in the hit box
		//Do Damage to each object of type Enemy.

	}

	/*
	void clearAttack(){
		foreach(GameObject go in enemies){
			Animator anim = (Animator) go.GetComponent(typeof(Animator));
			anim.SetFloat("Hit", 0f);

		}

			
	}

	IEnumerator WaitABit()
	{
		yield return new WaitForSeconds(5);
	}


	*/
	


}

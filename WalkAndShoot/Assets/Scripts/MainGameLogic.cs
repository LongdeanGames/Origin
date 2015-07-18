using UnityEngine;
using System.Collections;

public class MainGameLogic : MonoBehaviour {

	public Camera mainCam;
	public BoxCollider2D topWall;
	public BoxCollider2D bottomWall;
	public BoxCollider2D rightWall;
	public BoxCollider2D leftWall;
	public Transform player1Location;
	public Player p;


	Sprite backgroundSprite;
	Sprite playerSprite;
	Sprite enemySprite;
	

	//Set level Boundaries (Based on color?) 



	private float findCentreX(){
		return mainCam.ScreenToWorldPoint (new Vector3 (Screen.width/2, 0f, 0f)).x;
	}
	private float findCentreY(){
		return mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height/2, 0f)).y;
	}

	private float findCentreZ(){
		return 0f;
	}

	private Vector3 getCentreVector3(){
		return new Vector3 (findCentreX(), findCentreY(), findCentreZ());
	}

	private void createLevelBoundaries(){
		topWall.size = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 2f, 0f, 0f)).x, 1f);
		topWall.offset = new Vector2 (0f, mainCam.ScreenToWorldPoint (new Vector3 ( 0f, Screen.height, 0f)).y + 0.5f);
		
		bottomWall.size = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 2, 0f, 0f)).x, 1f);
		bottomWall.offset = new Vector2 (0f, mainCam.ScreenToWorldPoint (new Vector3( 0f, 0f, 0f)).y - 0.5f);
		
		leftWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height*2f, 0f)).y);;
		leftWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);
		
		rightWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height*2f, 0f)).y);
		rightWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);

	}



	// Use this for initialization
	void Start () {

		//level boundaries
		createLevelBoundaries();

		//Set player start location
		player1Location.position = getCentreVector3 ();
		//Set player health

		p.setHealth (100f);

		//Start timer
		//Reset Score

	}
	
	// Update is called once per frame
	void Update () {



	
	}
}

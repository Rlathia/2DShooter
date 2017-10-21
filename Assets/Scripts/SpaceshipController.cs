//                    COMP3064 CRN13899 Assignment 1
//                   Submitted to: Przemyslaw Pawluk
//                      Friday, October 20, 2017        
//                   From: Rajvi Lathia  - 101034808 
//                rajvimukeshbhai.lathia@georgebrown.ca

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour {

	[SerializeField]
	private float speed = 7f;
	[SerializeField]
	private float upY = 0;
	[SerializeField]
	private float downY = 0;
	[SerializeField]
	private float leftX = 0;
	[SerializeField]
	private float rightX = 0;
	[SerializeField]
	GameObject fireball;

	private Transform _transform;
	private Vector2 _currentPos;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
	}

	void Update(){
		_currentPos = _transform.position;
		//Storing user inputs into float variables
		float userInputV = Input.GetAxis ("Vertical");//vertical movement
		float userInputH = Input.GetAxis ("Horizontal"); //horizontal movement

		if(userInputV < 0)
		{
			//if up arrow or W is pressed move up
			_currentPos -= new Vector2(0, speed);
		}
			
		if(userInputV > 0)
		{
			//if down arrow or S is pressed move down
			_currentPos += new Vector2(0, speed);
		}
		if(userInputH < 0)
		{
			//if left arrow or A is pressed move left
			_currentPos -= new Vector2(speed, 0);
		}

		if(userInputH > 0)
		{
			//if right arrow or D is pressed move right
			_currentPos += new Vector2(speed, 0);
		}

		//player shoots fireball when space or left mouse click is pressed
		if (Input.GetKeyDown("space") || Input.GetButtonDown("Fire1"))
		{
			Debug.Log("Shooting fireball");
			Instantiate(fireball).GetComponent<Transform>().position = new Vector2(_currentPos.x + 30, _currentPos.y);
		}

		CheckBounds ();
		_transform.position = _currentPos;
	}
	//checking boundaries of the player(Spaceship)
	private void CheckBounds() {

		if (_currentPos.y < upY) {
			_currentPos.y = upY;
		}

		if (_currentPos.y > downY) {
			_currentPos.y = downY;
		}

		if (_currentPos.x < leftX) {
			_currentPos.x = leftX;
		}

		if (_currentPos.x > rightX) {
			_currentPos.x = rightX;
		}
	}
}
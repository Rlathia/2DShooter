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

	private Transform _transform;
	private Vector2 _currentPos;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
	}

	// Update is called once per frame
	void Update () {

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

		CheckBounds ();
		_transform.position = _currentPos;
	}

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
//                    COMP3064 CRN13899 Assignment 1
//                   Submitted to: Przemyslaw Pawluk
//                      Friday, October 20, 2017        
//                   From: Rajvi Lathia - 101034808 
//                rajvimukeshbhai.lathia@georgebrown.ca

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour {

	//private variables
	[SerializeField]
	public float speed = 20f;
	[SerializeField]
	public float position;
	//private AudioSource _enemykillSound;
	private Transform _transform;
	private Vector2 _currentSpeed;
	private Vector2 _currentPosition;

	// Use this for initialization
	void Start()
	{
		//_birdKillSound = gameObject.GetComponent<AudioSource>();
		_transform = gameObject.GetComponent<Transform>();
		Reset();
	}

	//resets the position of bullet
	public void Reset()
	{
		_currentSpeed = new Vector2(speed, 0);
	}
		
	// Update is called once per frame
	void Update()
	{
		_currentPosition = _transform.position;
		_currentPosition += new Vector2(speed, 0);

		//if the fireball goes out of bound, then it will destroy itself
		if (_currentPosition.x >= 730)
		{
			Destroy(gameObject);
		}
		_transform.position = _currentPosition;
	}

	//collision method is invoked when fireball collides
	public void OnTriggerEnter2D(Collider2D other)
	{
		//if fireball collides with enemy, player gets extra 20 points
		//enemy and fireball is destroyed
		if (other.gameObject.tag.Equals("Enemyship"))
		{
			Debug.Log ("Fireball with enemy");
			/*if (_birdKillSound != null)
			{
				//_birdKillSound.Play();
			}*/
			Player.Instance.Score += 50;
			other.gameObject.GetComponent<EnemyshipController> ().Reset ();
			Destroy (gameObject);
		}
	}
}
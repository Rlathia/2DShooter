//                    COMP3064 CRN13899 Assignment 1
//                   Submitted to: Przemyslaw Pawluk
//                      Friday, October 20, 2017        
//                   From: Rajvi Lathia  - 101034808 
//                rajvimukeshbhai.lathia@georgebrown.ca

//referenced from MailPilot lab project by Przemyslaw Pawluk
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipCollision : MonoBehaviour {

	[SerializeField]
	GameController explosion;

	private AudioSource _starSound;


	// Use this for initialization
	void Start () {
		_starSound = gameObject.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
	}

	public void OnTriggerEnter2D(Collider2D other){
		//check if spaceship collided with star
		if (other.gameObject.tag.Equals ("Star")) {
			Debug.Log ("Collision star\n");
			other.gameObject.GetComponent<EnemyshipController> ().Reset ();//after collision with star, star disappears.
			//add points
			Player.Instance.Score += 10;
			if (_starSound != null) {
				//_starSound.Play ();
			}
			//check if spaceship collided with enemyship
		} else if (other.gameObject.tag.Equals ("Enemyship")) {
			Debug.Log ("Collision with enemyship\n");
			//Instantiate (explosion).GetComponent<Transform> ().position = other.gameObject.GetComponent<Transform> ().position;
			other.gameObject.GetComponent<EnemyshipController> ().Reset ();
			//loses life
			Player.Instance.Life -= 1;
			//loses score
			Player.Instance.Score -= 5;

			StartCoroutine("Blink");
		}

	}

	private IEnumerator Blink(){
		Color c;
		Renderer renderer = gameObject.GetComponent<Renderer> ();
		for (int i = 0; i < 3; i++) {
			for (float f = 1f; f >= 0; f -= 0.1f) {
				c = renderer.material.color;
				c.a = f;
				renderer.material.color = c;
				yield return 0.1f;
			}
			for (float f = 0f; f <= 1; f += 0.1f) {
				c = renderer.material.color;
				c.a = f;
				renderer.material.color = c;
				yield return 0.1f;
			}
		}
	}
}
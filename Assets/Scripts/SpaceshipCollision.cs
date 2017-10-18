using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipCollision : MonoBehaviour {

	// [SerializeField]
	// GameController gameController;
	[SerializeField]
	GameObject crash;

	private AudioSource _starSound;

	// Use this for initialization
	void Start () {
		_starSound = gameObject.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
	}

	public void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag.Equals ("Star")) {
			Debug.Log ("Collision star\n");
			if (_starSound != null) {
				_starSound.Play ();
			}
		// Add points
			//Player.Instance.Score+=100;
		} else if (other.gameObject.tag.Equals ("Enemyship")) {
			Debug.Log ("Collision with enemy spaceship\n");
			//Instantiate (crash).GetComponent<Transform> ().position = other.gameObject.GetComponent<Transform> ().position;
			other.gameObject.GetComponent<EnemyshipController> ().Reset ();
			//Player.Instance.Life-=1;

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
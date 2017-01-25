﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float maxDistance = 20.0f;

	[HideInInspector]
	public Vector3 direction;
	public PlayerController player;
	BoxCollider2D bc2d;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		bc2d = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Check if out of bounds
		if (Mathf.Abs (player.transform.position.x - transform.position.x) > maxDistance || Mathf.Abs (player.transform.position.y - transform.position.y) > maxDistance) {
			Destroy (gameObject);
			return;
		}
		getMovement ();
	}

	void getMovement() {
		transform.position += direction * Time.deltaTime;
	}
}
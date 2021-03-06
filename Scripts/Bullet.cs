﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float maxDistance = 20.0f;

	[HideInInspector]
	public Vector3 direction;
	public bool kill = false;

	public PersonController owner;
	public float damage = 10.0f;

	public bool passthrough = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	public void GMUpdate () {
		//Check if out of bounds
		if (Mathf.Abs (owner.transform.position.x - transform.position.x) > maxDistance 
			|| Mathf.Abs (owner.transform.position.y - transform.position.y) > maxDistance) {
			kill = true;
			return;
		}
		getMovement ();
	}

	void getMovement() {
		transform.position += direction * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.SendMessage ("ApplyDamage", damage);
			if (!passthrough) {
				kill = true;
			}
		}
		if (col.gameObject.tag == "Block") {
			kill = true;
		}
	}
}

﻿using UnityEngine;
using System.Collections;

public class enemyBullet : MonoBehaviour 
{

	public float speed;
	public static float topY = -50f;
	
	void Start()
	{
		//this mean that when bullet is created it will move forward
		rigidbody2D.velocity = transform.forward * speed;
	}
	
	void Update()
	{
		if(transform.position.y < topY)
		{
			Destroy(this.gameObject);
		}
	}
}
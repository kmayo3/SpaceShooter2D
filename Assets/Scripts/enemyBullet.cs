using UnityEngine;
using System.Collections;

public class enemyBullet : MonoBehaviour 
{

	public float speed = .3f;
	public static float topY = -25f;
	
	void Start()
	{
		//this mean that when bullet is created it will move forward
		rigidbody2D.velocity = transform.forward * speed;
	}
	
	void Update()
	{
		//if position is less than topY it will destroy object
		if(transform.position.y < topY)
		{
			//destroy objects going outside the window
			Destroy(this.gameObject);
		}
	}
}

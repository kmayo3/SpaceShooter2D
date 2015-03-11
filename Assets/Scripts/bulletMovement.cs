using UnityEngine;
using System.Collections;

public class bulletMovement : MonoBehaviour
{
	public float speed;
	public static float topY = 25f;

	void Start()
	{
		//this mean that when bullet is created it will move forward
		rigidbody2D.velocity = transform.forward * speed;
	}

	void Update()
	{
		//if position id greater than topY
		if(transform.position.y > topY)
		{
			//destroy object if outside bounds
			Destroy(this.gameObject);
		}
	}
}
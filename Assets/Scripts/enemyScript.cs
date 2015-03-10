using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour 
{

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	public GameObject AlienBullet;
	public float speed = 1f;
	public float leftAndRightEdge = 10f;
	public float directions = 0.1f;
	public float secondsBetweenShots = 1f;
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.time > nextFire) 
			{
				nextFire = Time.time + fireRate;
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			}

		Vector3 post = transform.position;
		post.x += speed * Time.deltaTime;
		transform.position = post;
		
		if(post.x < -leftAndRightEdge)
		{
			speed = Mathf.Abs(speed);
		}
		else if(post.x > leftAndRightEdge)
		{
			speed = -Mathf.Abs(speed);
		}
		
		if(post.x < -leftAndRightEdge)
		{
			speed = Mathf.Abs(speed);
		}
		else if(post.x > leftAndRightEdge)
		{
			speed = -Mathf.Abs(speed);
		}
		else if(Random.value < directions)
		{
			speed *= -1;
		}
	}
	
	void FixedUpdate()
	{
		if(Random.value < directions)
		{
			speed *= -1;
		}
	}
}

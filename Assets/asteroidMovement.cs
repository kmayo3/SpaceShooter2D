using UnityEngine;
using System.Collections;

public class asteroidMovement : MonoBehaviour 
{
	public float speed = 1f;
	public float leftAndRightEdge = 10f;
	public float directions = 0.1f;
	public float secondsBetweenShots = 1f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
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
}

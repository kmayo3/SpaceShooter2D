using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D collider)
	{
		Destroy (gameObject);
	}
}

using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour 
{
	void OnTriggerExit2D(Collider2D collider)
	{
		Destroy (collider.gameObject);
		Destroy (gameObject);
	}
}

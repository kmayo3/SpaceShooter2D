﻿using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D collider)
	{
		//destroy object
		Destroy (gameObject);
	}
}

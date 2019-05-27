using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Pickup : MonoBehaviour, IPickable {
	
	public virtual void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			// Take(collision.gameObject.GetComponent<PlayerController>());
			//Destroy(gameObject);
		}
	}

	public void Deactivate()
	{
		gameObject.GetComponent<Renderer>().enabled = false;
		gameObject.GetComponent<Collider2D>().enabled = false;
	}

	public void Activate()
	{
		gameObject.GetComponent<Renderer>().enabled = true;
		gameObject.GetComponent<Collider2D>().enabled = true;
	}

	public abstract void Take (PlayerController player);

	public abstract void Take (EnemyController enemy);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Respawn : Pickup {

	public float RespawnTime;

	public Vector3 originalPosition;
	private Vector3 actualPosition;
	public float positionVariation;

	public override void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player"){
			Deactivate();
			Relocate(originalPosition, actualPosition, positionVariation);
			Invoke("Activate", RespawnTime);
		}
	}

	public void Relocate(Vector3 OriginalPosition, Vector3 ActualPosition, float PositionVariation)
	{
		ActualPosition = OriginalPosition;
		ActualPosition = new Vector3 (Random.Range(ActualPosition.x - PositionVariation, ActualPosition.x + PositionVariation), Random.Range(ActualPosition.y - PositionVariation, ActualPosition.y + PositionVariation), transform.position.z);
		gameObject.transform.position = ActualPosition;
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Player movement
		if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < 0.5f )
		{
			transform.Translate( new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f ), Space.World);
			//Space.World makes the player move according to the world space, not where it is facing or it's rotation.
		}

		if(Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < 0.5f )
		{
			transform.Translate( new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f), Space.World);
		}

		faceMouse();
	}

	//Player face mouse position
	void faceMouse()
	{
		Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
	}

	//Player collision with pickable object
	public virtual void OnTriggerEnter2D(Collider2D collision)
	{
		IPickable pickupScript = collision.gameObject.GetComponent<IPickable>();
		if(pickupScript != null)
		{
			pickupScript.Take(this);
		}
	} 
}

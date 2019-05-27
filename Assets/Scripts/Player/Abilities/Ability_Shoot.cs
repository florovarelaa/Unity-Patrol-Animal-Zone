using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_Shoot : Ability {

	public Transform firePoint;
	private Vector3 startOfShot;
	private Vector3 endOfShot;
	private Vector3 mousePosition;

	public int damage;
	public LineRenderer lineRenderer;
	public float distance;
	
	public override void Cast()
	{
		AbilityAction();
	}

	public override void AbilityAction()
    {
    	StartCoroutine(Shoot());
    }


	IEnumerator Shoot ()
	{
		startOfShot = firePoint.position;

		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		//Vector3.Lerp(firePoint.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), distance);

		RaycastHit2D hitInfo = Physics2D.Raycast(startOfShot, mousePosition, distance);


		//Something was hit
		if (hitInfo)
		{
			EnemyController enemy = hitInfo.transform.GetComponent<EnemyController>();
			if (enemy != null)
			{
				lineRenderer.SetColors(Color.green, Color.yellow);
				enemy.HurtEnemy(damage);
			}

		} else {
				lineRenderer.SetColors(Color.magenta, Color.magenta);
		}

		//alcance maximo del disparo. Radio alrededor del firepoint.
		//ERROR
		endOfShot = ((mousePosition - startOfShot).normalized) * distance;

		//Render Shoot;
		lineRenderer.SetPosition(0, startOfShot);
		lineRenderer.SetPosition(1, endOfShot);
		// Debug.Log("xmouse " + Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
		// Debug.Log("ymouse " + Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		// Debug.Log("x =" + endOfShot.x);
		// Debug.Log("y =" + endOfShot.y);

		lineRenderer.enabled = true;

		 yield return new WaitForSeconds(0.065f);

		lineRenderer.enabled = false;
	}
}

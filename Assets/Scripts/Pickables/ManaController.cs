using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ManaController : Respawn {

	public int manaToGive;

	// Use this for initialization
	void Start () {
		originalPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, transform.position.z);
	}

	//if Taken by player, give player mana
	public override void Take (PlayerController player) {
        player.GetComponent<PlayerManaManager>().GainMana(manaToGive);
    }

	//if Taken by enemy, respawn after time
    public override void Take(EnemyController enemy){
		Deactivate();
		Invoke("Activate", 15f);
	}
}

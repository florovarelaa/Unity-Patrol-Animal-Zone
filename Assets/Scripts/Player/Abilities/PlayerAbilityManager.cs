using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityManager : MonoBehaviour {

	public Ability[] playerAbilities = new Ability[5];
	
	public GameObject allAbilities;

	//public GameObject allAbilities;

	// Use this for initialization
	//void Awake(){

	void Start () {

		for(int i=0; i < playerAbilities.Length ; i++){
			if( allAbilities.GetComponent<Abilities>().abilities[i] != null)
			{
				playerAbilities[i] = allAbilities.GetComponent<Abilities>().abilities[i];
			}
		}			
	}
	
	// Update is called once per frame
	void Update () {

		 if (Input.GetKeyDown("space"))
            playerAbilities[0].Cast();

		 if (Input.GetKeyDown("1"))
            playerAbilities[1].Cast();
		
		 if (Input.GetKeyDown("2"))
            playerAbilities[2].Cast();

		 if (Input.GetKeyDown("3"))
            playerAbilities[3].Cast();

		 if (Input.GetKeyDown("4"))
            playerAbilities[4].Cast();	
	}

	public int RandomInactiveAbility(){
		int inactiveAbility = -1;
		int i = -1;
		int cont = 1;
		while (inactiveAbility == -1 && cont < playerAbilities.Length)
		{
			i = Random.Range(1, playerAbilities.Length);
			if(playerAbilities[i].active != true){
				inactiveAbility = i;
			} else {
				cont++;
			}
		}
		return i; 
	}
}

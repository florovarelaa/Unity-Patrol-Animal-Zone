using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManaManager : MonoBehaviour {

	public int playerMaxMana;
	public int playerCurrentMana;
	public int initialMana;

	// Use this for initialization
	void Start () {
		
		SetInitialMana();

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void GainMana(int manaToGain)
	{
		if(playerCurrentMana + manaToGain > playerMaxMana)
		{
			playerCurrentMana = playerMaxMana;
		} else
		{
			playerCurrentMana += manaToGain;
		}
	}

	public void SetInitialMana()
	{
		playerCurrentMana = initialMana;
	}
}

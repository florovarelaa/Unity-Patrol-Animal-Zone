using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour {

	public int playerMaxHealth;
	public int playerCurrentHealth;
	private bool isDead;

	// Use this for initialization
	void Start () {
		
		SetMaxHealth();

	}
	
	// Update is called once per frame
	void Update () {
		
		if(playerCurrentHealth <= 0)
		{
			Die();
		}
	}

	public void HurtPlayer(int damage)
	{	
		if(playerCurrentHealth - damage > 0){
			playerCurrentHealth -= damage;
		} else {
			playerCurrentHealth = 0;
			Die();
		}
	}

	public void HealPlayer(int healing)
	{
		if(playerCurrentHealth + healing > playerMaxHealth)
		{
			SetMaxHealth();
		} else {
			playerCurrentHealth += healing;
		}
	}

	private void Die()
	{
		isDead = true;
		Time.timeScale = 0;
	}

	public void SetMaxHealth()
	{
		playerCurrentHealth = playerMaxHealth/2;
	}
}

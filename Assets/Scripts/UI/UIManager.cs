using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Slider healthBar;
	public Text hpText;

	public Slider manaBar;
	public Text manaText;

	public GameObject player;

	public Image[] actionBarImages = new Image[5];
	public Image[] actionBarImagesCD = new Image[5];
	public Image[] actionBarImagesActive = new Image[5];

	// Use this for initialization
	void Start () {
		for(int i = 0; i < actionBarImages.Length; i++)
		{
			if(player.GetComponent<PlayerAbilityManager>().playerAbilities[i] != null)
			{
				actionBarImages[i].sprite = player.GetComponent<PlayerAbilityManager>().playerAbilities[i].abilityIcon;
				actionBarImagesCD[i].sprite = player.GetComponent<PlayerAbilityManager>().playerAbilities[i].abilityIcon;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		healthBar.maxValue = player.GetComponent<PlayerHealthManager>().playerMaxHealth;
		healthBar.value = player.GetComponent<PlayerHealthManager>().playerCurrentHealth;
		hpText.text = "HP: " + player.GetComponent<PlayerHealthManager>().playerCurrentHealth + "/" + player.GetComponent<PlayerHealthManager>().playerMaxHealth;

		manaBar.maxValue = player.GetComponent<PlayerManaManager>().playerMaxMana;
		manaBar.value = player.GetComponent<PlayerManaManager>().playerCurrentMana;
		manaText.text = "Mana: " + player.GetComponent<PlayerManaManager>().playerCurrentMana + "/" + player.GetComponent<PlayerManaManager>().playerMaxMana;
		
		for(int i = 1; i<player.GetComponent<PlayerAbilityManager>().playerAbilities.Length; i++)
		{
			if(player.GetComponent<PlayerAbilityManager>().playerAbilities[i].active)
			{
				actionBarImagesActive[i].color = Color.green;
			} else {
				actionBarImagesActive[i].color = Color.red;
			}

			actionBarImagesCD[i].fillAmount = player.GetComponent<PlayerAbilityManager>().playerAbilities[i].cooldownRemaining/player.GetComponent<PlayerAbilityManager>().playerAbilities[i].cooldown;
		}
	}
}

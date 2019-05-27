using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class GameController : MonoBehaviour {
   // Declare any public variables that you want to be able 
   // to access throughout your scene
   public PlayerHealthManager playerHealth;
   public PlayerController playerController;
   public PlayerAbilityManager playerAbility;
   public PlayerManaManager playerMana;

   public static GameController Instance { get; private set; } // static singleton
   void Awake() {
         if (Instance == null) { Instance = this;  }
         else { Destroy(gameObject); }
         // Cache references to all desired variables
        playerHealth = FindObjectOfType<PlayerHealthManager>();
		playerController = FindObjectOfType<PlayerController>();
		playerAbility = FindObjectOfType<PlayerAbilityManager>();
		playerMana = FindObjectOfType<PlayerManaManager>();
	}
}
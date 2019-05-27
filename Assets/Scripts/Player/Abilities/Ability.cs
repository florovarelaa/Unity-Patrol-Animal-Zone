using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ability: MonoBehaviour{
    
    public string abilityName = "New Ability";
    public string abilityDescription = "Ability Description";
    public Sprite abilityIcon;
	public int manaCost;
    public GameObject abilityText;
    public float cooldown;
    public float cooldownRemaining;
    [HideInInspector] public bool active = false;

    public PlayerController player;

    //Casts the ability if not on cooldown and player has enough mana.
    public virtual void Cast()
    {
        if(active)
        {
            if(!OnCooldown(this))
            {    
                if(player.GetComponent<PlayerManaManager>().playerCurrentMana >= manaCost)
                {
                    AbilityAction();
                    player.GetComponent<PlayerManaManager>().playerCurrentMana -= manaCost;
                    cooldownRemaining = cooldown;
                    active = false;
                } else {
                    if(abilityText){
                        ShowMissingMana();
                    }
                }
            } else{
                ShowAbilityOnCooldown();
            }

        } else{
            ShowAbilityNotActive();
        }
    }

    public bool OnCooldown(Ability ability)
    {
        if(ability.cooldownRemaining > 0)
        {
            return(true);
        } else {
            return(false);
        }
    }

    public abstract void AbilityAction();


    void FixedUpdate() {

        if(OnCooldown(this))
        {
            cooldownRemaining -= Time.deltaTime;
        }        

    }

    void ShowMissingMana()
    {
        var go = Instantiate(abilityText, player.GetComponent<PlayerController>().transform.position, Quaternion.identity, player.GetComponent<PlayerController>().transform);
        go.GetComponent<TextMesh>().text = manaCost-player.GetComponent<PlayerManaManager>().playerCurrentMana + " mana missing";
    }

    void ShowAbilityOnCooldown()
    {
        var go = Instantiate(abilityText, player.GetComponent<PlayerController>().transform.position, Quaternion.identity, player.GetComponent<PlayerController>().transform);
        go.GetComponent<TextMesh>().text = abilityName + " is on cooldown";
    }
    
    void ShowAbilityNotActive()
    {
        var go = Instantiate(abilityText, player.GetComponent<PlayerController>().transform.position, Quaternion.identity, player.GetComponent<PlayerController>().transform);
        go.GetComponent<TextMesh>().text = abilityName + " is not active";
    }

}
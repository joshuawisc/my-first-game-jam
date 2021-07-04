using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Consumables
{

    public override void Interact()
    {
        //upon inter action use it
        //TODO: May need to add an option to store it
        Use();
    }

    public override void Use()
    {
        //hard coded effect
        //add 10 HP
        //TODO: May need to add a heal method to damageable instead of just reversing damage
        player.Damage(-10);
    }
    private void Start()
    {
        base.Initialize();

        this.Name = "Health Potion";
        this.Description = "+10 HP";
    }
}

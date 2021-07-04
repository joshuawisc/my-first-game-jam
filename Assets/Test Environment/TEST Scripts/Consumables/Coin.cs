using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Consumables
{
    public override void Interact()
    {
        Use();
    }

    public override void Use()
    {
        player.addGold(1);
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();

        this.Name = "Gold Coin";
        this.Description = "+1 Gold";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

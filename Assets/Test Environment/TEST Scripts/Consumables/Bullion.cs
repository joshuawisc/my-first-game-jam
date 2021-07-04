using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullion : Consumables
{
    public override void Interact()
    {
        Use();
    }

    public override void Use()
    {
        player.addGold(10);
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();

        this.Name = "Gold Bullion";
        this.Description = "+10 Gold";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

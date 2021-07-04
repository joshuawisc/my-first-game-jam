using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : Consumables
{
    public override void Interact()
    {
        //TODO: make player hold it instead of use it directly
        Use();
    }

    public override void Use()
    {
        player.Damage(-50);
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();

        this.Name = "Medkit";
        this.Description = "+50 HP";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

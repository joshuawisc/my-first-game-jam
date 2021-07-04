using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRusty : Consumables
{
    public override void Interact()
    {
        Use();
    }

    public override void Use()
    {
        player.addKey(1);
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();

        this.Name = "Rusty Key";
        this.Description = "+1 Key";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

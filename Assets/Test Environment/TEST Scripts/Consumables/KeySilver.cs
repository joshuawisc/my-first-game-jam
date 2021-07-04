using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySilver : Consumables
{
    public override void Interact()
    {
        Use();
    }

    public override void Use()
    {
        player.addKey(2);
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();

        this.Name = "Silver Key";
        this.Description = "+2 Keys";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

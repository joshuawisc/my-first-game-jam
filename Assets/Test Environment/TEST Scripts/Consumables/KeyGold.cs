using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGold : Consumables
{
    public override void Interact()
    {
        Use();
    }

    public override void Use()
    {
        player.addKey(5);
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();

        this.Name = "Gold Key";
        this.Description = "+5 Keys";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Xml;
using UnityEngine;

/*
 * Public interface for any Interactable object in scene
 * Needs an Interact Key, Type, and Interact function that accepts a game world object
 * Example: Door interact(gameworld) -> set self.open to true/false
 * Example: Item.Interact(gameworld) -> find player, give instance of self to player, delete self
 * 
 */
public interface IInteractable
{
    // Interactable env objects: 
    // Dropped items(like hearts, bandages), locked doors, npc merchants etc

    // Primary Key, ReadOnly, Created on Instantiation
    string InstanceID { get; }

    // Type of the interactible
    string Type { get; }

    // Displayed Name of the Item
    string Name { get; }

    // Text Displayed when hovering with the mouse/aimed with the reticle for 1sec
    string Description { get; }

    // Decides the spawn weight of the item, with 0 being the lowest tier - very common, while 4 being the highest
    int Rarity { get; }

    // Can be interacted by touching it/ walking into it
    bool InteractTouching { get; set; }

    // Can be interacted by pressing the hoitkey while aiming at it
    bool InteractHotKey { get; set; }

    // Spawn adds instance to world, might run Anim Data
    void Spawn(Vector3 input);

    //What it does when player interact with it
    void Interact();
}

/*
 * Public interface for anything that can be attacked and damaged. 
 * Needs specification of what attacks can damage it.
 * Example: door is damageable by player attacks only
 * Needs a Damage() function -> when damaged by an attack incur an effect
 * 
 */
public interface IDamageable
{
    //Can it be destroyed by Explosion
    bool ExplosionDestructible { get; set; }

    //Can it be destroyed by Player's PrimaryFire
    bool PrimaryFireDestructible { get; set; }

    // Will it block player's movement/ Or can player just walk through it
    bool BlocksMovement { get; set; }

    // Will it block player's or enemy's bullets
    bool BlocksBullets { get; set; }

    // Things in the game that can recieve damage from attacks
    void Damage();

    //What it does when destroyed by player
    void OnDestroy();
}

/*
 * Public interface for item data. 
 * Can be Active/Passive
 * Picking up the item in the world will give player the item
 */
public interface IItem 
{
    // Item ID, the unique identifier for each item
    string ItemID { get; }

    // Displayed Name of the Item
    string Name { get; }

    // Tooltip Text of the item
    string Description { get; }

    // Decides the spawn weight of the item, with 0 being the lowest tier - very common, while 4 being the highest
    int Rarity { get; }

    // Determines wether is item is activated by the hotkey and uses cooldown
    bool IsActive { get; }

    // The cooldown in seconds remaining before the item can be used again
    float CurrentCoolDown { get; set; }

    // The cooldown in seconds for the item
    float MaxCoolDown { get; set; }

    // Upon picking up the item
    // For active items, replace player's current active skill
    // For passive items, could be stat changes or other effects
    void OnPickup();
     
    // For active items only
    // Activates item's effect
    void OnUse();

    // Upon Dropping the item
    // For active items: Can be called when replacing the current active item
    // For passive items: Undo the stat change/other effects
    void OnDrop();
}
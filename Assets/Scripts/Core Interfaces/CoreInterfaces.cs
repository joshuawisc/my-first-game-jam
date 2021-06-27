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
    // Dropped items, locked doors, npc merchants etc
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
    // Things in the game that can recieve damage from attacks
    void Damage();
}

/*
 * Public interface for item data. 
 */
public interface IItem 
{
    // Items 
}
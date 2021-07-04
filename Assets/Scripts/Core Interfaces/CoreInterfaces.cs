using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Xml;
using UnityEngine;

/* General Interface
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

    // In Game Object
    GameObject InGameObject { get; }

    // Primary Key, ReadOnly, Created on Instantiation
    string InstanceID { get; }

    // Type of the interactible
    string Type { get; }

    // Displayed Name of the Item
    string Name { get; }

    // Text Displayed when hovering with the mouse/aimed with the reticle for 1sec
    string Description { get; }

    // Spawn adds instance to world, might run Anim Data
    void Spawn(Vector3 input);

    // Despawn instance from world
    void Despawn();

    //What it does when player interact with it
    void Interact();
}

/* Specific Interface
 * Public interface for any game object (non item, non actor) that can be interacted with
 * Needs inGameObject with a getter method
 * 
 */
public interface IInteractableObject : IInteractable 
{
    // Apply a physics based interaction with the object
    void ApplyForce(Vector3 direction, float magnitude);

    // Set a state on the object 
    void setState(string stateID, string state);
}

/* Specific Interface
 * 
 */
public interface IInteractableCharacter : IInteractable 
{
    // TODO -> May be too early to implement this
}


/* General Interface
 * Public interface for anything that can be attacked and damaged. 
 * Needs specification of what attacks can damage it.
 * Example: door is damageable by player attacks only
 * Needs a Damage() function -> when damaged by an attack incur an effect
 * 
 */
public interface IDamageable
{
    int Health { get; set; }

    int MaximumHealth { get; set; }
    // Things in the game that can recieve damage from attacks
    void Damage(int dmg);
}

/* Specific Interface
 * Public interface for item data. 
 */
public interface IItem : IInteractable
{
    // Item ID, the unique identifier for each item
    string ItemID { get; }
    void Store();
    void Drop();

}

public interface IConsumable
{
    void Use();
}

/* General Interface
 * Public Interface for anything that can be held in hand
 */
public interface IHoldable 
{
    void Equip();
    void Use();
}

public interface IWeapon : IHoldable, IItem
{
    int baseDamage { get; set; }

    float attackSpeed { get; set; }
}

public interface IRangedWeapon : IWeapon
{
    float ReloadSpeed { get; set; }

    int MagazineSize { get; set; }

    string FXName { get; set; }
}
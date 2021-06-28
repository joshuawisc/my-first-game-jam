using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Xml;
using UnityEngine;


/*
 * Public interface for any Character. 
 * Needs basic properties like position, name, instance id
 * Needs base methods like MoveTo(), Dispose(), Spawn()
 * 
 */
public interface ICharacter 
{
    // Will be attached to any Character that plays as an actor in our game

    // Vector Position of Character
    Vector3 Position { get; set; }

    // Generic display name of character
    string Name { get; set; }

    // Primary Key, ReadOnly, Created on Instantiation
    string InstanceID { get; }

    //******Health******
    //The current HP of the player
    int Health { get; set; }
    //the Max HP of the player
    int MaxHealth { get; set; }

    //******Attack******
    //Whether this character is a melee character
    bool IsMelee { get; set; }
    //The Damage of each single bullet
    float AttackDamage { get; set; }
    //The damgage multiplier on Headshot, normally 2.0f for PC and 1.0f for NPC
    float HeadShotMult { get; set; }
    //Shot Delay in seconds between each bullet
    float ShotDelay { get; set; }
    //Reload Anim Length in seconds, NPC may have different length of reload, while player have no reload anim length
    float ReloadAnimLength { get; set; }
    //Damage Falloff Distance/Max damage distance
    float Range { get; set; }
    //How much Damage is multiplied/decreased outside of the range, typically 0.5f
    float FalloffMult { get; set; }
    //The Accuracy of the weapon they hold
    float Accuracy { get; set; }

    // Can be Overloaded. But at base construct vec3 to move object to.
    // Example: MoveTo applies a vec3 force
    // Example: MoveTo applies a vec3 position
    void MoveTo(Vector3 input);

    // Dispose destroys this instances and cleans up
    void Dispose();

    // Spawn adds instance to world, might run Anim Data
    void Spawn(Vector3 input);
}

public interface INonPlayableCharacter : ICharacter
{
    // Public interface for NPC
}


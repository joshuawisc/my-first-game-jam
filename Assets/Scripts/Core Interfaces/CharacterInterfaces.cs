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


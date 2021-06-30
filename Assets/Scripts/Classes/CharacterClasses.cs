using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Xml;
using UnityEngine;



public class GunSkeletonEnemy : INonPlayableCharacter, IDamageable
{
    #region PROPERTIES
    public Vector3 Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public string InstanceID => throw new NotImplementedException();

    public int health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int maximumHealth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int MaximumHealth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public GameObject Actor => throw new NotImplementedException();
    #endregion

    #region PUBLIC METHODS
    public void Damage(int dmg)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public void MoveTo(Vector3 input)
    {
        throw new NotImplementedException();
    }

    public void Spawn(Vector3 input)
    {
        throw new NotImplementedException();
    }
    #endregion

}


public class NonPlayableCharacterControllerState 
{

}

public class AnimationStateContainer 
{

}

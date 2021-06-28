using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Xml;
using UnityEngine;


public class PlayableCharacter : ICharacter
{
    public Vector3 Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public string InstanceID => throw new NotImplementedException();

    public int Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int MaxHealth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool IsMelee { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public float AttackDamage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public float HeadShotMult { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public float ShotDelay { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public float ReloadAnimLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public float Range { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public float FalloffMult { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public float Accuracy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
}

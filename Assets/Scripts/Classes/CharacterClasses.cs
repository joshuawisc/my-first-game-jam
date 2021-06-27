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

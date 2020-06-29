using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody) )]
public abstract class CharacterBase : MonoBehaviour
{
    [SerializeField] protected int Hp = 100;
    [SerializeField] protected int Armor = 10;

    [SerializeField, HideInInspector] protected Rigidbody Body;

    protected virtual void Reset()
    {
        Body = GetComponent<Rigidbody>();
    }

    protected abstract void Move(); 
} 
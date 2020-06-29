using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRun : MonoBehaviour
{
    [SerializeField] private float _range;
    public event Action<GameObject> Destroyed;
    private GameObject _target; 

    private void OnTriggerEnter(Collider other)
    {
        _target = other.gameObject;
        
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        Destroyed?.Invoke(_target);
    }
}

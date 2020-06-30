using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRun : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _range;
    private float _progress; 
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

    private void Move()
    {
        transform.position += transform.forward * (Time.deltaTime * _speed); // тут не могу понять как написать движение вдоль форворда пули
        _progress += Time.deltaTime * _speed;

        if (_progress >= _range)
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        Move();
    }
}

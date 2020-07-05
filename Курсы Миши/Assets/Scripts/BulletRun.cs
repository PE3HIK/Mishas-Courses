using System;
using System.Collections;
using UnityEngine;

public class BulletRun : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _range;
    private float _progress; 
    public event Action<GameObject> Destroyed;

    private IEnumerator Start()
    {
        while (_progress < _range)
        {
            yield return null;
            transform.position += transform.forward * (Time.deltaTime * _speed); // тут не могу понять как написать движение вдоль форворда 
            _progress += Time.deltaTime * _speed;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroyed?.Invoke(other.gameObject);
        Destroy(gameObject);
    }
}

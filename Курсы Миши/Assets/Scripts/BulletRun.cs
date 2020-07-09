using System;
using System.Collections;
using UnityEngine;

public class BulletRun : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _range;
    private float _progress; 
    public event Action <BulletRun, GameObject> Hited; // дженерик-ивент, с параметрами "BulletRun" и "GameObject"

    private IEnumerator Start()
    {
        while (_progress < _range)
        {
            yield return null;
            transform.position += transform.forward * (Time.deltaTime * _speed); 
            _progress += Time.deltaTime * _speed;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Hited?.Invoke(this, other.gameObject);
        Destroy(gameObject);
    }
}

using System;
using System.Collections;
using UnityEngine;

public class BulletRun : MonoBehaviour, IDamageDealer
{
    [SerializeField] private float _speed;
    [SerializeField] private float _range;
    private float _progress;

    private IDamageDealer _dealer;
    private Damage _damage;
    
    public event Action<BulletRun> Destroyed; 

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
        var recever = other.GetComponent<IDamageReceiver>();
        if (recever!= null)
        {
            DealDamage(recever, _damage);
        }
        Destroy(gameObject);
    }

    public void Initialization(IDamageDealer dealer, Damage damage)
    {
       _dealer = dealer;
       _damage = damage; 
    }

    public void DealDamage<T>(IDamageReceiver receiver, T damage) where T : Damage
    {
        _dealer.DealDamage(receiver, damage);
    }

    private void OnDestroy()
    {
        Destroyed?.Invoke(this);
    }
}

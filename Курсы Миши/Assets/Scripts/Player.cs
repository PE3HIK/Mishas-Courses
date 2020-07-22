using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(CharacterController))]
public class Player : CharacterBase, IDamageDealer, IDamageReceiver // Капсуль, двигается, может прыгать
{
    [SerializeField, HideInInspector] private CharacterController _characterController;
    [SerializeField] private float _forwardSpeed = 10f;
    [SerializeField] private float _sideSpeed = 10f;
    [SerializeField] private float _jumpHeight = 3f;
    [SerializeField] private float _rotateSpeed = 50f;
    [FormerlySerializedAs("_weapon")] [SerializeField] private BulletRun _bulletPrefab; 
    [SerializeField] private Transform _bulletSpawnPoint;

    private Dictionary<BulletRun, Damage> _activeSkills = new Dictionary<BulletRun, Damage>();

    private bool _canShoot = true; 
    
    private Vector3 _velosity;


    // Action == Method (){} 
    // Action<float> == Method (float i){}

    public void DealDamage<T>(IDamageReceiver receiver, T damage) where T : Damage
    {
        receiver.ReceiveDamage(this, damage);
    }
    public void ReceiveDamage<T>(IDamageDealer dealer, T damage) where T : Damage
    {
        var periodoicDamage = damage as ElementalDamage;
        if (periodoicDamage != null)
        {
            Hp -= periodoicDamage.amount;
        }
        else
        {
            if (damage.amount - Armor > 0)
            {
                Hp -= damage.amount - Armor;
            }
        }
    }

    protected override void Reset()
    {
        base.Reset();
        _characterController = GetComponent<CharacterController>();
    }

    protected override void Move()
    {
        var isGrounded = _characterController.isGrounded;
        var gravity = Physics.gravity.y * Time.deltaTime + _velosity.y;

        _velosity = transform.forward * (_forwardSpeed * Input.GetAxis("Vertical")) +
                    transform.right * (_sideSpeed * Input.GetAxis("Horizontal")) + 
                    new Vector3(0, gravity, 0);
        
        if (isGrounded && _velosity.y < 0)
        {
            _velosity.y = 0;
        } 

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            _velosity.y += Mathf.Sqrt(_jumpHeight * -3.0f * Physics.gravity.y);
        }

        var move = _velosity * Time.deltaTime;
        _characterController.Move(move);
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.rotation *= Quaternion.Euler(0f, -_rotateSpeed * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.rotation *= Quaternion.Euler(0f, _rotateSpeed * Time.deltaTime, 0f);
        }
    }

    private void BulletShoot()
    {
        Damage damage = null;

        if (!_canShoot) 
        {
            return;
        }

        if (Input.GetKey(KeyCode.Alpha1))
        { 
            damage= new ElementalDamage(ElementalDamageType.Fire, 10 );
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        { 
            damage= new ElementalDamage(ElementalDamageType.Air, 15 );
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        { 
            damage= new ElementalDamage(ElementalDamageType.Earth, 20 );
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        { 
            damage= new ElementalDamage(ElementalDamageType.Water, 25 );
        }

        if (damage != null)
        {
            var bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, this.transform.rotation);
            bullet.Initialization(this, damage);
            _canShoot = false; 
            bullet.Destroyed += BulletOnDestroyed;
        }
    }

    private void BulletOnDestroyed(BulletRun bullet)
    {
        _canShoot = true;
        bullet.Destroyed -= BulletOnDestroyed;
    }

    private IEnumerator TimerRoutine(Action onTimerEnd, float time) // ротина - это то, что должно быть выполенно в корутине 
    {
        var tick = 1; 

        while (time > 0)
        {
            yield return new WaitForSeconds(tick);
            time -= tick; 
        }
        
        onTimerEnd?.Invoke();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
        BulletShoot();
    }
    
    


    private int _number; 
    public int GetNumber() // get - переводится как "получить". 
    {
        return _number; 
    }

    public void SetNumber(int value) // set - переводится как "присвоить"
    {
        if (value != _number)
            _number = value;
        else
        {
            _number = 0; 
        }
    }

    public int Number
    {
        set 
        {
            if (value != _number)
                _number = value;
            else
            {
                _number = 0; 
            }
        }
    }
}
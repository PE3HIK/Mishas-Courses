using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : CharacterBase, IDamageDealer, IDamageReceiver // Капсуль, двигается, может прыгать
{
    [SerializeField, HideInInspector] private CharacterController _characterController;
    [SerializeField] private float _forwardSpeed = 10f;
    [SerializeField] private float _sideSpeed = 10f;
    [SerializeField] private float _jumpHeight = 3f;
    [SerializeField] private float _rotateSpeed = 50f;
    [SerializeField] private GameObject _weapon; 
    [SerializeField] private Transform _bulletSpawnPoint;


    
    private Vector3 _velosity;

    public void DealDamage(IDamageReceiver receiver)
    {
        receiver.ReceiveDamage(this, new Damage(15));
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
        
        if (Input.GetKeyDown(KeyCode.R))
        { 
            damage= new ElementalDamage(ElementalDamageType.Fire, 20 );
        }
    
        if (damage != null)
        {
            Instantiate(_weapon, _bulletSpawnPoint.position, this.transform.rotation ); 
        }
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
        BulletShoot();
    }
}
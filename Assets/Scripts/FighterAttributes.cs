using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FighterAttributes : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _health;
    [SerializeField] private int _stamina;
    [SerializeField] private int _damage;
    [SerializeField] private int _agility;
    [SerializeField] private int _precision;
    [SerializeField] private int _specialAttack;
    [SerializeField] private int _specialDefense;
    [SerializeField] private int _defense;
    [SerializeField] private int _speed;
    [SerializeField] public Attacks Attack1;
    [SerializeField] public Attacks Attack2;

    private int _startHealth;
    private int _startStamina;

    [SerializeField] private HealthBarUpdater _enemyHealthBar;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startHealth = _health;
        _startStamina = _stamina;

    }

    public int GetHealth() { return _health; }
    public int GetStartHealth() { return _startHealth; }
    public int GetStamina() { return _stamina; }
    public int GetStartStamina() { return _startStamina; }
    public int GetDamage() { return _damage; }
    public int GetAgility() { return _agility; }
    public int GetPrecision() { return _precision; }
    public int GetSpecialAttack() { return _specialAttack; }
    public int GetSpecialDefense() { return _specialDefense; }
    public int GetDefense() { return _defense; }
    public string GetName() { return _name; }
    public int GetSpeed() { return _speed; }

    public void ReduceHealth(int damage)
    {
        _health -= damage;
    }

    public void ReduceDamage(int nerf)
    {
        _damage -= nerf;
    }

    public void ReduceSpeed(int nerf)
    {
        _speed -= nerf;
    }

    public void ReduceStamina(int reduction)
    {
        _stamina -= reduction;
    }

    public void GainStamina()
    {
        _stamina += (_startStamina / 10);
        if (_stamina > _startStamina)
        {
            _stamina = _startStamina;
        }
    }
}

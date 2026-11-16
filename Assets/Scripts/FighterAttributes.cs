using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FighterAttributes : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private int _specialAttack;
    [SerializeField] private int _defense;
    [SerializeField] public Attacks Attack1;
    [SerializeField] public Attacks Attack2;

    private int _startHealth;

    [SerializeField] private HealthBarUpdater _enemyHealthBar;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startHealth = _health;

    }

    public int GetHealth() { return _health; }
    public int GetStartHealth() { return _startHealth; }
    public int GetDamage() { return _damage; }
    public int GetSpecialAttack() { return _specialAttack; }
    public int GetFense() { return _defense; }
    public string GetName() { return _name; }  

    public void SetHealth(int damage)
    {
        _health -= damage - (damage * (_defense / 100));
    }

    public void SetDamage(int nerf)
    {
        nerf = _damage * nerf / 100;
        _damage -= nerf;
    }
}

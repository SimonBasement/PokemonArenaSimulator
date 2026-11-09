using System;
using UnityEngine;
using UnityEngine.UI;

public class FighterAttributes : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;

    private int _startHealth;

    [SerializeField] private HealthBarUpdater enemyHealthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startHealth = _health;  
    }

    public int GetHealth()
        { return _health; }

    public int GetStartHealth()
        { return _startHealth; }

    public int GetDamage()
        { return _damage; }

    public void SetHealth(int damage)
    {
        _health -= damage;
    }

}

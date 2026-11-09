using System;
using UnityEngine;
using UnityEngine.UI;

public class FighterAttributes : MonoBehaviour
{
    private string _name;
    [SerializeField] private int _health;
    private int _startHealth;
    private int _damage;

    [SerializeField] private HealthBarUpdater enemyHealthBar;
    [SerializeField] private FighterAttributes enemyAttributes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _name = "Bulbor";
        _health = 100;
        _startHealth = _health;
        _damage = 10;
        
        
    }

    public int GetHealth()
        { return _health; }

    public int GetStartHealth()
        { return _startHealth; }


    public void Attack()
    {
        enemyAttributes._health -= _damage;
        enemyHealthBar.ValueChange();
    }
}

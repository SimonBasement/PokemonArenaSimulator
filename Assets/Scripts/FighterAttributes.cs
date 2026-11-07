using System;
using UnityEngine;
using UnityEngine.UI;

public class FighterAttributes : MonoBehaviour
{
    private string _name;
    private int _health;
    private int _startHealth;
    private int _damage;

    [SerializeField] private Slider healthBar;
    [SerializeField] private FighterAttributes enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _name = "Bulbor";
        _health = 100;
        _startHealth = _health;
        _damage = 10;
        
        
    }

    private void Update()
    {
        healthBar.value = (float)_health / _startHealth * 100;
    }

    public void Attack()
    {
        enemy._health -= _damage;
    }
}

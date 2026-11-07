using UnityEngine;

public class FighterAttributes : MonoBehaviour
{
    private string _name;
    [SerializeField] private int _health;
    private int _damage;

    [SerializeField] private FighterAttributes enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _name = "Bulbor";
        _health = 100;
        _damage = 10;
        
        
    }

    public void Attack()
    {
        enemy._health -= _damage;
    }
}

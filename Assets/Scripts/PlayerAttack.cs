using UnityEngine;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    FighterAttributes attributes;

    [SerializeField] GameObject target;
    [SerializeField] private TextMeshProUGUI _announcer;


    private FighterAttributes targetAttributes;
    private HealthBarUpdater targetHealthBar;

    public bool hasTurn;

    private void Start()
    {
        attributes = GetComponent<FighterAttributes>();

        targetAttributes = target.GetComponent<FighterAttributes>();
        targetHealthBar = target.GetComponent<HealthBarUpdater>();
    }

    public void Attack()
    {
        if (hasTurn)
        {
            int damage = CalculateDamage(attributes.Attack1.damage, attributes.GetDamage());
            targetAttributes.SetHealth(damage);
            targetHealthBar.ValueChange();
            hasTurn = false;
            _announcer.text = attributes.GetName() + " used " + attributes.Attack1.name;
        }

    }

    public int CalculateDamage(int attackDamage, int fighterDamage)
    {
        int damage = attackDamage + fighterDamage;
        return damage;
    }
}

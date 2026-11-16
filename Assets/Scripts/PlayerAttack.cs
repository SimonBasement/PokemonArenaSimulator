using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    private FighterAttributes _attributes;

    [SerializeField] private GameObject _target;
    [SerializeField] private TextMeshProUGUI _announcer;


    private FighterAttributes _targetAttributes;
    private HealthBarUpdater _targetHealthBar;

    public bool HasTurn;

    private void Start()
    {
        _attributes = GetComponent<FighterAttributes>();

        _targetAttributes = _target.GetComponent<FighterAttributes>();
        _targetHealthBar = _target.GetComponent<HealthBarUpdater>();
    }

    public void Attack1()
    {
        ExecuteAttack(_attributes.Attack1);
    }
    public void Attack2()
    {
        ExecuteAttack(_attributes.Attack2);
    }

    public void ExecuteAttack(Attacks attack)
    {
        if (HasTurn)
        {
            if (attack.AttackType == AttackType.Damage)
            {
                int damage = CalculateDamage(attack.Damage, _attributes.GetDamage());
                _targetAttributes.SetHealth(damage);
                _targetHealthBar.ValueChange();
                HasTurn = false;
                _announcer.text = _attributes.GetName() + " used " + attack.name;
            }
            if (attack.AttackType == AttackType.Nerf)
            {
                int nerf = CalculateNerf(attack.Damage, _attributes.GetSpecialAttack());
                _targetAttributes.SetDamage(nerf);
                HasTurn = false;
                _announcer.text = _attributes.GetName() + " used " + attack.name;
            }

        }
    }

    private int CalculateDamage(int attackDamage, int fighterDamage)
    {
        int damage = attackDamage + fighterDamage;
        return damage;
    }

    private int CalculateNerf(int attackNerf, int fighterSpecial)
    {
        int nerf = attackNerf + fighterSpecial;
        return nerf;
    }

}

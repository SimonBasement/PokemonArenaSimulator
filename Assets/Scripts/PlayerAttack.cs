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

    private Animator _playerAnimator;
    private Animator _targetAnimator;

    private void Start()
    {
        _attributes = GetComponent<FighterAttributes>();
        _playerAnimator = GetComponent<Animator>();

        _targetAttributes = _target.GetComponent<FighterAttributes>();
        _targetHealthBar = _target.GetComponent<HealthBarUpdater>();
        _targetAnimator = _target.GetComponent<Animator>();
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
        if (HasTurn) //Check if its the fighters turn
        {
            _playerAnimator.SetTrigger("TriggerAttackAnimation");
            if (CheckIfMissed(attack.AttackPrecision, _attributes.GetPrecision(), _targetAttributes.GetAgility())) //Check if attack missed
            {
                if (attack.AttackType == AttackType.Damage)
                {
                    int damage = CalculateDamage(attack.Damage, _attributes.GetDamage(), _targetAttributes.GetDefense());
                    _targetAttributes.ReduceHealth(damage);
                    _targetHealthBar.ValueChange();

                    HasTurn = false;
                    _announcer.text = _attributes.GetName() + " used " + attack.name;

                    _targetAnimator.SetTrigger("TriggerGotHit");
                }
                if (attack.AttackType == AttackType.Nerf)
                {
                    int nerf = CalculateNerf(attack.Damage, _attributes.GetSpecialAttack(), _targetAttributes.GetSpecialDefense());
                    _targetAttributes.ReduceDamage(nerf);
                    HasTurn = false;
                    _announcer.text = _attributes.GetName() + " used " + attack.name;
                }
            }
            else
            {
                HasTurn = false;
                _announcer.text = _attributes.GetName() + "s attack missed!";
            }


        }
    }

    private bool CheckIfMissed(int attackChance, int attackerPrecision, int targetAgility)
    {
        int hitChance = attackChance + attackerPrecision - targetAgility;
        float random = Random.Range(0, 100);
        if (hitChance  > random)
        {
            return true;
        }
        else
        { 
            return false; 
        }
    }

    private int CalculateDamage(int attackDamage, int fighterDamage, int targetDefense)
    {
        float damage = (float)attackDamage + (float)fighterDamage;
        damage = damage - (damage * ((float)targetDefense / 100));
        return (int)damage;
    }

    private int CalculateNerf(int attackNerf, int fighterSpecial, int targetSpecialDefense)
    {
        float nerf = (float)attackNerf + (float)fighterSpecial;
        nerf = nerf - (nerf * ((float)targetSpecialDefense / 100));
        return (int)nerf;
    }

}

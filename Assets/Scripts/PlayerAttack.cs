using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    FighterAttributes attributes;

    [SerializeField] GameObject target;
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
            int damage = attributes.GetDamage();
            targetAttributes.SetHealth(damage);
            targetHealthBar.ValueChange();
            hasTurn = false;
        }

    }
}

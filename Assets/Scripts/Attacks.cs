using UnityEngine;

[CreateAssetMenu(fileName = "Attacks", menuName = "Scriptable Objects/Attacks")]
public class Attacks : ScriptableObject
{
    public string AttackName;
    public int Damage;
    public int AttackPrecision;
    [SerializeField] public AttackType AttackType;
}

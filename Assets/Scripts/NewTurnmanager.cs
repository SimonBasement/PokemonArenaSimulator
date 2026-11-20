using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NewTurnmanager : MonoBehaviour
{
    [SerializeField] private GameObject[] _fighter;

    private PlayerAttack _fighterAttack;
    private FighterAttributes _fighterAttributes;

    [SerializeField] private TextMeshProUGUI _announcer;
    [SerializeField] private TextMeshProUGUI _attack1Button;
    [SerializeField] private TextMeshProUGUI _attack2Button;

    private void Update()
    {
        //get order of attacks
        _fighter = GetOrder(_fighter);
        //let fighter attack
        for(int i = 0; i < _fighter.Length; i++)
        {
            Select(_fighter[i]);
        }
    }

    public GameObject[] GetOrder(GameObject[] fighters)
    {
        GameObject[] orderedList = fighters;

        for(int i = 0; i < _fighter.Length; i++) //bubble sort
        {
            for(int j = i + 1; j <= _fighter.Length; j++)
            {
                int SpeedI = _fighter[i].GetComponent<FighterAttributes>().GetSpeed();
                int SpeedJ = _fighter[j].GetComponent<FighterAttributes>().GetSpeed();
                if (SpeedJ < SpeedI)
                {
                    GameObject temp = _fighter[i];
                    _fighter[i] = _fighter[j];
                    _fighter[j] = temp;
                }
            }
        }

        return orderedList;
    }

    private void Select(GameObject fighter)
    {
        FighterAttributes attributes = fighter.GetComponent<FighterAttributes>();
        _announcer.text = fighter.name + "s turn!";

        _attack1Button.text = attributes.Attack1.name;
        _attack2Button.text = attributes.Attack2.name;
    }
}

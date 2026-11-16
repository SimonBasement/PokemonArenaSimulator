using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerFighter;
    [SerializeField] private GameObject _enemyFighter;
    [SerializeField] private TextMeshProUGUI _announcer;

    private PlayerAttack _playerFighterAttack;
    private PlayerAttack _enemyFighterAttack;

    private FighterAttributes _playerFighterAttributes;
    private FighterAttributes _enemyFighterAttributes;

    [SerializeField] private TextMeshProUGUI _attack1Button;
    [SerializeField] private TextMeshProUGUI _attack2Button;


    void Start()
    {
        _playerFighterAttack = _playerFighter.GetComponent<PlayerAttack>();
        _enemyFighterAttack = _enemyFighter.GetComponent<PlayerAttack>();

        _playerFighterAttributes = _playerFighter.GetComponent<FighterAttributes>();
        _enemyFighterAttributes = _enemyFighter.GetComponent<FighterAttributes>();

        _playerFighterAttack.HasTurn = true;

        _announcer.text = "Fight started!";

        _attack1Button.text = _playerFighterAttributes.Attack1.name;
        _attack2Button.text = _playerFighterAttributes.Attack2.name;

    }

    private void Update()
    {

        if (!_playerFighterAttack.HasTurn)
        {
            _enemyFighterAttack.HasTurn = true;
            StartCoroutine(ExecuteTurn());
        }
    }

    IEnumerator ExecuteTurn()
    {
        yield return new WaitForSeconds(1);

        _enemyFighterAttack.Attack1();
        _playerFighterAttack.HasTurn = true;
    }

}

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

    private string _playerFighterName;
    private string _enemyFighterName;
    void Start()
    {
        _playerFighterAttack = _playerFighter.GetComponent<PlayerAttack>();
        _enemyFighterAttack = _enemyFighter.GetComponent<PlayerAttack>();

        _playerFighterAttributes = _playerFighter.GetComponent<FighterAttributes>();
        _enemyFighterAttributes = _enemyFighter.GetComponent<FighterAttributes>();

        _playerFighterName = _playerFighterAttributes.GetName();
        _enemyFighterName = _enemyFighterAttributes.GetName();

        _playerFighterAttack.hasTurn = true;

        _announcer.text = "Fight started!";

    }

    private void Update()
    {

        if (!_playerFighterAttack.hasTurn)
        {
            _enemyFighterAttack.hasTurn = true;
            StartCoroutine(ExecuteTurn());
        }
    }

    IEnumerator ExecuteTurn()
    {
        yield return new WaitForSeconds(1);

        _enemyFighterAttack.Attack();
        _playerFighterAttack.hasTurn = true;
    }

}

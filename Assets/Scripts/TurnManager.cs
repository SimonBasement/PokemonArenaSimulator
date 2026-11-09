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
    void Start()
    {
        _playerFighterAttack = _playerFighter.GetComponent<PlayerAttack>();
        _enemyFighterAttack = _enemyFighter.GetComponent<PlayerAttack>();

        _playerFighterAttack.hasTurn = true;

        _announcer.text = "Fight started!";

    }

    private void Update()
    {
        if (!_playerFighterAttack.hasTurn)
        {
            _enemyFighterAttack.hasTurn = true;
            _announcer.text = "Player attacked!";
            StartCoroutine(ExecuteTurn());

        }
    }

    IEnumerator ExecuteTurn()
    {
        yield return new WaitForSeconds(1);

        _announcer.text = "Enemy attacked!";

        _enemyFighterAttack.Attack();
        _playerFighterAttack.hasTurn = true;
    }

}

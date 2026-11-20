using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarUpdater : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Slider _staminaSlider;
    [SerializeField] private TextMeshProUGUI _healthCount;
    FighterAttributes _fighterAttributes;

    private void Start()
    {
        _fighterAttributes = GetComponent<FighterAttributes>();
        SetSlider();
        SetHealthCount();
    }

    public void ValueChange()
    {
        SetSlider();
        SetHealthCount();
    }

    private void SetSlider()
    {
        //Health Slider
        int startHelath = _fighterAttributes.GetStartHealth();
        int newHealth = _fighterAttributes.GetHealth();
        _healthSlider.value = (float)newHealth / startHelath;
        //Stamina Slider
        int startStamina = _fighterAttributes.GetStartStamina();
        int newStamina = _fighterAttributes.GetStamina();
        _staminaSlider.value = (float)newStamina / startStamina; 
    }

    private void SetHealthCount()
    {
        _healthCount.text = _fighterAttributes.GetHealth() + "/" + _fighterAttributes.GetStartHealth();
    }
}

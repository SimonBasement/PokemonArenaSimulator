using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarUpdater : MonoBehaviour
{
    [SerializeField] private Slider _slider;
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
        int startHelath = _fighterAttributes.GetStartHealth();
        int newHealth = _fighterAttributes.GetHealth();
        _slider.value = (float)newHealth / startHelath;
    }

    private void SetHealthCount()
    {
        _healthCount.text = _fighterAttributes.GetHealth() + "/" + _fighterAttributes.GetStartHealth();
    }
}

using UnityEngine;
using UnityEngine.UI;

public class HealthBarUpdater : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    FighterAttributes _fighterAttributes;

    private void Start()
    {
        _fighterAttributes = GetComponent<FighterAttributes>();
    }

    public void ValueChange()
    {
        int startHelath = _fighterAttributes.GetStartHealth();
        int newHealth = _fighterAttributes.GetHealth();
        _slider.value = (float)newHealth / startHelath;
    }
}

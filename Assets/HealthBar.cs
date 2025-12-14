using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxHealh(int maxHealh)
    {
        slider.maxValue = maxHealh;
        slider.value = maxHealh;
    }
    
    public void SetHealh(int healh)
    {
        slider.value = healh;
    }
}

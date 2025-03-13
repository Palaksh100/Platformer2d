using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image Fill;
    public TMP_Text text;
    public void SetMaxHealth(int MaxHealth){
        slider.maxValue=MaxHealth;
        SetHealth(MaxHealth);
    }
    public void SetHealth(int health){
        slider.value=health;
        Fill.color=gradient.Evaluate(slider.normalizedValue);
        text.text=string.Format("{0}/{1}",health,slider.maxValue);
    }
}

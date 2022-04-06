using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxValue(int maxValue)
    {
        slider.maxValue = maxValue;
        //slider.value = maxValue;
    }

    public void SetValue(int maxValue)
    {
        slider.value = maxValue;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}

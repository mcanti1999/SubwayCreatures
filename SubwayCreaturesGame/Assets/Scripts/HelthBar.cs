using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelthBar : MonoBehaviour
{

    public Slider slider;

    public void SetMAxHelth(int helth)
    {
        slider.maxValue = helth;
        slider.value = helth;
    }
    
    public void SetHelth(int helth)
    {
        slider.value = helth;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBar : MonoBehaviour
{
    private Slider slider;
    private bool filled = false;



    public void Init(float speed)
        {
        if (!slider)
            {
            slider = GetComponent<Slider>();

            }
        slider.maxValue = speed;
        slider.value = 0;
        filled = false;
        }
    void Update()
    {
        if (!filled)
            {
            slider.value += Time.deltaTime;
            if (slider.value >= slider.maxValue)
                {
                filled = true;
                }
            }
    }

    public void FinishBattle()
        {
        filled = true;
        }
}

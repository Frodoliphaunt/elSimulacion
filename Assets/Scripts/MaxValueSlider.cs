using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MaxValueSlider : MonoBehaviour
{
    private Slider m_Slider;
    [SerializeField] Slider planeValue;
    [SerializeField] TextMeshProUGUI m_TextMeshPro;
    void Update()
    {
        m_Slider = GetComponent<Slider>();
        m_Slider.maxValue = planeValue.value * planeValue.value/2;
    }
}

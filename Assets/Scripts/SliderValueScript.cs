using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueScript : MonoBehaviour 
{
    private Slider m_Slider;
    [SerializeField] TextMeshProUGUI m_TextMeshPro;

    void Start()
    {
        m_Slider = GetComponent<Slider>();
        m_Slider.onValueChanged.AddListener((v) =>
        {
            m_TextMeshPro.text = v.ToString("0");           
        });       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeScript : MonoBehaviour
{
    private Slider m_Slider;
    [SerializeField] TextMeshProUGUI m_TextMeshPro;
    void Start()
    {
        m_Slider = GetComponent<Slider>();
        m_Slider.onValueChanged.AddListener((v) =>
        {
            m_TextMeshPro.text = "Speed: " + v.ToString() + "x";
            Time.timeScale = m_Slider.value;
        });
    }
}

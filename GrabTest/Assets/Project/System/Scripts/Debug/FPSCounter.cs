using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text m_counterText = null;

    //helpers
    private int m_lastFrameIndex = 0;
    private float[] m_frameDeltaTimeArray = null;

    private void Awake()
    {
        m_frameDeltaTimeArray = new float[25];
    }
    private void Start()
    {
    }

    private void Update()
    {
        m_frameDeltaTimeArray[m_lastFrameIndex] = Time.deltaTime;
        m_lastFrameIndex = (m_lastFrameIndex + 1) % m_frameDeltaTimeArray.Length;

        m_counterText.text = Mathf.RoundToInt(CalculateFPS()).ToString();
    }

    private float CalculateFPS()
    {
        float total = 0.0f;
        foreach (float deltaTime in m_frameDeltaTimeArray)
        {
            total += deltaTime;
        }

        return m_frameDeltaTimeArray.Length / total;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
struct BaseColorMaterialInfo
{
    public Color m_materialColor;
    public int m_materialIndex;
}
public class BasicColorChange : MonoBehaviour
{
    [Header("MaterialsInfo")]
    [SerializeField] private BaseColorMaterialInfo[] m_materialInfos = null;
    private void Awake()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        foreach (BaseColorMaterialInfo materialInfo in m_materialInfos)
        {
            renderer.GetPropertyBlock(propertyBlock, materialInfo.m_materialIndex);

            propertyBlock.SetColor("_Color", materialInfo.m_materialColor);

            renderer.SetPropertyBlock(propertyBlock, materialInfo.m_materialIndex);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    public CubeMaterialScriptableObject cubeMaterial;

    [SerializeField] private float interval = 1.0f;
    private Renderer _renderer = null;

    public void SwitchMaterialToRed()
    {
        _renderer.material = cubeMaterial.dangerousMaterial;
    }

    public void SwitchMaterialToWhite()
    {
        _renderer.material = cubeMaterial.defaultMaterial;
    }
    public void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }
}

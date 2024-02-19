using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MaterialList : ScriptableObject
{
    public List<Material> materials;
    public List<string> statusList;

    public enum MaterialName
    {
        white,
        red,
        green,
        wall
    }
}

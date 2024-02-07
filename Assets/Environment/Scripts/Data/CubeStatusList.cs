using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CubeStatusList : ScriptableObject
{
    //Couldn't be like a tuple?
    public List<Material> materialList;
    public List<string> statusList;
}

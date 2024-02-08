using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControl : MonoBehaviour
{
    public MaterialList materialList;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "dangerous")
        {
            Debug.Log("Take Damage");
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControl : MonoBehaviour
{
    public MaterialList materialList;
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("colliding");
        if (collision.gameObject.tag == "dangerous")
        {
            Debug.Log("Take Damage");
        }
    }
}


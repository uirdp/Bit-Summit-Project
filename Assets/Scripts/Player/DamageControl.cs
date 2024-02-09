using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControl : MonoBehaviour
{
    public MaterialList materialList;


    //Maybe use ray?
    public void Get()
    {
        Debug.Log("called");
    }
    private void OnCollisionStay(Collision collision)
    {
        Get();
        if (collision.gameObject.tag == "dangerous")
        {
            //Debug.Log("Take Damage");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) { Debug.Log(transform.position); }
       
    }
}


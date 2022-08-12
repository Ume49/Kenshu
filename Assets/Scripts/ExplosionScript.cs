using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log("ExplosionScript.Start()");
        
        Destroy(this.gameObject, 0.5f);
    }
}

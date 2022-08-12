using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Michizure : MonoBehaviour
{
    private void OnDestroy() {
        var parent = transform.parent;
        
        Destroy(parent.gameObject);
    }
}

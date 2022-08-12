using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAreaScript : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other) { Debug.Log("DestroyAreaScript.OnTriggerExit2D()");
        // 領域から出たオブジェクトを消す
        Destroy(other.gameObject);
    }
}

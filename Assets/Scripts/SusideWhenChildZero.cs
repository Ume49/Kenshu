using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusideWhenChildZero : MonoBehaviour
{
    IEnumerator Start() {
        Debug.Log("SusideWhenChileZero");

        while(true){
            if(transform.childCount <= 0){
                Destroy(this.gameObject);
            }

            yield return new WaitForSeconds(0.05f);
        }
    }
}

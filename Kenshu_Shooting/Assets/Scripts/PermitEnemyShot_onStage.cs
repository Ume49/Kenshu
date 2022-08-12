using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermitEnemyShot_onStage : MonoBehaviour
{
    [SerializeField] string stageLayerName="DestroyArea";

    private void OnTriggerEnter2D(Collider2D other) { Debug.Log("PermitEnemyShot_onStage.OnTriggerEnter2D()");
        // 衝突したオブジェクトのレイヤー名を取得
        var layerName = LayerMask.LayerToName(other.gameObject.layer);

        // レイヤー名が一致するときだけ続行
        if(layerName != stageLayerName) return;
        
        var spaceShip = GetComponent<SpaceShipScript>();

        // ステージに入ったら射撃許可
        spaceShip.canShot = true;

        Debug.Log(spaceShip.canShot);
    }
}

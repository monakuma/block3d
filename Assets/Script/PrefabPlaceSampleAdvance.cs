using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Summary>
/// Prefabのオブジェクトを並べるサンプルスクリプトです。
/// </Summary>
public class PrefabPlaceSampleAdvance : MonoBehaviour
{
    // オブジェクトを生成する元となるPrefabへの参照を保持します。
    public GameObject prefabObj;

    // 生成したオブジェクトの親オブジェクトへの参照を保持します。
    public Transform parentTran;

    // マテリアルを保持します。
    public Material matCyan;
    public Material matMagenta;
    public Material matYellow;

    // オブジェクトの間隔を保持します。
    public float horizontalOffset = 1.0f;
    public float verticalOffset = 1.0f;

    // オブジェクトを並べる数を保持します。
    public int horizontalNum = 20;
    public int verticalNum = 10;

    void Start()
    {
        CreateBlockObject();
    }

    /// <Summary>
    /// Prefabからブロックとして使うオブジェクトを生成します。
    /// </Summary>
    public void CreateBlockObject()
    {
        Vector3 prefabScale = prefabObj.transform.localScale;
        float yPos = prefabScale.y / 2;

        for (int j = 0; j < verticalNum; j++)
        {
            for (int i = 0; i < horizontalNum; i++)
            {
                // ゲームオブジェクトを生成します。
                GameObject obj = Instantiate(prefabObj, Vector3.zero, Quaternion.identity);

                // ゲームオブジェクトの親オブジェクトを設定します。
                obj.transform.SetParent(parentTran);

                // ゲームオブジェクトの位置を設定します。
                float xPos = (prefabScale.x + horizontalOffset) * i;
                float zPos = (prefabScale.z + verticalOffset) * j;
                obj.transform.localPosition = new Vector3(xPos, yPos, zPos);

                // マテリアルをランダムで設定します。
                int materialId = Random.Range(0, 3);
                Material mat = matCyan;
                switch (materialId)
                {
                    case 1:
                        mat = matMagenta;
                        break;
                    case 2:
                        mat = matYellow;
                        break;
                }
                obj.GetComponent<MeshRenderer>().material = mat;
            }
        }
    }
}
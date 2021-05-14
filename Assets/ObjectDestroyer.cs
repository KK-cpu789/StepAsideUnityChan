using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// コライダーに衝突したゲームオブジェクトを破棄するスクリプトです。
public class ObjectDestroyer : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //Unityちゃんとカメラの距離
    private float difference;
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //Unityちゃんとカメラの位置（z座標）の差を求める
        this.difference = unitychan.transform.position.z - this.transform.position.z;
    }

    void Update()
    {
        //Unityちゃんの位置に合わせてカメラの位置を移動
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
    }

    /// コライダーに衝突したゲームオブジェクトを破棄します。
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("衝突しました");
        Destroy(other.gameObject);
    }
}
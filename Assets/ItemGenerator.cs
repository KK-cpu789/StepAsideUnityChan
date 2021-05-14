﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
   
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //Unityちゃんとカメラの距離
    private float difference;
    private int startPos;
    private int goalPos;
    //3秒間を計るための変数
    public float timeOut = 1;
    private float timeElapsed = 1;

    // Use this for initialization
    void Start()
    {
        
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //Unityちゃんとオブジェクトの位置（z座標）の差を求める
        this.difference = unitychan.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //スタート地点
        this.startPos = (int)unitychan.transform.position.z + 55;
        //ゴール地点
        this.goalPos = (int)unitychan.transform.position.z + 100;
        //timeElapsedに経過時間(Time.deltaTime)を加算
        timeElapsed += Time.deltaTime;
        if(startPos <= 360)
        {
            //timeElapsedが3秒(timeOut)を超えた時
            if (timeElapsed >= timeOut)
            {
                //一定の距離ごとにアイテムを生成
                for (int i = startPos; i < goalPos; i += 15)
                {
                    //どのアイテムを出すのかをランダムに設定
                    int num = Random.Range(1, 11);
                    if (num <= 2)
                    {
                        //コーンをx軸方向に一直線に生成
                        for (float j = -1; j <= 1; j += 0.4f)
                        {
                            GameObject cone = Instantiate(conePrefab);
                            cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                        }
                    }
                    else
                    {

                        //レーンごとにアイテムを生成
                        for (int j = -1; j <= 1; j++)
                        {
                            //アイテムの種類を決める
                            int item = Random.Range(1, 11);
                            //アイテムを置くZ座標のオフセットをランダムに設定
                            int offsetZ = Random.Range(-5, 6);
                            //60%コイン配置:30%車配置:10%何もなし
                            if (1 <= item && item <= 6)
                            {
                                //コインを生成
                                GameObject coin = Instantiate(coinPrefab);
                                coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                            }
                            else if (7 <= item && item <= 9)
                            {
                                //車を生成
                                GameObject car = Instantiate(carPrefab);
                                car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                            }
                        }
                    }
                    timeElapsed = 0.0f;
                }
            }
        }
        //Unityちゃんの位置に合わせてオブジェクトの位置を移動
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
    }
}
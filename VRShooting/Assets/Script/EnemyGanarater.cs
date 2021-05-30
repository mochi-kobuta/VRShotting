using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGanarater : MonoBehaviour
{
    [SerializeField] EnemyController[] enemyPrefabs; // 登場させる敵

    [SerializeField] float spawnInterval = 3.0f;
    float timer = 0f;
    

    void Start()
    {
    }

    void Update()
    {
        // タイマー更新
        timer += Time.deltaTime;

        // 出現間隔の判定
        if(spawnInterval < timer)
        {
            CreatEvemy();

            // タイマーリセット
            timer = 0f;
        }
    }

    public void CreatEvemy() {

        // 表示中でなければ敵を生成する
        var pos = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
        var parent = this.transform;

        // 生成した敵がキャラクターの方向を向くようにする
        var targetDir = transform.position - pos;
        float step = 2 * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 10.0F);
        var rotation = Quaternion.LookRotation(newDir);


        // 登録されている敵のPrefabからランダムで敵を生成
        var index = Random.Range(0, enemyPrefabs.Length);
        var enemy = Instantiate(enemyPrefabs[index], pos, rotation, parent);
        enemy.transform.LookAt(transform);
    }


    //public List<Vector3> EnemyPsitions()
    //{
        
    //    positions.Add(
    //        new Vector3(Random.Range(-5.0f, 6.0f), 0 ,Random.Range(1.0f, 7.0f)));
    //    positions.Add(
    //        new Vector3(Random.Range(-5.0f, 6.0f), 0, Random.Range(1.0f, 7.0f)));
    //    positions.Add(
    //                new Vector3(Random.Range(-5.0f, 6.0f), 0, Random.Range(1.0f, 7.0f)));
    //    positions.Add(
    //                new Vector3(Random.Range(-5.0f, 6.0f), 0, Random.Range(1.0f, 7.0f)));
    //    positions.Add(
    //                new Vector3(Random.Range(-5.0f, 6.0f), 0, Random.Range(1.0f, 7.0f)));


    //    return positions;
    //}

}

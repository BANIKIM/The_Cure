using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform[] spawnPoint;
    public SpawData[] spawData;

    int level;
    float timer;

     void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawData.Length-1);//FloorToInt �Ҽ��� �Ʒ��� ������ Int ������ �ٲٴ� �Լ�
        // CeilToInt �Ҽ��� �Ʒ��� �ø��� Int ������ �ٲٴ� �Լ�
        if (timer > spawData[level].spawnTime)
        {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {

       GameObject enemy =  GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawData[level]);
    }
}


[System.Serializable]
public class SpawData
{
    public float spawnTime;
    public int spriteType;
    public int Hp;
    public float speed;
}
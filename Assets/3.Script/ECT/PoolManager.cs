using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리펩을 보관할 변수
    public GameObject[] prefabs;

    // 풀을 담당할 리스트
    List<GameObject>[] pools;


    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        
        for(int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
        
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        //선택한 풀의 비활성화 된 게임오브젝트 접근
        foreach(GameObject item in pools[index])
        {
            if(!item.activeSelf)
            {
                //발견하면 select 변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }
        //못 찾았으면?

        if(!select)
        {
            //새로 생성하고 select 변수에 할당
            select = Instantiate(prefabs[index], transform);
            //Instantiate - 원본 오브젝트를 복제하여 장면에 생성하는 함수
            pools[index].Add(select);
        }


        return select;
    }


}

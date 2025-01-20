using Shoot;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class RocektPoolManager : MonoBehaviour
{
    [System.Serializable]
    private class RocketInfo
    {
        public int rocketIdx;
        public GameObject rocketPf;
        public int maxSize;
    }

    // Definitions
    public static RocektPoolManager instance;

    // Properties
    public bool IsReady { get; private set; }

    // Methods
    public GameObject GetGo(int goIdx)
    {
        rocketIdx = goIdx;
        return rocketPoolDic[goIdx].Get();
    }



    // Fields
    private int rocketIdx;

    private Dictionary<int, IObjectPool<GameObject>> rocketPoolDic = new();
    private Dictionary<int, GameObject> goDic = new();

    // Functions
    private void init()
    {
        IsReady = false;

        for (int idx = 0; idx < rocketInfos.Length; idx++)
        {
            IObjectPool<GameObject> pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool,
            OnDestroyPoolObject, maxSize: rocketInfos[idx].maxSize);

            if (goDic.ContainsKey(rocketInfos[idx].rocketIdx))
            {
                Debug.LogFormat("{0} Already Done.", rocketInfos[idx].rocketIdx);
                return;
            }

            goDic.Add(rocketInfos[idx].rocketIdx, rocketInfos[idx].rocketPf);
            rocketPoolDic.Add(rocketInfos[idx].rocketIdx, pool);

            for (int i = 0; i < rocketInfos[idx].maxSize; i++)
            {
                rocketIdx = rocketInfos[idx].rocketIdx;
                Poolable poolAbleGo = CreatePooledItem().GetComponent<Poolable>();
                poolAbleGo.Pool.Release(poolAbleGo.gameObject);
            }
        }

        IsReady = true;
    }
    // 생성
    private GameObject CreatePooledItem()
    {
        GameObject poolGo = Instantiate(goDic[rocketIdx]);
        poolGo.transform.SetParent(rocketPoolTR);
        poolGo.GetComponent<Poolable>().Pool = rocketPoolDic[rocketIdx];
        return poolGo;
    }

    // 대여
    private void OnTakeFromPool(GameObject poolGo)
    {
        poolGo.SetActive(true);
    }

    // 반환
    private void OnReturnedToPool(GameObject poolGo)
    {
        poolGo.SetActive(false);
    }

    // 삭제
    private void OnDestroyPoolObject(GameObject poolGo)
    {
        Destroy(poolGo);
    }



    // Unity Inspectors
    [Header("★ Bindings")]
    [SerializeField] private Transform rocketPoolTR = null;
    [SerializeField] private RocketInfo[] rocketInfos = null;



    // Unity Messages
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        init();
    }
}
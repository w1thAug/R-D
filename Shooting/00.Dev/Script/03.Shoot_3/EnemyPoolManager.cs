using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Shoot03
{
    public class EnemyPoolManager : MonoBehaviour
    {
        [System.Serializable]
        private class EnemyInfo
        {
            public int enemyIdx;
            public GameObject enemyPf;
            public int maxSize;
        }

        // Definitions
        public static EnemyPoolManager instance;

        // Properties
        public bool IsReady { get; private set; }

        // Methods
        public GameObject GetGo(int goIdx)
        {
            enemyIdx = goIdx;
            return enemyPoolDic[goIdx].Get();
        }



        // Fields
        private int enemyIdx;

        private Dictionary<int, IObjectPool<GameObject>> enemyPoolDic = new();
        private Dictionary<int, GameObject> goDic = new();

        // Functions
        private void init()
        {
            IsReady = false;

            for (int idx = 0; idx < enemyInfos.Length; idx++)
            {
                IObjectPool<GameObject> pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool,
                OnDestroyPoolObject, maxSize: enemyInfos[idx].maxSize);

                goDic.Add(enemyInfos[idx].enemyIdx, enemyInfos[idx].enemyPf);
                enemyPoolDic.Add(enemyInfos[idx].enemyIdx, pool);

                for (int i = 0; i < enemyInfos[idx].maxSize; i++)
                {
                    enemyIdx = enemyInfos[idx].enemyIdx;
                    Poolable poolAbleGo = CreatePooledItem().GetComponent<Poolable>();
                    poolAbleGo.Pool.Release(poolAbleGo.gameObject);
                }
            }

            IsReady = true;
        }
        // 생성
        private GameObject CreatePooledItem()
        {
            GameObject poolGo = Instantiate(goDic[enemyIdx]);
            poolGo.transform.SetParent(enemyPoolTR);
            poolGo.GetComponent<Poolable>().Pool = enemyPoolDic[enemyIdx];
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
        [Header("@ Bindings")]
        [SerializeField] private Transform enemyPoolTR = null;
        [SerializeField] private EnemyInfo[] enemyInfos = null;



        // Unity Messages
        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this.gameObject);

            init();
            enabled = true;
        }
    }

}
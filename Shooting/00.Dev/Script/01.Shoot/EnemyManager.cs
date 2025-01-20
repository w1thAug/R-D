using System.Collections.Generic;
using UnityEngine;

namespace Shoot
{
    public class EnemyManager : MonoBehaviour
    {
        // Fields
        private float currentTime = 0f;
        private float createTime = 0f;

        private GameObject curEnemy;
        private int rndEnemyIdx = 0;



        // Functions
        private void init()
        {
            createTime = Random.Range(minTime, maxTime);
            rndEnemyIdx = Random.Range(0, 2);
            currentTime = 0;
        }
        private void spawn()
        {
            currentTime += Time.deltaTime;

            if (currentTime > createTime)
            {
                // 랜덤으로 enemy
                int idx = Random.Range(0, spawnPoints.Length);
                curEnemy = EnemyPoolManager.instance.GetGo(rndEnemyIdx);
                curEnemy.transform.position = spawnPoints[idx].position;

                // 다음
                init();
            }
        }



        // Unity Inspectors
        [Header("★ Bindings")]
        [SerializeField] private Transform[] spawnPoints = null;
        [Header("★ Config")]
        [SerializeField] private float minTime = 0.5f;
        [SerializeField] private float maxTime = 1.5f;

        // Unity Messages
        private void Awake()
        {

        }
        private void Start()
        {
            init();
        }
        private void Update()
        {
            spawn();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame
{
	public class EnemyManager : MonoBehaviour
	{
        // Definitions
        // Properties
        public void AddEnemyPool(GameObject enemy)
        {
            enemyObjectPool.Add(enemy);
        }
        // Methods
        // Events



        // Fields : caching
        // Fields
        private float currentTime = 0f;
		private float createTime = 0f;


        private List<GameObject> enemyObjectPool = new();
		// Functions
		private void init()
		{
			createTime = Random.Range(minTime, maxTime);

			enemyObjectPool = new List<GameObject>();
			for(int i =0; i < poolSize; i++)
			{
				GameObject enemy = Instantiate(enemyFactory);
				enemy.transform.SetParent(enemyPool.transform);
				enemyObjectPool.Add(enemy);
				enemy.SetActive(false);
			}
		}
		private void spawn()
		{
			currentTime += Time.deltaTime;

			if(currentTime > createTime)
			{
				if(enemyObjectPool.Count > 0)
				{
					GameObject enemy = enemyObjectPool[0];
					enemyObjectPool.Remove(enemy);

					int idx = Random.Range(0, spawnPoints.Length);
					enemy.transform.position = spawnPoints[idx].position;
					enemy.SetActive(true);
				}

                createTime = Random.Range(minTime, maxTime);
                currentTime = 0;
            }
		}
		// Event Handlers
		// Overrides



		// Unity Inspectors
		[Header("★ Bindings")]
		[SerializeField] private GameObject enemyFactory = null;
		[SerializeField] private GameObject enemyPool = null;
        [SerializeField] private Transform[] spawnPoints = null;
        [Header("★ Config")]
		[SerializeField] private int poolSize = 10;
		[Space()]
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
        // Unity Coroutine
    }
}
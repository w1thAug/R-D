using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame
{
	public class EnemyManager : MonoBehaviour
	{
		// Definitions
		// Properties
		// Methods
		// Events



		// Fields : caching
		// Fields
		private float currentTime = 0f;

		private float minTime = 1f;
		private float maxTime = 5f;
		// Functions
		private void spawn()
		{
			currentTime += Time.deltaTime;

			if(currentTime > createTime)
			{
				GameObject enemy = Instantiate(enemyFactory);
				enemy.transform.position = transform.position;
				currentTime = 0;

                createTime = UnityEngine.Random.Range(minTime, maxTime);
            }
		}
		// Event Handlers
		// Overrides



		// Unity Inspectors
		[Header("★ Bindings")]
		[SerializeField] private GameObject enemyFactory = null;
		[Header("★ Config")]
		[SerializeField] private float createTime = 0f;

		// Unity Messages
		private void Awake()
		{
		   
		}
		private void Start()
		{
		   createTime = UnityEngine.Random.Range(minTime, maxTime);
		}
        private void Update()
        {
			spawn();
        }
        // Unity Coroutine
    }
}
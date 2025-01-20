using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Shoot
{
	public class GameManager : MonoBehaviour
	{
		// Definitions
		// Properties
		// Methods
		// Events



		// Fields : caching
		// Fields
		// Functions
		// Event Handlers
		// Overrides



		// Unity Inspectors
		[Header("★ Bindings")]
		[SerializeField] private PlayerMove player = null;
		[SerializeField] private EnemyManager enemyMgr = null;
        //[Header("★ Config")]
        //[SerializeField] private P

        // Unity Messages
        private void Awake()
		{
		   
		}
		private void Start()
		{
			StartCoroutine(crPlay());
		}

		// Unity Coroutine
		IEnumerator crPlay()
		{
			yield return null;
			// 1. 321 카운트다운
			// 2. 시작. Player 이동가능, Enemy Spawn 시작
			while (player.IsActive)
			{
				//enemyMgr.Spawn();
                yield return null;
            }

			Debug.Log("End");

			// 3. 종료시 Gameover
		}
	}
}
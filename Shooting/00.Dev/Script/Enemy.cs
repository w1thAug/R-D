using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame
{
	public class Enemy : MonoBehaviour
	{
		// Definitions
		// Properties
		// Methods
		// Events



		// Fields : caching
		// Fields
		private Vector3 dir;
		// Functions
		private void init()
		{
			int rndValue = UnityEngine.Random.Range(0, 10);
			if(rndValue < 3)
			{
				GameObject target = GameObject.Find("Player");
				dir = target.transform.position - transform.position;
				dir.Normalize();
			}
			else
			{
				//dir = Vector3.down;
				transform.position += dir * speed * Time.deltaTime;
			}
		}
		private void move()
		{
			Vector3 dir = Vector3.down;
			transform.position += dir * speed * Time.deltaTime;
		}
        // Event Handlers
        private void OnCollisionEnter(Collision other)
        {
			GameObject explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;

			GameObject scoreMgrObj = GameObject.Find("ScoreManager");
			ScoreManager scoreMgr = scoreMgrObj.GetComponent<ScoreManager>();

			scoreMgr.SetScore(scoreMgr.GetScore() + 1);

            Destroy(gameObject);
			Destroy(other.gameObject);
        }
        // Overrides



        // Unity Inspectors
		[Header("★ Bindings")]
        [SerializeField] private GameObject explosionFactory = null;
		[Header("★ Config")]
        [SerializeField] private float speed = 0f;

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
			move();
        }

        // Unity Coroutine
    }
}
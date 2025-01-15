using UnityEngine;

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
            GameObject target = GameObject.Find("Player");

            if(target != null)
            {
                int rndValue = Random.Range(0, 10);
                if (rndValue < 3)
                {
                    dir = target.transform.position - transform.position;
                    dir.Normalize();
                }
                else
                {
                    dir = Vector3.down;
                }
            }
        }
        private void move()
        {
            transform.position += dir * speed * Time.deltaTime;
        }
        // Event Handlers
        private void OnCollisionEnter(Collision other)
        {
            ScoreManager.Instance.Score++;

            GameObject explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;

            if (other.gameObject.name.Contains("Bullet"))
            {
                other.gameObject.SetActive(false);

                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
                player.AddBulletPool(other.gameObject);
            }
            else Destroy(other.gameObject);

            gameObject.SetActive(false);

            EnemyManager enemyMgr = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
            enemyMgr.AddEnemyPool(other.gameObject);
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

        }
        private void Update()
        {
            move();
        }
        private void OnEnable()
        {
            init();
            
        }

        // Unity Coroutine
    }
}
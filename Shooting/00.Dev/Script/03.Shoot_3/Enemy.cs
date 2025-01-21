using System.Collections;
using UnityEngine;

namespace Shoot03
{
    public class Enemy : Poolable
    {
        // Fields
        private Vector3 dir;
        private bool isPointPlayer = false;

        // Functions
        private void init()
        {
            if (PlayerMove.instance != null)
            {
                int rndValue = Random.Range(0, 10);
                if (rndValue < 3)
                {
                    isPointPlayer = true;
                }
                else
                {
                    isPointPlayer = false;
                }
            }
        }
        private void move()
        {
            if (isPointPlayer)
            {
                if (transform.position.y < PlayerMove.instance.Pos.y) dir = Vector3.down;
                else
                {
                    dir = PlayerMove.instance.Pos - transform.position;
                    dir.Normalize();
                }
            }
            else dir = Vector3.down;
            transform.position += dir * speed * Time.deltaTime;
        }

        // Event Handlers
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Rocket>() != null)
            {
                if (other.gameObject.GetComponent<Rocket>().Shooter == Shooter.player)
                {
                    UIManager.Instance.Score++;

                    GameObject explosion = Instantiate(explosionFx);
                    explosion.transform.position = transform.position;

                    RocketManager.instance.ReturnRocket(other.gameObject.GetComponent<Rocket>());

                    ReleaseObject();
                    other.gameObject.SetActive(false);
                }
            }
        }



        // Unity Inspectors
        [Header("@ Bindings")]
        [SerializeField] private GameObject explosionFx = null;
        [SerializeField] private Transform cannonTR = null;
        [Header("@ Configs")]
        [SerializeField] private int enemyIdx = 0;
        [Space()]
        [SerializeField] private float speed = 0.1f;
        [SerializeField] private float shootInterval = 0.1f;



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
            StartCoroutine(crFire());
        }
        private void OnDisable()
        {
            StopCoroutine(crFire());
        }

        // Unity Coroutines
        IEnumerator crFire()
        {
            yield return null;
            while (gameObject.activeSelf)
            {
                yield return new WaitForSeconds(shootInterval);

                RocketManager.instance.GetRocket(enemyIdx, Shooter.enemy);
                Rocket curRocket = RocketManager.instance.Rocket;

                if (curRocket != null)
                {
                    curRocket.transform.position = cannonTR.position;
                    curRocket.gameObject.SetActive(true);
                }

                yield return null;
            }
        }
    }
}
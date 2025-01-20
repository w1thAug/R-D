using UnityEngine;
using UnityEngine.UIElements;

namespace Shoot
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
            if(isPointPlayer)
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
            if (other.gameObject.GetComponent<Block>() == null)
            {
                ScoreManager.Instance.Score++;

                GameObject explosion = Instantiate(explosionFx);
                explosion.transform.position = transform.position;

                if (other.gameObject.GetComponent<Rocket>())
                {
                    other.gameObject.GetComponent<Rocket>().ReleaseObject();
                }

                ReleaseObject();
                other.gameObject.SetActive(false);
            }
            else Debug.Log("block");
        }



        // Unity Inspectors
        [Header("@ Bindings")]
        [SerializeField] private GameObject explosionFx = null;
        [Header("@ Configs")]
        [SerializeField] private float speed = 0.1f;



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
    }
}
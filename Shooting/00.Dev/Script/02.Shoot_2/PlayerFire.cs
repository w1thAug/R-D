using Shoot;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingGame
{
    public class PlayerFire : MonoBehaviour
    {
        // Properties
        public void AddBulletPool(GameObject bullet)
        {
            bulletObjectPool.Add(bullet);
        }



        // Fields
        private List<GameObject> bulletObjectPool;

        // Functions
        private void init()
        {
            bulletObjectPool = new List<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                GameObject bullet = Instantiate(bulletFactory);
                bullet.transform.SetParent(bulletPool.transform);
                bulletObjectPool.Add(bullet);
                bullet.SetActive(false);
            }
        }
        private void fire()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (bulletObjectPool.Count > 0)
                {
                    GameObject bullet = bulletObjectPool[0];
                    bullet.SetActive(true);
                    bulletObjectPool.Remove(bullet);

                    bullet.transform.position = fireCannonTR.position;
                }
            }
        }



        // Unity Inspectors
        [Header("★ Bindings")]
        [SerializeField] private GameObject bulletFactory = null;
        [SerializeField] private GameObject bulletPool = null;
        [SerializeField] private Transform fireCannonTR = null;
        [Header("★ Config")]
        [SerializeField] private int poolSize = 10;

        // Unity Messages
        private void Awake()
        {
            init();
        }
        private void Start()
        {

        }
        private void Update()
        {
            fire();
        }
        // Unity Coroutine
    }
}
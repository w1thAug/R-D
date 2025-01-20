using System.Collections.Generic;
using UnityEngine;

namespace Shoot
{
    public class PlayerFire : MonoBehaviour
    {
        // Properties
        public void AddBulletPool(GameObject bullet)
        {
            rocketObjectPool.Add(bullet);
        }



        // Fields
        private List<GameObject> rocketObjectPool;
        private int curRocketIdx;
        private GameObject curRocket;

        // Functions
        private void init()
        {
            curRocketIdx = 0;
        }
        private void fire()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                curRocket = RocektPoolManager.instance.GetGo(curRocketIdx);
                curRocket.transform.position = fireCannonTR.position;
            }
        }
        private void changeRocket()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                curRocketIdx = 0;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                curRocketIdx = 1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                curRocketIdx = 2;
            }
        }



        // Unity Inspectors
        [Header("¡Ú Bindings")]
        [SerializeField] private Transform fireCannonTR = null;



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
            changeRocket();
            fire();
        }
    }
}
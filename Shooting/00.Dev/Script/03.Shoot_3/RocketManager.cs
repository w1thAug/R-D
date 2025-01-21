using System.Collections.Generic;
using UnityEngine;

namespace Shoot03
{

    public class RocketManager : MonoBehaviour
    {
        [System.Serializable]
        private class RocketPoolInfo
        {
            public int rocketTypeIdx;
            public int maxSize;
        }

        // Definitions
        public static RocketManager instance;
        // Properties
        public Rocket Rocket => rocket;
        // Methods
        public void GetRocket(int poolIdx, Shooter shooter) { getRocket(poolIdx, shooter); }
        public void ReturnRocket(Rocket rocket) { returnRocket(rocket); }



        // Fields
        private Rocket rocket = null;

        // Dic
        private List<Queue<Rocket>> playerRocketPools = new();
        private List<Queue<Rocket>> enemyRocketPools = new();



        // Functions
        // 생성
        private void init()
        {
            // Player
            for (int idx = 0; idx < pRocketInfo.Length; idx++)
            {
                Queue<Rocket> rocketPoolQueue = new Queue<Rocket>();
                int rndSpeed = Random.Range(3, 6);

                for (int i = 0; i < pRocketInfo[idx].maxSize; i++)
                {
                    PlayerRocket rocket = Instantiate(pRocketPf).GetComponent<PlayerRocket>();

                    rocket.SetModel(idx);
                    rocket.SetSpeed(rndSpeed);

                    rocket.transform.SetParent(pRocketTR);
                    rocket.gameObject.SetActive(false);
                    rocketPoolQueue.Enqueue(rocket);
                }

                playerRocketPools.Add(rocketPoolQueue);
            }

            // Enemy
            for (int idx = 0; idx < eRocketInfo.Length; idx++)
            {
                Queue<Rocket> rocketPoolQueue = new Queue<Rocket>();
                int rndSpeed = Random.Range(3, 6);

                for (int i = 0; i < eRocketInfo[idx].maxSize; i++)
                {
                    EnemyRocket rocket = Instantiate(eRocketPf).GetComponent<EnemyRocket>();

                    rocket.SetModel(idx);
                    rocket.SetSpeed(rndSpeed);

                    rocket.transform.SetParent(eRocketTR);
                    rocket.gameObject.SetActive(false);
                    rocketPoolQueue.Enqueue(rocket);
                }

                enemyRocketPools.Add(rocketPoolQueue);
            }
        }

        // 대여
        private void getRocket(int poolIdx, Shooter shooter)
        {
            Queue<Rocket> currRocketPool = new();

            if (shooter == Shooter.player)
                currRocketPool = playerRocketPools[poolIdx];
            else
                currRocketPool = enemyRocketPools[poolIdx];

            if (currRocketPool.Count > 0)
            {
                var go = currRocketPool.Dequeue();
                go.transform.SetParent(null);
                go.gameObject.SetActive(true);
                rocket = go;
            }
            else
            {
                rocket = null;
            }
        }
        
        // 반환
        private void returnRocket(Rocket rocket)
        {
            rocket.gameObject.SetActive(false);

            if (rocket.Shooter == Shooter.player)
            {
                rocket.transform.SetParent(pRocketTR);
                playerRocketPools[rocket.Index].Enqueue(rocket);
            }
            else
            {
                rocket.transform.SetParent(eRocketTR);
                enemyRocketPools[rocket.Index].Enqueue(rocket);
            }
        }



        // Unity Inspectors
        [Header("@ Player")]
        [SerializeField] private GameObject pRocketPf;
        [SerializeField] private Transform pRocketTR;
        [SerializeField] private RocketPoolInfo[] pRocketInfo;
        [Space()]
        [Header("@ Enemy")]
        [SerializeField] private GameObject eRocketPf;
        [SerializeField] private Transform eRocketTR;
        [SerializeField] private RocketPoolInfo[] eRocketInfo;

        // Unity Messages
        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this.gameObject);

            init();
        }
        private void Start()
        {

        }
    }
}
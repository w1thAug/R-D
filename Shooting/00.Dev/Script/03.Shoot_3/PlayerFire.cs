using UnityEngine;

namespace Shoot03
{
    public class PlayerFire : MonoBehaviour
    {
        // Fields
        private int curRocketIdx;

        // Functions
        private void init()
        {
            curRocketIdx = 0;
        }
        private void fire()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                RocketManager.instance.GetRocket(curRocketIdx, Shooter.player);
                Rocket curRocket = RocketManager.instance.Rocket;

                if (curRocket != null)
                {
                    UIManager.Instance.ActiveCoolDownMessage(false);
                    curRocket.transform.position = fireCannonTR.position;
                    curRocket.gameObject.SetActive(true);
                }
                else UIManager.Instance.ActiveCoolDownMessage(true);
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
        [Header("@ Bindings")]
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
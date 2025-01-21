using UnityEngine;

namespace Shoot03
{
    public class PlayerCollide : MonoBehaviour
    {
        // Event Handlers
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Rocket>() != null)
            {
                if (other.gameObject.GetComponent<Rocket>().Shooter == Shooter.enemy)
                {
                    GameObject explosion = Instantiate(explosionFx);
                    explosion.transform.position = transform.position;

                    RocketManager.instance.ReturnRocket(other.gameObject.GetComponent<Rocket>());

                    gameObject.SetActive(false);
                    other.gameObject.SetActive(false);
                }
            }
        }



        // Unity Inspectors
        [Header("@ Bindings")]
        [SerializeField] private GameObject explosionFx = null;

        // Unity Messages
        private void Awake()
        {

        }
        private void Start()
        {

        }
    }
}
using UnityEngine;

namespace Shoot03
{
    public class Block : MonoBehaviour
    {
        // Event Handlers
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Enemy>() != null)
                other.gameObject.GetComponent<Enemy>().ReleaseObject();

            if (other.gameObject.GetComponent<Rocket>() != null)
            {
                RocketManager.instance.ReturnRocket(other.gameObject.GetComponent<Rocket>());
            }

            other.gameObject.SetActive(false);
        }



        // Unity Messages
        private void Awake()
        {

        }
        private void Start()
        {

        }
    }
}
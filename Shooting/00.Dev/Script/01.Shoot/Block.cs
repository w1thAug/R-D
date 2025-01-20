using UnityEngine;

namespace Shoot
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
                other.gameObject.GetComponent<Rocket>().ReleaseObject();
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
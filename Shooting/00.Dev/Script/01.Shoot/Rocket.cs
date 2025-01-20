using UnityEngine;

namespace Shoot
{
    //public enum Shooter { player, enemey, none = 99};

    public class Rocket : Poolable
    {
        // Properties
        //public Shooter Shooter = Shooter.none;

        // Methods
        //public void SetShooter(Shooter shoot)
        //{
        //    Shooter = shoot;
        //}
        // Event Handlers
        private void OnTriggerEnter(Collider other)
        {

        }



        // Unity Inspectors
        [Header("@ Config")]
        [SerializeField] private float speed = 5f;


        
        // Unity Messages
        void Start()
        {

        }

        void Update()
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            //if (Shooter == Shooter.player) transform.position += Vector3.up * speed * Time.deltaTime;
            //else if(Shooter == Shooter.enemey) transform.position += Vector3.down * speed * Time.deltaTime;
        }
        private void OnEnable()
        {

        }
        private void OnDisable()
        {
            
        }
    }
}
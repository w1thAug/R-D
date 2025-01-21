using UnityEngine;

namespace Shoot03
{
    public class PlayerRocket : Rocket
    {
        // Fields
        private float playerRocketSpeed = 1.0f;



        // Overrides
        public override void SetSpeed(float speed)
        {
            playerRocketSpeed = speed;
        }
        public override void Move()
        {
            transform.position += Vector3.up * playerRocketSpeed * Time.deltaTime;
        }



        // Unity Messages
        private void Awake()
        {
            Shooter = Shooter.player;
        }
        private void Start()
        {

        }
        private void Update()
        {
            Move();
        }
    }
}
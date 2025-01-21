using UnityEngine;

namespace Shoot03
{
    public class EnemyRocket : Rocket
    {
        // Fields
        private float enemyRocketSpeed = 1.0f;



        // Overrides
        public override void SetSpeed(float speed)
        {
            enemyRocketSpeed = speed;
        }
        public override void Move()
        {
            transform.position += Vector3.down * enemyRocketSpeed * Time.deltaTime;
        }



        // Unity Messages
        private void Awake()
        {
            Shooter = Shooter.enemy;
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
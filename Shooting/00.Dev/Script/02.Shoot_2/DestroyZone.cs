using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame
{
	public class DestroyZone : MonoBehaviour
	{
        // Event Handlers
        private void OnTriggerEnter(Collider other)
        {
			if (other.gameObject.name.Contains("Bullet") 
				|| other.gameObject.name.Contains("Enemy"))
			{
				other.gameObject.SetActive(false);

				if (other.gameObject.name.Contains("Bullet"))
				{
					PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
					player.AddBulletPool(other.gameObject);
				}
				else if (other.gameObject.name.Contains("Enemy"))
				{
                    EnemyManager enemyMgr = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
					enemyMgr.AddEnemyPool(other.gameObject);
				}
			}
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
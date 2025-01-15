using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame
{
	public class PlayerFire : MonoBehaviour
	{
		// Definitions
		// Properties
		// Methods
		// Events



		// Fields : caching
		// Fields
		private void fire()
		{
			if (Input.GetButtonDown("Fire1"))
			{
				GameObject bullet = Instantiate(bulletFactory);

				bullet.transform.position = firePositon.transform.position;
			}
		}
		// Functions
		// Event Handlers
		// Overrides



		// Unity Inspectors
		[Header("★ Bindings")]
		[SerializeField] private GameObject bulletFactory = null;
		[SerializeField] private GameObject firePositon = null;
		[Header("★ Config")]
		[SerializeField] private int intValue = 0;

		// Unity Messages
		private void Awake()
		{
		   
		}
		private void Start()
		{
		   
		}
        private void Update()
        {
			fire();
        }
        // Unity Coroutine
    }
}
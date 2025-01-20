using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame
{
	public class Bullet : MonoBehaviour
	{
		// Definitions
		// Properties
		// Methods
		// Events



		// Fields : caching
		// Fields
		// Functions
		private void move()
		{
			Vector3 dir = Vector3.up;
			transform.position += dir * speed * Time.deltaTime;
		}
		// Event Handlers
		// Overrides



		// Unity Inspectors
		[Header("★ Config")]
		[SerializeField] private float speed = 0f;

		// Unity Messages
		private void Awake()
		{
		   
		}
		private void Start()
		{
		   
		}
        private void Update()
        {
			move();
        }

        // Unity Coroutine
    }
}
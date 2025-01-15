using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame
{
	public class DestroyZone : MonoBehaviour
	{
        // Definitions
        // Properties
        // Methods
        // Events



        // Fields : caching
        // Fields
        // Functions
        // Event Handlers
        private void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
        }
        // Overrides



        // Unity Inspectors
        [Header("★ Bindings")]
		[SerializeField] private Text labelTXT = null;
		[Header("★ Config")]
		[SerializeField] private int intValue = 0;

		// Unity Messages
		private void Awake()
		{
		   
		}
		private void Start()
		{
		   
		}

		// Unity Coroutine
	}
}
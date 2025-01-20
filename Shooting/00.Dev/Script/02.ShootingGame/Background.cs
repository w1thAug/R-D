using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame
{
	public class Background : MonoBehaviour
	{
		// Definitions
		// Properties
		// Methods
		// Events



		// Fields : caching
		// Fields
		private void scroll()
		{
			Vector2 dir = Vector2.up;

			bgMaterial.mainTextureOffset += dir * scrollSpeed * Time.deltaTime;
		}
		// Functions
		// Event Handlers
		// Overrides



		// Unity Inspectors
		[Header("★ Bindings")]
		[SerializeField] private Material bgMaterial = null;
		[Header("★ Config")]
		[SerializeField] private float scrollSpeed = 0f;

		// Unity Messages
		private void Awake()
		{
		   
		}
		private void Start()
		{
		   
		}
        private void Update()
        {
			scroll();
        }

        // Unity Coroutine
    }
}
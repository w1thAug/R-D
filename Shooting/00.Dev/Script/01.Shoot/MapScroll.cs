using UnityEngine;

public class MapScroll : MonoBehaviour
{
    // Unity Inspectors
    [Header("@ Bindings")]
    [SerializeField] private Material bgMaterial;
    [Header("@ Config")]
    [SerializeField] private float speed = 1f;


    
    // Unity Messages
    private void Update()
    {
        Vector2 dir = Vector2.up;
        bgMaterial.mainTextureOffset += dir * speed * Time.deltaTime;
    }
}
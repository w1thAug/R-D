using UnityEngine;
using UnityEngine.Pool;

namespace Shoot
{
    public class Poolable : MonoBehaviour
    {
        // Properties
        public IObjectPool<GameObject> Pool { get; set; }

        // Methods
        public void ReleaseObject()
        {
            if(gameObject != null) Pool.Release(gameObject);
        }
    }
}
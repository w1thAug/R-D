using UnityEngine;

namespace Shoot03
{
    public enum Shooter { player, enemy, none = 99 };

    public abstract class Rocket : MonoBehaviour
    {
        // Properties
        public Shooter Shooter = Shooter.none;
        public int Index => rocketIdx;

        // Methods
        public abstract void Move();
        public abstract void SetSpeed(float speed);
        public void SetModel(int idx)
        {
            for(int i =0; i < transform.childCount; i++)
                transform.GetChild(i).gameObject.SetActive(false);

            transform.GetChild(idx).gameObject.SetActive(true);

            rocketIdx = idx;
        }



        // Fields
        public int rocketIdx = 0;



        // Unity Messages
        void Awake()
        {
            
        }
        void Start()
        {

        }
    }
}
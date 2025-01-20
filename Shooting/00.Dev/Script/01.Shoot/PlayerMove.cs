using UnityEngine;

namespace Shoot
{
    public class PlayerMove : MonoBehaviour
    {
        // Definitions
        public static PlayerMove instance;

        // Properties
        public bool IsActive = true;
        public Vector3 Pos => pos;



        // Fields
        private float playerX = 0;
        private float playerY = 0;

        private int movingPos = 0;
        private Vector3 pos;

        //Fields : caching
        private Animator anim_ = null;
        private Animator anim => anim_ ?? GetComponent<Animator>();

        // Fields - Anim
        private static int hashkey_tiltL = Animator.StringToHash("tiltL");
        private static int hashkey_tiltR = Animator.StringToHash("tiltR");
        private static int hashkey_returnL = Animator.StringToHash("returnL");
        private static int hashkey_returnR = Animator.StringToHash("returnR");

        // Functions
        private void move()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 dir = new Vector3(h, v, 0);
            transform.position += dir * speed * Time.deltaTime;

            // 오른쪽 키를 눌렀는데
            if (h > 0)
            {
                // 왼쪽에서 움직이고 있었다면
                if (movingPos <= 0) anim.SetTrigger(hashkey_tiltR);
                movingPos = 1;
            }
            else if (h < 0)
            {
                if (movingPos >= 0) anim.SetTrigger(hashkey_tiltL);
                movingPos = -1;
            }
            else
            {
                if (movingPos < 0) anim.SetTrigger(hashkey_returnR);
                else if(movingPos > 0) anim.SetTrigger(hashkey_returnL);
                movingPos = 0;
            }

            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

            if (pos.x < playerX) pos.x = playerX;
            if (pos.x > 1 - playerX) pos.x = 1 - playerX;
            if (pos.y < playerY) pos.y = playerY;
            if (pos.y > 1 - playerY) pos.y = 1 - playerY;

            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }



        // Unity Inspectors
        [Header("@ Bindings")]
        [SerializeField] private GameObject plane = null;
        [Header("@ Config")]
        [SerializeField] private float speed = 10f;

        // Unity Messages
        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this.gameObject);

            playerX = plane.transform.localScale.x / 2;
            playerY = plane.transform.localScale.y / 2;
        }
        private void Start()
        {

        }
        private void Update()
        {
            move();
            pos = transform.position;
        }
        private void OnDisable()
        {
            IsActive = false;
        }
    }
}
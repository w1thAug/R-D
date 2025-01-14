using UnityEngine;
using UnityEngine.UI;

namespace Shoot
{
    public class PlayerMove : MonoBehaviour
    {
        // 사용자의 입력에 따라 플레이어 이동시키기



        // Functions
        private void move()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            //Vector3 dir = Vector3.right * h + Vector3.up * v;
            Vector3 dir = new Vector3(h, v, 0);

            //transform.Translate(dir * speed * Time.deltaTime);
            transform.position += dir * speed * Time.deltaTime;
        }



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
    }
}
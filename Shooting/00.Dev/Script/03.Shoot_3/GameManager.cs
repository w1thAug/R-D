using System.Collections;
using UnityEngine;

namespace Shoot03
{
    public class GameManager : MonoBehaviour
    {
        // Definitions
        // Properties
        // Methods
        // Events



        // Fields
        // Functions
        // Event Handlers
        // Overrides




        // Unity Messages
        private void Awake()
        {
            
        }
        private void Start()
        {
            StartCoroutine(crPlay());
        }

        // Unity Coroutine
        IEnumerator crPlay()
        {
            // 1. 321 카운트다운
            UIManager.Instance.ShowStartAnim();
            yield return new WaitForSeconds(4.0f);

            // 2. 시작
            PlayerMove.instance.IsActive = true;
            EnemyManager.instance.IsStart = true;
            yield return new WaitUntil(()=> !PlayerMove.instance.IsActive);

            // 3. 종료시 Gameover
            EnemyManager.instance.IsStart = false;
            UIManager.Instance.ShowEnding();

        }
    }
}
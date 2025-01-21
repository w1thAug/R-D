using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

namespace Shoot03
{
    public class UIManager : MonoBehaviour
    {
        // Definitions
        public static UIManager Instance = null;

        // Properties
        public int Score
        {
            get
            {
                return currScore;
            }
            set
            {
                currScore = value;

                currScoreText.text = "현재 점수 : " + currScore;

                if (currScore > bestScore)
                {
                    bestScore = currScore;
                    bestScoreText.text = "최고 점수 : " + bestScore;
                    currScoreText.GetComponent<Text>().color = Color.yellow;

                    PlayerPrefs.SetInt("Best Score", bestScore);
                }
            }
        }

        // Method
        public void ShowStartAnim()
        {
            startAnim.SetTrigger(hashkey_start);
        }
        public void ShowEnding()
        {
            endingPanel.SetActive(true);
        }
        public void ActiveCoolDownMessage(bool isActive)
        {
            coolDownNotice.SetActive(isActive);
        }





        // Fields - Anim
        private static int hashkey_start = Animator.StringToHash("start");

        // Fields
        private int currScore = 0;
        private int bestScore = 0;



        // Unity Inspectors
        [Header("@ Bindings")]
        [SerializeField] private Text currScoreText = null;
        [SerializeField] private Text bestScoreText = null;
        [Space()]
        [SerializeField] private Animator startAnim = null;
        [SerializeField] private GameObject coolDownNotice = null;
        [SerializeField] private GameObject endingPanel = null;



        // Unity Messages
        private void Awake()
        {
            if (Instance == null) Instance = this;

            endingPanel.SetActive(false);
        }
        private void Start()
        {
            bestScore = PlayerPrefs.GetInt("Best Score", 0);
            bestScoreText.text = "최고 점수 : " + bestScore;
        }
    }
}
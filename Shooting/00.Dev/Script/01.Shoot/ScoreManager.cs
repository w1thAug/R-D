using UnityEngine;
using UnityEngine.UI;

namespace Shoot
{
    public class ScoreManager : MonoBehaviour
    {
        // Definitions
        public static ScoreManager Instance = null;
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



        // Fields
        private int currScore = 0;
        private int bestScore = 0;



        // Unity Inspectors
        [Header("@ Bindings")]
        [SerializeField] private Text currScoreText = null;
        [SerializeField] private Text bestScoreText = null;



        // Unity Messages
        private void Awake()
        {
            if (Instance == null) Instance = this;
        }
        private void Start()
        {
            bestScore = PlayerPrefs.GetInt("Best Score", 0);
            bestScoreText.text = "최고 점수 : " + bestScore;
        }
    }
}
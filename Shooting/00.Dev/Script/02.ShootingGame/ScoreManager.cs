using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame
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

                    PlayerPrefs.SetInt("Best Score", bestScore);
                }
            }
        }
        // Methods
        // Events



        // Fields : caching
        // Fields
        private int currScore = 0;
        private int bestScore = 0;

        // Functions
        // Event Handlers
        // Overrides



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

        // Unity Coroutine
    }
}
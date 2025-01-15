using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame
{
    public class ScoreManager : MonoBehaviour
    {
        // Definitions
        // Properties
        // Methods
        public void SetScore(int value)
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
        public int GetScore()
        {
            return currScore;
        }
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

        }
        private void Start()
        {
            bestScore = PlayerPrefs.GetInt("Best Score", 0);
            bestScoreText.text = "최고 점수 : " + bestScore;
        }

        // Unity Coroutine
    }
}
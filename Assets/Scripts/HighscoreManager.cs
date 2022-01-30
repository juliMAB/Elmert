using UnityEngine;
using UnityEngine.UI;

namespace GuilleUtils.Score
{
    public class HighscoreManager : MonoBehaviour
    {
        [SerializeField] private Text text;

        private int highscore = 0;

        public int Highscore { get => highscore; set => highscore = value; }

        private void Start()
        {
            highscore = PlayerPrefs.GetInt("highscoreElmert", highscore);
            text.text = highscore.ToString();
        }

        public void SetScore(int score)
        {
            if (score > highscore)
            {
                highscore = score;
                text.text = score.ToString();

                PlayerPrefs.SetInt("highscoreElmert", highscore);
            }
        }
    }
}
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    private float score = 0.0f;
    private int dificultyLevel = 1;
    private int maxDificultyLeve = 10;
    public Text scoreText;
    public int scoreToNextLevel = 10;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;
        score += Time.deltaTime + dificultyLevel;
        scoreText.text = ((int)score).ToString();

        if (score >= scoreToNextLevel)
        {
            LeveUp();
          /*  score += Time.deltaTime + dificultyLevel;
            scoreText.text = ((int)score).ToString();*/
        }
        void LeveUp()
        {
            if (dificultyLevel == maxDificultyLeve)
            {
                return;
                scoreToNextLevel *= 2;
                dificultyLevel++;
                 GetComponent<PlayerContent>().SetSpeed(dificultyLevel);
                Debug.Log(dificultyLevel);
            }
        }

    }
    private bool isDead = false;

    public void onDeath()
    {
        isDead = true;
    }
}

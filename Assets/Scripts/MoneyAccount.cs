using UnityEngine;
using UnityEngine.UI;

public class MoneyAccount : MonoBehaviour
{
    public GameController gameController;
    public WheelController wheelController;
    public Text winGamer, scoreGamer;

    private Collider2D sectorCollider;
    private int sectorWin, win, score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sectorCollider = collision;
    }

    private void Start()
    {
        //PlayerPrefs.SetInt("score", 0); // Test
        score = PlayerPrefs.GetInt("score");
        scoreGamer.text = FormatScore(score);
    }

    private void Update()
    {
        if (WheelController.isStopWheel)
        {
            sectorWin = sectorCollider.GetComponent<NumberCollider>().number;
            win = gameController.GetNumberWin(sectorWin);
            winGamer.text = "You win: " + win.ToString();
            score += win;
            scoreGamer.text = FormatScore(score);
            PlayerPrefs.SetInt("score", score);

            WheelController.isStopWheel = false;
        }

        if (wheelController.IsWheelPlay())
        {
            winGamer.text = "";
        }
    }

    private string FormatScore(int score)
    {
        int million;
        float thousand;
        string formScor = "Score: ";

        if (score > 1000000)
        {
            million = (int)(score / 1000000);
            score -= million * 1000000;
            formScor += million.ToString() + " m ";
        }
        if(score > 1000)
        {
            thousand = score / 1000f;
            formScor += thousand.ToString() + " k";
        }
        else
        {
            formScor += score;
        }
        return formScor;
    }
}

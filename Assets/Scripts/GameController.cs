using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static int colSectorov = 16;
    private int[] numbersWheel = new int[colSectorov];

    public TextMeshProUGUI[] arrNumbersWheel;
    void Start()
    {
        numbersWheel = new RandomRuletka(colSectorov).GetArrayRandomNumerics();

        for(int i = 0; i < numbersWheel.Length; i++)
        {
            arrNumbersWheel[i].text = numbersWheel[i].ToString();
        }
    }

    public int GetNumberWin(int sector)
    {
        if(sector>=0 && sector < colSectorov)
        {
            return numbersWheel[sector];
        }
        return 0;
    }
}

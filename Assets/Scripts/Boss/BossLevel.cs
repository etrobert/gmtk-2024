using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossLevel : MonoBehaviour
{
    public int level = 1;
    public TMP_Text text;

    //open music file
    public GameObject backgroundMusic;


    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        text.text = "lvl: " + level;

    }
    public void IncreaseLevel()
    {
        level++;
        text.text = "lvl: " + level;
        if (level > 6)
        {
            MainMenu.QuitGame();
        }
    }
    public int GetLevel()
    {
        return level;
    }
}

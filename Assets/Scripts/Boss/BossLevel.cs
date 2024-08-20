using UnityEngine;

public class BossLevel : MonoBehaviour
{
    public int level = 1;
    // Start is called before the first frame update
    void Start()
    {
        level = 1;
    }
    public void IncreaseLevel()
    {
        level++;
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

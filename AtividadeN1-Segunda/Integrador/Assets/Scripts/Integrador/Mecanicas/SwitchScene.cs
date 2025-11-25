using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchScene : MonoBehaviour
{
    public Button[] buttons;
    public Sprite openDoor;


    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 0);

        if (unlockedLevel >= buttons.Length)
            unlockedLevel = buttons.Length - 1;

        while (unlockedLevel >= 0)
        {
            Debug.Log(unlockedLevel);
            buttons[unlockedLevel].interactable = true;
            buttons[unlockedLevel].GetComponent<Image>().sprite = openDoor;
            unlockedLevel--;
        }
    }


    public void ProximaFase()
    {
        int faseSalva = PlayerPrefs.GetInt("faseAtual", -1);

        if (faseSalva == -1)
        {
            int fallback = SceneManager.GetActiveScene().buildIndex + 1;
            if (fallback < SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(fallback);
            else
                CarregaMenuFinal();
            return;
        }

        int proxima = faseSalva + 1;

        if (proxima < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(proxima);
        }
        else
        {
            CarregaMenuFinal();
        }
    }

    public void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void switchScenes(string Menu)
    {
        SceneManager.LoadScene(Menu);
    }

    private void CarregaMenuFinal()
    {
        SceneManager.LoadScene("Menu");
    }
}
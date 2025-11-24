using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
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
using System.Collections;
using UnityEngine;
using TMPro;

public class Descricao : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    void Start()
    {

        index = 0;
        StartCoroutine(TypeLine());
    }

    void Update()
    {

    }
    private void OnEnable()
    {
        DeckManager.OnChangeProgressBar += OnChangeProgressBar;
    }

    private void OnDisable()
    {
        DeckManager.OnChangeProgressBar -= OnChangeProgressBar;
    }


    private void OnChangeProgressBar(float valueBar)
    {

        if (valueBar >= 0 && valueBar <= 0.18f)
        {
            if (textComponent.text == lines[index])
            {
                index = 0;
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        else if (valueBar >= 0.19f && valueBar <= 0.37f)
        {

            if (textComponent.text == lines[index])
            {
                index = 1;
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        else if (valueBar >= 0.41f && valueBar <= 0.54f)
        {
            if (textComponent.text == lines[index])
            {
                index = 2;
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        else if (valueBar >= 0.55f && valueBar <= 0.68f)
        {
            if (textComponent.text == lines[index])
            {
                index = 3;
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        else if (valueBar >= 0.69f && valueBar <= 0.82f)
        {
            if (textComponent.text == lines[index])
            {
                index = 4;
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        else if (valueBar >= 0.83f && valueBar <= 0.96f)
        {
            if (textComponent.text == lines[index])
            {
                index = 5;
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        else if (valueBar >= 0.97f && valueBar <= 1f)
        {
            if (textComponent.text == lines[index])
            {
                index = 6;
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }


    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }

    }

}




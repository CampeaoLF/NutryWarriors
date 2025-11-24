using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
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

        if (valueBar >= 0 && valueBar <= 0.33f)
        {
            if(textComponent.text == lines[index])
            {
                index = 0;
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        else if (valueBar >= 0.34f && valueBar <= 0.66f)
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
        else if (valueBar >= 0.67f && valueBar <= 1f)
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
        if(index < lines.Length - 1)
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




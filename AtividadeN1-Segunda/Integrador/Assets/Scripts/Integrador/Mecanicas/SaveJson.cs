using System.Net.NetworkInformation;
using JetBrains.Annotations;
using UnityEngine;

public class SaveJson
{
    public bool[] portasDesbloqueadas;

    public SaveJson(int quantidadePortas)
    {
        portasDesbloqueadas = new bool[quantidadePortas];

        
        for (int i = 0; i < quantidadePortas; i++)
            portasDesbloqueadas[i] = false;

       
        if (quantidadePortas > 0)
            portasDesbloqueadas[0] = true;
    }
}
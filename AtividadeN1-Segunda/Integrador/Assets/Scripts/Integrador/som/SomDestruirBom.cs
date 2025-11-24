using UnityEngine;


public class SomAoDestruir : MonoBehaviour
{
    [SerializeField] private DeckManager deckManager;
    [Header("Configurações de Áudio")]
    public AudioClip somDestruicao;
    public AudioClip sombom;
    public float volume = 1.0f;
    
    private AudioSource audioSource;

    void Start()
    {
      
    }

    private void Update()
    {
       
    }
}

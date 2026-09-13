using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic backgroundMusic;

    void Awake()
    {
        if (backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Play the music when the game starts
        GetComponent<AudioSource>().Play();
    }

    // You can add methods to control the music here, like Play, Pause, Stop, etc.
    public void PlayMusic()
    {
        GetComponent<AudioSource>().Play();
    }

    public void StopMusic()
    {
        GetComponent<AudioSource>().Stop();
    }
}
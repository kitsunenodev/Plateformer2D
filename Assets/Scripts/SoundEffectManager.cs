using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager instance;

    public AudioSource soundEffectSource;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There are more than one SoundEffectManger instance in the scene");
            return;
        }

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

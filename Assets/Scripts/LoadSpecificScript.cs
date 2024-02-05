using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScript : MonoBehaviour
{
    public String sceneName;
    private Animator fadeSystem;

    private void Awake()
    {
       fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadNextScene());

        }
        
    }

    IEnumerator LoadNextScene()
    {
        LoadAndSaveData.instance.SaveData();
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }
}

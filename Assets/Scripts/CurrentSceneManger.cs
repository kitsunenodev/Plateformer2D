using UnityEngine;

public class CurrentSceneManger : MonoBehaviour
{
    public int coinsPickedUp;
    public Vector3 respawnPoint;
    public int levelToUnlock;

    public static CurrentSceneManger instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There are more than one CurrentSceneManger instance in the scene");
            return;
        }

        instance = this;
        respawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}

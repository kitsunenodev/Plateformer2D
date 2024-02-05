using UnityEngine;

public class ItemsDatabase : MonoBehaviour
{
    public Item[] allItems;
    public static ItemsDatabase instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is more than one instance of ItemsDatabase in the scene");
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

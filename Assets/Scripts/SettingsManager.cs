using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;

    // local scale size
    public float GridSize = 2f; 
    void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this) {
            Destroy(gameObject);
        }
        
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

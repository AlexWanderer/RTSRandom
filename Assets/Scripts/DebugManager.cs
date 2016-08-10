using UnityEngine;
using System.Collections;

public class DebugManager : MonoBehaviour
{

    public static DebugManager instance;

	//Debug;
	public Spinning spiningPerformer; 

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
		if (Input.GetKeyUp(KeyCode.R) && Input.GetKey(KeyCode.LeftShift)) {
			spiningPerformer.Play();
			Debug.Log("<color=red> Spining! </color>");
		}
    }
}

using UnityEngine;
using System.Collections;

public class Spining : MonoBehaviour
{

    public float period = 2f;
    public EaseType easeType = EaseType.easeInOutCubic;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
		Debug.Log("Playtime -> " + Time.timeSinceLevelLoad);
        gameObject.RotateBy(new Vector3(0, 1f, 0), period, 0, easeType, LoopType.loop);
    }
}

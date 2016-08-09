using UnityEngine;
using System.Collections;

public interface IPlayable{
    void Play();
    void Stop();
}

public class Spinning : MonoBehaviour, IPlayable
{

    public float period = 2f;
    public EaseType easeType = EaseType.easeInOutCubic;

    string myItweenName;

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
        myItweenName = gameObject.GetInstanceID().ToString() + "Spinning";
        gameObject.RotateBy(new Vector3(0, 1f, 0), period, 0, easeType, LoopType.loop, myItweenName);
    }

    public void Stop(){
        iTween.StopByName(myItweenName);
    }

}

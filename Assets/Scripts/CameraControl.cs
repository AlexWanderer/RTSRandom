using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{

    Vector3 _keyboardDirection;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        KeyBoardControl();
    }


    public void KeyBoardControl()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            _keyboardDirection = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _keyboardDirection = transform.TransformVector(new Vector3(-1f, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _keyboardDirection = transform.TransformVector(new Vector3(+1f, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _keyboardDirection = new Vector3(1f, 0, 1f).normalized;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _keyboardDirection = new Vector3(-1f, 0, -1f).normalized;
        }

        Camera.main.transform.position += _keyboardDirection * 10f * Time.deltaTime;

    }
}

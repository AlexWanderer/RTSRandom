using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class MaterialModifier : MonoBehaviour
{

    protected Renderer _renderer;

    protected virtual void ModifyMaterialColor(Color _color)
    {
        _renderer.material.color = _color;
    }


    protected virtual void Awake()
    {
		_renderer = GetComponent<Renderer>();
    }
    // Use this for initialization
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }
}

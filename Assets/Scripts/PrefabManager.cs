using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PrefabManager : MonoBehaviour
{

    public static PrefabManager instance;

	public List<GameObject> buildingPrefabs;

    void Awake()
    {
        instance = this;
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

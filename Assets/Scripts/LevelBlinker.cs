using UnityEngine;
using System.Collections;

public class LevelBlinker : MonoBehaviour
{

    Material[] myMaterials;
    Material mainMaterial;

	public float periodTime = 2f;
	public float lowest = 0.5f;
	public float highest = 0.8f;

    // Use this for initialization
    void Start()
    {
        myMaterials = GetComponent<MeshRenderer>().materials;
        mainMaterial = myMaterials[0];
    }

    // Update is called once per frame
    void Update()
    {
		mainMaterial.color = new Color(
			mainMaterial.color.r,
			mainMaterial.color.g,
			mainMaterial.color.b,
		 	((Mathf.Sin(Time.timeSinceLevelLoad / periodTime * Mathf.PI * 2f) + 1)/2f) * (highest - lowest) + lowest);
    }
}

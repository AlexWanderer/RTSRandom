using UnityEngine;
using System.Collections;

public class Utils : MonoBehaviour
{

    public static GameObject CreateAndParent(GameObject parentGameObject, GameObject instance)
    {
        GameObject targetInstance = (GameObject)GameObject.Instantiate(instance, Vector3.zero, Quaternion.identity);
        targetInstance.transform.parent = parentGameObject.transform;
        targetInstance.transform.localPosition = Vector3.zero;
        targetInstance.transform.localEulerAngles = Vector3.zero;
        targetInstance.transform.localScale = Vector3.one;
        return targetInstance;
    }

    // public static T AddMissingComponent<T>  (this GameObject gameObject) where T: UnityEngine.Component
    // {
    //     T targetComponent = gameObject.GetComponent<T>();
    //     if (targetComponent != null)
    //         return targetComponent;
	// 	return gameObject.AddComponent<T>();
    // }
}

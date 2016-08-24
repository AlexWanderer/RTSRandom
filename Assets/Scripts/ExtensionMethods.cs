using UnityEngine;
using System.Collections;

public static class ExtensionMethods {

    public static T AddMissingComponent<T>  (this GameObject gameObject) where T: UnityEngine.Component
    {
        T targetComponent = gameObject.GetComponent<T>();
        if (targetComponent != null)
            return targetComponent;
		return gameObject.AddComponent<T>();
    }

}



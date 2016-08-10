using UnityEngine;
using System.Collections;

public class BuildingIndicator : MonoBehaviour
{

    int _myBuildingIconIndex = -1;

    public bool canBuild = true;

    Transform _world;
    public int myBuildingIconIndex
    {
        get { return _myBuildingIconIndex; }
        set
        {
            if (value > PrefabManager.instance.buildingPrefabs.Count)
                return;
            _myBuildingIconIndex = value;
            if (_myBuildingIcon != null)
            {
                Destroy(_myBuildingIcon.gameObject);
            }
            _myBuildingIcon = Utils.CreateAndParent(gameObject, PrefabManager.instance.buildingPrefabs[value]);
            _myBuildingIcon.GetComponent<IndicatorCollidingMaterialModifier>().myBuildingIndicator = this;
        }
    }

    GameObject _myBuildingIcon;
    int _buildableLayerMask;

    void Awake()
    {
        _world = GameObject.Find("WorldLocation").transform;
    }

    // Use this for initialization
    void Start()
    {
        _buildableLayerMask = 1 << LayerMask.NameToLayer("BuildableTerrains");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        float gridSize = SettingsManager.instance.GridSize;
        if (Physics.Raycast(ray, out hit, 1000f, _buildableLayerMask))
        {
            Vector3 targetPosition = hit.point + new Vector3(gridSize, 0f, gridSize) / 2f;
            targetPosition = new Vector3(Mathf.Round(targetPosition.x / gridSize) * gridSize, targetPosition.y, Mathf.Round(targetPosition.z / gridSize) * gridSize);
            //Debug.Log("HitPosition -> " + targetPosition);
            transform.position = targetPosition;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.Rotate(new Vector3(0f, 90f, 0f));
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (_myBuildingIcon != null)
            {
                if (!canBuild)
                    return;
                Invoke("Build", 0.2f);
            }
        }
    }

    void Build()
    {
        // ifonly canBuild in this whole 0.2secs we can build
        if (!canBuild)
            return;
        
        GameObject newGo = Utils.CreateAndParent(_myBuildingIcon, PrefabManager.instance.buildingPrefabs[_myBuildingIconIndex]);
        newGo.transform.parent = _world;

        newGo.GetComponent<PlayMakerFSM>().SendEvent("Build");
        Collider newGoCollider = newGo.GetComponent<Collider>();
        newGoCollider.enabled = true;
        newGoCollider.isTrigger = false;
        Rigidbody rb = newGo.AddMissingComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.detectCollisions = true;

    }
}

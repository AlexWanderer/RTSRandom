using UnityEngine;
using System.Collections;

public interface IStateChangable
{
    void OnStateChange(string state);
}

public class IndicatorCollidingMaterialModifier : MaterialModifier, IStateChangable
{
    protected PlayMakerFSM _state;
    Color _initialColor;
    BuildingIndicator _myBuildingIndicator;
    public BuildingIndicator myBuildingIndicator{
        get{
            return _myBuildingIndicator;
        }
        set{
            _myBuildingIndicator = value;
            GetComponent<Collider>().enabled = true;
        }
    }

    // Use this for initialization

    protected override void Awake()
    {
        base.Awake();
        _state = GetComponent<PlayMakerFSM>();
        Collider _myCollider =GetComponent<Collider>(); 
        _myCollider.isTrigger = true;
        _myCollider.enabled = false;
        _initialColor = _renderer.material.color;
    }
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public void OnTriggerEnter(Collider _coll)
    {
        if (!PassCollisionTest(_coll))
            return;

        if (_state.ActiveStateName == "Indicator")
        {
            myBuildingIndicator.canBuild = false;
            ModifyMaterialColor(Color.red);
        }
    }

    public void OnTriggerExit(Collider _coll)
    {
        if (!PassCollisionTest(_coll))
            return;

        if (_state.ActiveStateName == "Indicator")
        {
            myBuildingIndicator.canBuild = true;
            ModifyMaterialColor(_initialColor);
        }
    }

    public void OnTriggerStay(Collider _coll)
    {
        if (!PassCollisionTest(_coll))
            return;
        if (myBuildingIndicator.canBuild == false)
            return;
        myBuildingIndicator.canBuild = false;
        ModifyMaterialColor(Color.red);
    }

    bool PassCollisionTest(Collider _coll)
    {
        bool _passCollisionTest = false;
        if (_coll.gameObject.layer == LayerMask.NameToLayer("Buildings"))
            _passCollisionTest = true;

        return _passCollisionTest;
    }

    public void OnStateChange(string state)
    {
        //throw new NotImplementedException();
        if (state != "Indicator")
        {
            Destroy(this);
        }
    }
}

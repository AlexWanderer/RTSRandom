using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayMakerFSM))]
public class PlayMakerStateManager : MonoBehaviour {

	PlayMakerFSM _playmakerFSM;

	// Use this for initialization

	void Awake(){
		_playmakerFSM = GetComponent<PlayMakerFSM>();
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayMakerStateChange(){
		IStateChangable[] _stateChangers =  GetComponents<IStateChangable>();
		for (int i = 0; i < _stateChangers.Length; i++) {
			_stateChangers[i].OnStateChange(_playmakerFSM.ActiveStateName);
		}
	}
}

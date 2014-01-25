using UnityEngine;
using System.Collections;

public class FollowTransform : MonoBehaviour {
	public Transform target;
	public bool translate;
	public bool rotate;
	public bool scale;
	void Start(){
		update();
	}
	void Update () {
		update();
	}
	void update(){
		if(translate){
			transform.position = target.position;
		}
		if(rotate){
			transform.rotation = target.rotation;
		}
		if(scale){
			transform.localScale = target.localScale;
		}
	}
}

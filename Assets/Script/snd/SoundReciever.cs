using UnityEngine;
using System.Collections;

public class SoundReciever : MonoBehaviour {
	public Renderer[] renderers;
	// Use this for initialization
	public Vector2 lastHitDirection;
	public float lastHitPower;
	public float power;
	public float decayTime = 5;

	void Start () {
		renderers = GetComponentsInChildren<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Renderer r in renderers){
			Color c= Color.white *power;
			c.a = lastHitPower;
			r.material.color = c;
			r.material.SetFloat("_RotationX",lastHitDirection.x);
			r.material.SetFloat("_RotationY",lastHitDirection.y);
		}
		lastHitPower = Mathf.Max(lastHitPower-Time.deltaTime*1f/decayTime/2f,0);
		power = Mathf.Max(power-Time.deltaTime*1f/decayTime,0);
	}
	void OnSoundHit(SoundWave wave){
		power += wave.getPower()*0.5f;
		lastHitPower+= wave.getPower();
		if(lastHitPower>1)lastHitPower=1;
		if(power>1)power=1;

		lastHitDirection = wave.getDirection(transform);
	}
}

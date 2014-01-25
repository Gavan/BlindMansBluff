using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SphereCollider))]
[RequireComponent (typeof (Rigidbody))]
public class SoundWave : MonoBehaviour {
	public enum DecayType{
		Linear,
		Square,
		Cube
	}
	public enum DirectionType{
		Radical,
		Straight
	}
	public DirectionType directionType;
	public DecayType decayType;
	public float speed;
	public float originalPower = 1;
	public float expand= 4f;
	public float lifespan = 5;
	private float remainLife = 5 ;
	public Renderer targetRenderer;
	public Vector3 targetRendererOriSize;
	public Color targetRendererOriColor;
	private SphereCollider sphere;
	private float sphereSize;
	// Use this for initialization
	void Start () {
		sphere = GetComponent<SphereCollider>();
		sphereSize = sphere.radius;
		if(targetRenderer==null)targetRenderer=renderer;
		if(targetRenderer){
			targetRendererOriSize = targetRenderer.transform.localScale;
			targetRendererOriColor = targetRenderer.material.GetColor("_TintColor");
		}
		remainLife = lifespan;
	}
	
	// Update is called once per frame
	void Update () {

		rigidbody.MovePosition(transform.position+transform.forward*speed*Time.deltaTime);
		//transform.position+=transform.forward*speed*Time.deltaTime;
		remainLife -= Time.deltaTime;
		if(remainLife<= 0 ){
			Destroy(gameObject);
		}else{

			if(targetRenderer != null && targetRenderer == renderer){
				transform.localScale = targetRendererOriSize * (lifespan-remainLife)*expand;

			}else
			{
				if(targetRenderer){
					targetRenderer.transform.localScale = targetRendererOriSize * (lifespan-remainLife)*expand;
					Color c = targetRendererOriColor;
					c *= (1-(lifespan-remainLife)/lifespan);
					targetRenderer.material.SetColor("_TintColor",c);
				}
				sphere.radius = sphereSize * (lifespan-remainLife)*expand;
			}

		}
	}

	void OnTriggerEnter(Collider other){
		other.SendMessage("OnSoundHit",this,SendMessageOptions.DontRequireReceiver);
	}
	public float getPower(){
		switch(decayType){
		case DecayType.Linear:
			return originalPower*(1-(lifespan-remainLife)/lifespan);
		case DecayType.Square:
			return originalPower*Mathf.Pow(1-(lifespan-remainLife)/lifespan,2);
		case DecayType.Cube:
			return originalPower*Mathf.Pow(1-(lifespan-remainLife)/lifespan,3);

		}
		return 0;
	}
	public Vector2 getDirection(Transform reciever){
		Vector3 dis = reciever.InverseTransformPoint(transform.position);
		return new Vector2(dis.x,0);;
	}
	void OnDrawGizmos(){
		Gizmos.color = new Color(1,1,1,1-(lifespan-remainLife)/lifespan);
		Gizmos.DrawWireSphere(transform.position,sphere.radius);
	}
}

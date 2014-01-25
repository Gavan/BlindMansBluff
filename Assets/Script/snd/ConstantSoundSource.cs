using UnityEngine;
using System.Collections;

public class ConstantSoundSource : MonoBehaviour {
	public SoundWave soundwaveSource;
	public float period = 1;
	public float time ;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(audio)audio.Play();
		time +=Time.deltaTime;
		if(time>=period){
			time = 0;
			SoundWave snd = Instantiate(soundwaveSource) as SoundWave;
			snd.transform.rotation = transform.rotation;
			snd.transform.position = transform.position;
		}
	}
}

using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
// add this to CharacterController
public class CharacterCollisionMessager : MonoBehaviour {

	// Use this for initialization
	void OnControllerColliderHit(ControllerColliderHit hit) {
		hit.gameObject.gameObject.SendMessage("OnHitByCharacter",hit,SendMessageOptions.DontRequireReceiver);
	}

}

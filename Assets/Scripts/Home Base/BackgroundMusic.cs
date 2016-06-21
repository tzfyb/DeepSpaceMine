using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour {



	public AudioClip[] myAudioClip = new AudioClip[4];
	private int currentClip = 0;


	//loops through the background music

	IEnumerator Start() {
		while (true) {
			audio.clip = myAudioClip [currentClip];
			audio.Play ();

			yield return new WaitForSeconds (audio.clip.length);

			currentClip++;

			if (currentClip == 4)
					currentClip = 0;
		}
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
}

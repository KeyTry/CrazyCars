using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

	public AudioClip[] audios;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
		playAudio ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void playAudio()
	{
		int audioNumber = Random.Range (-1, audios.Length);
		audioSource.clip = audios [audioNumber];
		audioSource.volume = (0.1f);
		audioSource.Play ();
	}
}

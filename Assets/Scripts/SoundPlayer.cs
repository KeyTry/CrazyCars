using UnityEngine;

public class SoundPlayer :MonoBehaviour
{

    public AudioClip[] audios;
    public AudioSource audioSource;

    private void Start ( )
    {
        if( audioSource == null )
        {
            audioSource = gameObject.GetComponent<AudioSource>( );
        }

        PlayAudio( );
    }

    private void PlayAudio ( )
    {
        audioSource.clip = audios[ Random.Range( -1, audios.Length ) ];
        audioSource.volume = ( 0.1f );
        audioSource.Play( );
    }
}

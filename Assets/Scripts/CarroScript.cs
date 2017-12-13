using System;
using UnityEngine;

public class CarroScript :MonoBehaviour
{
    private readonly float MIN_SPEED = 0.5f;
    private readonly float MAX_SPEED = 3f;

    public Animator explodeAnimator;
    public GameObject originalMesh;
    public GameObject explodeMesh;

    public AudioClip boomSound;
    private Rigidbody rb;

    private AudioSource audioSource;

    void Awake ( )
    {
        audioSource = gameObject.GetComponent<AudioSource>( );
        rb = GetComponent<Rigidbody>( );
    }

    private void OnDespawned ( )
    {
        rb.velocity = Vector3.zero;
    }

    private void OnSpawned ( )
    {
        originalMesh.SetActive( true );
        explodeMesh.SetActive( false );
        rb.velocity = transform.forward * UnityEngine.Random.Range( MIN_SPEED, MAX_SPEED );
    }

    public void Explode ( )
    {
        audioSource.clip = boomSound;
        audioSource.Play( );
        originalMesh.SetActive( false );
        explodeMesh.SetActive( true );
        explodeAnimator.SetTrigger( "Explode" );
    }
}

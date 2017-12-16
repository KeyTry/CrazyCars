using System;
using UnityEngine;

public class CarroScript :MonoBehaviour
{
    public float minSpeed = 0.5f;
    public float maxSpeed = 2.5f;

    public Animator explodeAnimator;
    public GameObject originalMesh;
    public GameObject explodeMesh;

    public AudioClip boomSound;
    private Rigidbody rb;

    private AudioSource audioSource;

    private BoxCollider carroCollider;

    void Awake ( )
    {
        audioSource = gameObject.GetComponent<AudioSource>( );
        rb = GetComponent<Rigidbody>( );
        carroCollider = gameObject.GetComponent<BoxCollider>();
    }

    private void OnDespawned ( )
    {
        rb.velocity = Vector3.zero;
    }

    private void OnSpawned ( )
    {
        originalMesh.SetActive( true );
        explodeMesh.SetActive( false );
        rb.velocity = transform.forward * UnityEngine.Random.Range( minSpeed, maxSpeed );
    }

    public void Explode ( )
    {
        carroCollider.enabled = false;
        audioSource.clip = boomSound;
        audioSource.Play( );
        originalMesh.SetActive( false );
        explodeMesh.SetActive( true );
        explodeAnimator.SetTrigger( "Explode" );
    }
}

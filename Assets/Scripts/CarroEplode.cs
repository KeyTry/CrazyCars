using UnityEngine;
using UnityEngine.SceneManagement;

public class CarroEplode :MonoBehaviour
{

    public GameObject originalMesh;

    public GameObject explodeMesh;
    private Animator animator;

    public float timeForEndCallback;

    public float timeScale;

    // Use this for initialization
    void Start ( )
    {
        animator = explodeMesh.GetComponent<Animator>( );
    }

    public void Explode ( )
    {
        Invoke( "EndAnimation", timeForEndCallback );
        Time.timeScale = timeScale;

        originalMesh.SetActive( false );
        explodeMesh.SetActive( true );

        animator.SetTrigger( "Explode" );
    }

    void EndAnimation ( )
    {
        // Debug.Log ("Termino la animacion");
        Time.timeScale = 1;
        //SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
        Initiate.Fade( SceneManager.GetActiveScene( ).name, Color.white, 1.0f );
    }
}

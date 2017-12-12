using UnityEngine;
using UnityEngine.UI;

public class ActivateGame :MonoBehaviour
{

    public GameObject city;
    public GameObject carro;
    public GameObject uiStuff;
    public GameObject menuUI;
    public GameObject effTheRules;
    public GameObject pauseMenu;

    CarroUser2 carroScript;
    GameObject carSpawners;
    GameManager gm;

    bool paused;
    float previousTimeScale;

    static bool inicio = true;

    public Button resumeButton;

    // Use this for initialization
    void Start ( )
    {
        previousTimeScale = 0f;
        paused = false;
        carroScript = carro.GetComponent<CarroUser2>( );
        carSpawners = city.transform.Find( "CarSpawners" ).gameObject;
        gm = gameObject.GetComponent<GameManager>( );
        if( inicio )
        {
            DeactivateStuff( );
        } else
        {
            ActivateInit( );
        }
    }

    // Update is called once per frame
    void Update ( )
    {
        Pause( );
    }

    void DeactivateStuff ( )
    {
        uiStuff.gameObject.SetActive( false );
        carroScript.input = false;
        carroScript.toExplode = false;
        carSpawners.SetActive( true );
        gm.countPoints = false;
        inicio = false;
    }

    public void ActivateInit ( )
    {
        uiStuff.gameObject.SetActive( false );
        carSpawners.SetActive( false );
        gm.countPoints = false;
        menuUI.gameObject.SetActive( false );
        carroScript.input = true;
        carroScript.toExplode = false;
        effTheRules.gameObject.SetActive( true );
    }

    public void ActivateStuff ( )
    {
        carroScript.input = true;
        carroScript.toExplode = true;
        uiStuff.gameObject.SetActive( true );
        carSpawners.SetActive( true );
        gm.countPoints = true;
    }

    public void Pause ( )
    {
        if( Input.GetButtonDown( "Cancel" ) )
        {
            if( !paused )
            {
                previousTimeScale = Time.timeScale;
                Time.timeScale = 0;
                DeactivateStuff( );
                pauseMenu.gameObject.SetActive( true );
                carroScript.StopCar( );
                resumeButton.Select( );
                paused = true;
            }
        }
    }

    public void UnPause ( )
    {
        if( paused )
        {
            Time.timeScale = previousTimeScale;
            pauseMenu.gameObject.SetActive( false );
            ActivateStuff( );
            carroScript.ResumeCar( );
            paused = false;
        }
    }
}

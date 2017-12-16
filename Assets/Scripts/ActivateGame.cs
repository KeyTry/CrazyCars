using System;
using UnityEngine;
using UnityEngine.UI;

public class ActivateGame :Singleton<ActivateGame>
{
    public GameObject city;
    public GameObject inGameUI;
    public GameObject menuUI;

    public GameObject effTheRules;
    public GameObject pauseMenu;

    public Button resumeButton;

    private GameManager gm;

    private bool paused;

    private static bool desdeMenuPrincipal = true;

    private void Start ( )
    {
        paused = false;

        foreach( var item in city.GetComponentsInChildren<Spawneable>( true ) )
        {
            item.Init( );
        }

        gm = GameManager.Instance;
        if( desdeMenuPrincipal )
        {
            desdeMenuPrincipal = false;
            gm.Estado = GameManager.State.MENU_PINCIPAL;
            EventManager.TriggerEvent( EventDefinition.MENU_PRINCIPAL );
            MenuPrincipal( );
        } else
        {
            gm.Estado = GameManager.State.JUEGO_NUEVO;
            EventManager.TriggerEvent( EventDefinition.JUEGO_NUEVO );
            JuegoNuevo( );
        }
    }

    private void OnEnable ( )
    {
        EventManager.AddListener( EventDefinition.FIN_BLINKING_UI, OnFinBlinkingUI );
    }

    private void OnDisable ( )
    {
        EventManager.RemoveListener( EventDefinition.FIN_BLINKING_UI, OnFinBlinkingUI );
    }

    private void OnFinBlinkingUI ( )
    {
        inGameUI.SetActive( true );
        menuUI.SetActive( false );
        effTheRules.SetActive( false );
        pauseMenu.SetActive( false );

        gm.countPoints = true;
    }

    private void JuegoNuevo ( )
    {
        inGameUI.SetActive( false );
        menuUI.SetActive( false );
        effTheRules.SetActive( true );
        pauseMenu.SetActive( false );

        gm.countPoints = false;
    }

    private void MenuPrincipal ( )
    {
        inGameUI.SetActive( false );
        menuUI.SetActive( true );
        effTheRules.SetActive( false );
        pauseMenu.SetActive( false );

        gm.countPoints = false;
    }

    private void MenuPause ( )
    {
        inGameUI.SetActive( false );
        menuUI.SetActive( true );
        effTheRules.SetActive( false );
        pauseMenu.SetActive( false );


        pauseMenu.gameObject.SetActive( true );
        resumeButton.Select( );

        gm.countPoints = false;
        paused = true;
    }

    private void DisposeMenuPause ( )
    {
        inGameUI.SetActive( false );
        menuUI.SetActive( true );
        effTheRules.SetActive( false );
        pauseMenu.SetActive( false );


        pauseMenu.gameObject.SetActive( false );
        paused = false;


        gm.countPoints = false;
    }

    private void Update ( )
    {
        CheckPause( );
    }

    public void BotonIniciar ( )
    {
        gm.Estado = GameManager.State.JUEGO_NUEVO;
        EventManager.TriggerEvent( EventDefinition.JUEGO_NUEVO );
        JuegoNuevo( );
    }

    public void CheckPause ( )
    {
        if( Input.GetButtonDown( "Cancel" ) )
        {
            if( !paused )
            {
                EventManager.TriggerEvent( EventDefinition.PAUSE );
                MenuPause( );
            }
        }
    }

    public void UnPause ( )
    {
        if( paused )
        {
            EventManager.TriggerEvent( EventDefinition.RESUME );
            DisposeMenuPause( );
        }
    }
}

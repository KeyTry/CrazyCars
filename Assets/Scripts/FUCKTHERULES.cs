using System.Collections;
using UnityEngine;

public class FUCKTHERULES :MonoBehaviour
{

    int counter;
    public GameObject blinkingObj;
    bool blinking;
    public ActivateGame manager;

    // Use this for initialization
    void Start ( )
    {
        blinking = true;
        StartCoroutine( Blink( ) );
        counter = 0;
    }

    // Update is called once per frame
    void Update ( )
    {

    }

    IEnumerator Blink ( )
    {
        while( blinking )
        {
            blinkingObj.SetActive( true );
            yield return new WaitForSeconds( 0.1f );
            blinkingObj.SetActive( false );
            yield return new WaitForSeconds( 0.1f );
            counter++;
            if( counter > 3 )
            {
                blinking = false;
                manager.ActivateStuff( );
            }
        }
    }
}

using System.Collections;
using UnityEngine;

public class FUCKTHERULES :MonoBehaviour
{

    int counter;
    GameObject eff;
    bool blinking;
    public ActivateGame manager;

    // Use this for initialization
    void Start ( )
    {
        eff = transform.Find( "Eff" ).gameObject;
        blinking = true;
        StartCoroutine( blink( ) );
        counter = 0;
    }

    // Update is called once per frame
    void Update ( )
    {

    }

    IEnumerator blink ( )
    {
        while( blinking )
        {
            eff.SetActive( true );
            yield return new WaitForSeconds( 0.1f );
            eff.SetActive( false );
            yield return new WaitForSeconds( 0.1f );
            counter++;
            if( counter > 3 )
            {
                blinking = false;
                manager.ActivateStuff( );
                transform.parent.gameObject.SetActive( false );
            }
        }
    }
}

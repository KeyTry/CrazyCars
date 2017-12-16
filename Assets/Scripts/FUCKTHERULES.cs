using System.Collections;
using UnityEngine;

public class FUCKTHERULES :MonoBehaviour
{

    public GameObject blinkingObj;

    private int counter;
    private bool blinking;

    private void OnEnable ( )
    {
        blinking = true;
        StartCoroutine( Blink( ) );
        counter = 0;
    }

    private IEnumerator Blink ( )
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
                EventManager.TriggerEvent( EventDefinition.FIN_BLINKING_UI );
            }
        }
    }
}

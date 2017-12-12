using UnityEngine;
using UnityEngine.UI;

public class Semaforo :MonoBehaviour
{

    public Image[] imgs;
    public Color color1 = new Color( 178, 25, 53, 255 );
    public Color color2 = new Color( 7, 128, 57, 255 );
    public Color color3 = new Color( 178, 25, 53, 255 );

    public Color blank = new Color( 73, 73, 73, 255 );
    // Use this for initialization
    void Start ( )
    {
        BlankColors( );
    }

    public void BlankColors ( )
    {
        imgs[ 0 ].color = blank;
        imgs[ 1 ].color = blank;
        imgs[ 2 ].color = blank;
    }

    public void Luz1 ( )
    {
        imgs[ 0 ].color = color1;
        imgs[ 1 ].color = blank;
        imgs[ 2 ].color = blank;
    }

    public void Luz2 ( )
    {
        imgs[ 0 ].color = color1;
        imgs[ 1 ].color = color2;
        imgs[ 2 ].color = blank;
    }

    public void Luz3 ( )
    {
        imgs[ 0 ].color = color1;
        imgs[ 1 ].color = color2;
        imgs[ 2 ].color = color3;
    }
}

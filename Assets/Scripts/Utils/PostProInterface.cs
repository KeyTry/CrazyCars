using UnityEngine;
using UnityEngine.PostProcessing;

public class PostProInterface :MonoBehaviour
{
    public PostProcessingBehaviour behaviour;
    private PostProcessingProfile m_Profile;

    private ChromaticAberrationModel.Settings setC;
    private ColorGradingModel.Settings setCG;

    public float input;
    private float saturation;
    private float chromaticAberration;

    private void Start ( )
    {
        if( behaviour == null )
        {
            behaviour = FindObjectOfType<PostProcessingBehaviour>( );
        }

        m_Profile = Instantiate( behaviour.profile );
        behaviour.profile = m_Profile;

        setC = m_Profile.chromaticAberration.settings;
        setCG = m_Profile.colorGrading.settings;
    }

    private void Update ( )
    {
        input = Input.GetAxis( "Vertical" );

        if( input > 0 )
        {
            chromaticAberration = MathfExtension.Remap( input, 0f, 1f, 0.5f, 3f );
            saturation = MathfExtension.Remap( input, 0f, 1f, 1.5f, 2f );

            Change( chromaticAberration, saturation );
        }
        if( input == 0 )
        {
            Change( 0.5f, 1.5f );
        }
        if( input < 0 )
        {
            chromaticAberration = MathfExtension.Remap( input, 0f, -1f, 0.5f, 2f );
            saturation = MathfExtension.Remap( input, 0f, -1f, 1.5f, 0.9f );

            Change( chromaticAberration, saturation );
        }
    }

    public void Change ( float chromaticAberration, float saturation )
    {
        setC.intensity = chromaticAberration;
        setCG.basic.saturation = saturation;

        m_Profile.chromaticAberration.settings = setC;
        m_Profile.colorGrading.settings = setCG;
    }

}

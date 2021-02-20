using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // The Audio source that we will be using in the game to play audio
    [SerializeField] private AudioSource _audioSource;

    // Rotation Sounds
    [SerializeField] private AudioClip _rotateLeftSFX;
    [SerializeField] private AudioClip _rotaterightSFX;

    // Disc Sounds
    [SerializeField] private AudioClip _pickupSFX;
    [SerializeField] private AudioClip _putDownSFX;

    // Error Sound
    [SerializeField] private AudioClip _errorSFX;

    // Button Sound
    [SerializeField] private AudioClip _buttonSFX;
    [SerializeField] private AudioClip _sliderSFX;

    /// <summary>
    /// Plays a specific Audio Clipt
    /// </summary>
    /// <param name="p_audioClip">The audio clip to be played</param>
    /// <param name="p_loop">Will it be looped?</param>
    private void PlayAudio(AudioClip p_audioClip, bool p_loop)
    {
        _audioSource.clip = p_audioClip;
        _audioSource.loop = p_loop;
        _audioSource.Play();
    }

    /// <summary>
    /// Plays the rotation sound effect depending on which rotation type
    /// </summary>
    /// <param name="p_rotation">Wheter the rotation type is left or right</param>
    public void PlayRotateSFX(RotationType p_rotation)
    {
        switch (p_rotation)
        {
            case RotationType.LEFT:
                PlayAudio(_rotateLeftSFX, false);
                break;
            case RotationType.RIGHT:
                PlayAudio(_rotaterightSFX, false);
                break;
        }
    }

    /// <summary>
    /// Plays the pick up sfx
    /// </summary>
    public void PlayPickupSFX()
    {
        PlayAudio(_pickupSFX, false);
    }

    /// <summary>
    /// Plays the put down sfx
    /// </summary>
    public void PlayPutDownSFX()
    {
        PlayAudio(_putDownSFX, false);
    }

    /// <summary>
    /// Plays the Error sfx
    /// </summary>
    public void PlayErrorSFX()
    {
        PlayAudio(_errorSFX, false);
    }

    /// <summary>
    /// Plays the Button sfx
    /// </summary>
    public void PlayButtonSFX()
    {
        PlayAudio(_buttonSFX, false);
    }

    /// <summary>
    /// Plays the Slider sfx
    /// </summary>
    public void PlaySliderSFX()
    {
        PlayAudio(_sliderSFX, false);
    }
}

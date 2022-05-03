using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_AudioManager : MonoBehaviour
{
    public AudioSource bomb_dropping;
    public AudioSource triple_shot;
    public AudioSource single_shot;
    /// <summary>
    /// type "Bomb_dropping" for a bomb dropping sound. Type "Triple_shot" for a Triple_shot sound
    /// Type "Single_shot" for a Single_shot sound
    /// </summary>
    public void playAudio(string name)
    {
        switch (name)
        {
            case "Bomb_dropping":
                if (bomb_dropping != null)
                {
                    if (Save_manager.Instance != null)
                    {
                        bomb_dropping.volume = Save_manager.Instance.ui_sound_effects.sound_vfx;
                        bomb_dropping.Play();
                    }
                    else
                    {
                        bomb_dropping.volume = .3f;
                        bomb_dropping.Play();
                    }
                }
                break;
            case "Triple_shot":
                if (triple_shot != null)
                {
                    if (Save_manager.Instance != null)
                    {
                        triple_shot.volume = Save_manager.Instance.ui_sound_effects.sound_vfx;
                        triple_shot.Play();
                    }
                    else
                    {
                        triple_shot.volume = .3f;
                        triple_shot.Play();
                    }
                }
                break;
            case "Single_shot":
                if (single_shot != null)
                {
                    if (Save_manager.Instance != null)
                    {
                        single_shot.volume = Save_manager.Instance.ui_sound_effects.sound_vfx;
                        single_shot.Play();
                    }
                    else
                    {
                        single_shot.volume = .3f;
                        single_shot.Play();
                    }
                }
                break;
        }
    }
    /// <summary>
    /// type "Bomb_dropping" to stop a bomb dropping sound. Type "Triple_shot" for a Triple_shot sound
    /// Type "Single_shot" to stop a Single_shot sound
    /// </summary>
    public void stopAudio(string name)
    {
        switch (name)
        {
            case "Bomb_dropping":
                if (bomb_dropping != null)
                {
                    bomb_dropping.Stop();
                }
                    break;
            case "Triple_shot":
                if (triple_shot != null)
                {
                   triple_shot.Stop();
                }
                break;
            case "Single_shot":
                if (single_shot != null)
                {
                    single_shot.Stop();
                }
                break;
        }
    }
}

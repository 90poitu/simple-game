using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class GameUIAudio : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private AudioSource audioSource;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audioSource != null)
        {
            if (Save_manager.Instance != null)
            {
                audioSource.volume = Save_manager.Instance.ui_sound_effects.sound_vfx;
                audioSource.Play();
            }
        }
        else
        {
            Debug.LogError("Audio Source is not found");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Hover : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        for (int i = 0; i < Audio_manager.Instance.ASources.Length; i++)
        {
            if (Audio_manager.Instance.ASources[i] != null)
            {
                Audio_manager.Instance.playSound("Hover", Save_manager.Instance.ui_sound_effects.sound_vfx);
            }
            else
            {
                Debug.LogError("Audio sources is not found");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class StartingPageUiHover : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private AudioSource SourceClip;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (SourceClip != null)
        {
            SourceClip.Play();
        }
        else
        {
            Debug.LogError("No audio source found");
        }
    }
}

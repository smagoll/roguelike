using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackgroundBack : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GameObject window;

    public void OnPointerDown(PointerEventData eventData)
    {
        window.SetActive(false);
        Action();
    }

    public virtual void Action()
    {
        
    }
}

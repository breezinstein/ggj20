using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Clickable : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    UnityEvent enter;
    [SerializeField]
    UnityEvent exit;
    [SerializeField]
    UnityEvent click;
#pragma warning restore 0649

    public void SetupListeners(UnityAction onEnter, UnityAction onExit, UnityAction onClick)
    {
        RemoveListeners();

        enter.AddListener(onEnter);
        exit.AddListener(onExit);
        click.AddListener(onClick);
    }

    void RemoveListeners()
    {
        enter.RemoveAllListeners();
        exit.RemoveAllListeners();
        click.RemoveAllListeners();
    }

    private void OnMouseEnter()
    {
        enter?.Invoke();
    }

    private void OnMouseExit()
    {
        exit?.Invoke();
    }

    private void OnMouseUpAsButton()
    {
        click?.Invoke();
    }

    private void OnDestroy()
    {
        RemoveListeners();
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorSwitch : MonoBehaviour
{
    [SerializeField]
    private GameObject _trap;
    public void ToggleTrap()
    {
        _trap.SetActive(!_trap.activeSelf);
    }

    public void EnableTrap()
    {
        _trap.SetActive(true);
    }

    public void DisableTrap()
    {
        _trap.SetActive(false);
    }

    public void SetTrapStatus(bool val)
    {
        _trap.SetActive(val);
    }
}

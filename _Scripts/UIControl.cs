using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class UIControl : MonoBehaviour
{
    //Movement & Toggle Controls
    [SerializeField] private Toggle _toggleA1, _toggleA2, _toggleB1, _toggleB2;
    [SerializeField] private GameObject _player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //SetLocomotionPreferences();
    }

    private void SetLocomotionPreferences()
    {
        var continuousTurn = _player.GetComponent<ActionBasedContinuousTurnProvider>();
        var snapTurn = _player.GetComponent<ActionBasedSnapTurnProvider>();

        if (_toggleA1.isOn) { continuousTurn.enabled = true; }
        else { continuousTurn.enabled = false; }

        if (_toggleA2.isOn) { snapTurn.enabled = true; }
        else { snapTurn.enabled = false; }


        var continuousMove = _player.GetComponent<ActionBasedContinuousMoveProvider>();
        var teleportMove = _player.GetComponent<TeleportationProvider>();

        if(_toggleB1.isOn) { continuousMove.enabled = true; }
        else { continuousMove.enabled = false; }

        if (_toggleB2.isOn) { teleportMove.enabled = true; }
        else { teleportMove.enabled = false; }
    }
}

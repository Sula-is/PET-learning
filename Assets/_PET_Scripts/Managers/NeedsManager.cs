using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsManager : MonoBehaviour {
    public Pet _activePet;
    public TimerManager.Timer _needsTimer;
    public int _needDecreaseRate = 10;
    private void OnEnable() {
        if (_needsTimer!=null) {
            return;
        }
        _needsTimer = TimerManager.Instance.AddTimer(_needDecreaseRate, DecreaseNeeds,true);
    }

    private void DecreaseNeeds() {
        Debug.Log("Decrease Needs");
        _activePet._satiety = _activePet._satiety - 1;
        _activePet._affection = _activePet._affection - 1;
        _activePet._fun = _activePet._fun - 1;
    }

    
}

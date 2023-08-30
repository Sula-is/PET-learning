using System;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour {
    //Singleton pattern
    private static TimerManager _instance = null;
    private static readonly object _padlock = new object();
    public List<Timer> _timers = new List<Timer>();

    TimerManager() { }

    public static TimerManager Instance {
        get {
            lock (_padlock) {
                if (_instance == null) {
                    var obj = new GameObject("TimerManager", typeof(TimerManager));
                    _instance = obj.GetComponent<TimerManager>();
                }

                return _instance;
            }
        }
    }

    private void Awake() {
        _instance = this;
    }

    private void Update() {
        for (var i = 0; i < _timers.Count; i++) {
            if (_timers[i]._timerDuration < Time.time) {
                _timers[i]._action?.Invoke();
                if (!_timers[i]._looping) {
                    _timers.RemoveAt(i);
                }
            }
        }
    }

    /// <summary>
    ///
    /// Example: TimerManager.active.AddTimer(2, ()=> {print(Time.time);} , true);
    /// </summary>
    /// <param name="delay"></param>
    /// <param name="action"></param>
    /// <param name="looping"></param>
    public Timer AddTimer(float delay, System.Action action, bool looping = false) {
        Timer newTimer = new Timer(delay, action, looping);
        _timers.Add(newTimer);
        return newTimer;
    }

    public bool RemoveTimer(Timer timerToRemove) {
        bool result = _timers.Remove(timerToRemove);
        return result;
    }

    public class Timer {
        public Action _action;
        public float _delay;
        public bool _looping;
        public float _timerDuration;

        public Timer(float delay, Action action, bool looping = false) {
            _timerDuration = Time.time + delay;
            _delay = delay;
            _action = action;
            _looping = looping;

            if (!looping) {
                return;
            }

            _action += () => { _timerDuration = Time.time + _delay; };
        }
    }
}
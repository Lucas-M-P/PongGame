using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum States
    {
        MENU,
        PLAYING,
        RESET_POSITION,
        END_GAME
    }

    public Dictionary<States, StateBase> dictionaryStates;

    private StateBase _currentState;

    public static StateMachine Instance;

    private void Awake()
    {
        Instance = this;

        dictionaryStates = new Dictionary<States, StateBase>();
        dictionaryStates.Add(States.MENU, new StateBase());
        dictionaryStates.Add(States.PLAYING, new StatePlaying());
        dictionaryStates.Add(States.RESET_POSITION, new StateResetPosition());
        dictionaryStates.Add(States.END_GAME, new StateBase());

        SwitchState(States.MENU);
    }

    private void SwitchState(States state)
    {
        if(_currentState != null)
        {
            _currentState.OnStateExit();
        }

        _currentState = dictionaryStates[state];

        _currentState.OnStateEnter(null);
    }

    // Update is called once per frame
    void Update()
    {
        if(_currentState != null)
        {
            _currentState.OnStateStay();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            SwitchState(States.PLAYING);
        }
    }

    public void ResetPosition()
    {
        SwitchState(States.RESET_POSITION);
    }
}

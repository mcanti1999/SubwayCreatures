using System;
using UnityEngine;

namespace StateMachines
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] private State currentState;
        private State mainMenuState, pauseState, mainGameState, looseGameState, winGameState;
        
        [SerializeField] private StateHandler 
            mainMenuHandler,
            pauseHandler,
            mainGameStateHandler,
            looseGameHandler,
            winGameHandler;
        private void Start() {
            mainMenuState = new State("Main Menu", mainMenuHandler);
            pauseState = new State("Pause Game", pauseHandler);
            mainGameState = new State("Game Start", mainGameStateHandler);
            looseGameState = new State("Lost Game", looseGameHandler);
            winGameState = new State("Won Game", winGameHandler);
            
            currentState = mainGameState;
            Trigger(Event.EnteredLooseScreen);

        }
        private bool Handle(Event transition) {
            switch (transition) {
                case Event.UserPressedPlay:
                    return Transition(mainMenuState, mainGameState);
                case Event.UserPausedGame:
                    return Transition(mainGameState, pauseState);
                case Event.EnteredWinScreen:
                    return Transition(mainGameState, winGameState);
                case Event.EnteredLooseScreen:
                    return Transition(mainGameState, looseGameState);
                case Event.ExitedEndScreen:
                    return Transition(looseGameState, mainGameState);
                
            }

            return false;
        }

        private bool Transition(State expectedState, State nextState) {
            if (currentState == expectedState) {
                Debug.Log($"[{currentState.stateName}] -> [{nextState.stateName}]");
                currentState.onExit?.Invoke();
                currentState = nextState;
                nextState.onEnter?.Invoke();
                return true;
            }
            return false;
        }
        public bool Trigger(Event @event) {
            return Handle(@event);
        }
    }
    public enum Event {
        UserPressedPlay, UserPausedGame,
        EnteredWinScreen, EnteredLooseScreen,
        ExitedEndScreen
    }
    [Serializable]
    public class State {
        public string stateName;
        public Action onEnter;
        public Action onExit;

        public State(string name, StateHandler handler) {
            stateName = name;
            if (handler != null) {
                onEnter += handler.OnEnter;
                onExit += handler.OnExit;
            }
        }
    }
  
    interface IStateHandler {
        void OnEnter();
        void OnExit();
    }
    
    public abstract class StateHandler : MonoBehaviour, IStateHandler {
        public void OnEnter() {
            //throw new NotImplementedException();
        }

        public void OnExit() {
           // throw new NotImplementedException();
        }
    }
}
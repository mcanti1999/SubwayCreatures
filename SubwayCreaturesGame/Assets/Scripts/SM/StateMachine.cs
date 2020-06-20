using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace StateMachines
{
    public class StateMachine : MonoBehaviour
    {
        private static StateMachine instance;

        public static StateMachine Instance
        {
            get
            {
                if (instance == null)
                {
                    Initialize();
                }

                return instance;
            }
            private set { instance = value; }
        }

        private static void Initialize()
        {
            var gameObjects = FindObjectsOfType<StateMachine>();
            if (gameObjects.Length < 1)
            {
                CreateInstance();
            }
            else if(gameObjects.Length == 1)
            {
                instance = gameObjects[0];
            }
            else
            {
                Debug.LogWarning("more than one Instance! Assuming first");
                instance = gameObjects[0];
            }
        }

        private static void CreateInstance()
        {
            var host = new GameObject();
            Instance = host.AddComponent<StateMachine>();
            // prevent accidental scene saving
            host.hideFlags = HideFlags.DontSaveInEditor;
        }
        
        
        [SerializeField] private State currentState;
        private State mainMenuState, pauseState, mainGameState, looseGameState, winGameState;

        [SerializeField] private StateHandler 
            mainMenuHandler,
            pauseHandler,
            looseGameHandler,
            mainGameHandler,
            winGameHandler;


        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
            }

            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        private void Start() {
            
            mainMenuState = new State("Main Menu", mainMenuHandler);
            pauseState = new State("Pause Game", pauseHandler);
            mainGameState = new State("Game Start", mainGameHandler);
            looseGameState = new State("Lost Game", looseGameHandler);
            winGameState = new State("Won Game", winGameHandler);
            
            currentState = mainMenuState;
            
            //this is bs
            Trigger(Event.EnteredMainMenu);


        }
        private bool Handle(Event transition) {
            switch (transition) {
                case Event.EnteredMainGame:
                    return Transition(mainMenuState, mainGameState);
                case Event.EnteredPauseScreen:
                    return Transition(mainGameState, pauseState);
                case Event.EnteredWinScreen:
                    return Transition(mainGameState, winGameState);
                case Event.EnteredLooseScreen:
                    return Transition(mainGameState, looseGameState);
                case Event.ExitedEndScreen:
                    return Transition(looseGameState, mainGameState);
                case Event.ExitedPauseScreen:
                    return Transition(pauseState, mainGameState);
                case Event.EnteredMainMenu:
                    return Transition(mainMenuState, mainMenuState);

                
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
        EnteredMainGame, EnteredPauseScreen,
        EnteredWinScreen, EnteredLooseScreen,
        ExitedEndScreen, ExitedPauseScreen,
        EnteredMainMenu
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
    
    public abstract class StateHandler : MonoBehaviour, IStateHandler
    {
        public abstract void OnEnter();

        public abstract void OnExit();
    }
}
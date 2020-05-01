using UnityEngine;

namespace StateMachines
{
    public class PauseHandler2: StateHandler
    {
        public override void OnEnter()
        {
            Time.timeScale = 0;
        }

        public override void OnExit()
        {
            Time.timeScale = 1;
        }
    }
}
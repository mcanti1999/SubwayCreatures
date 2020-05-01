using UnityEngine;
using UnityEngine.SceneManagement;

namespace StateMachines
{
    public class MainGameHandler: StateHandler
    {
        public override void OnEnter()
        {
            
            SceneManager.LoadScene("Main");
        }

        public override void OnExit()
        {
            
        }
    }
}
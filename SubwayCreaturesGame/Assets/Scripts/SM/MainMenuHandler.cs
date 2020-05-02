using UnityEngine;
using UnityEngine.SceneManagement;

namespace StateMachines
{
    public class MainMenuHandler: StateHandler
    {
        public override void OnEnter()
        {
            SceneManager.LoadScene("Start");
        }

        public override void OnExit()
        {
           
        }
    }
}
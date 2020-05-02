using UnityEngine;
using UnityEngine.SceneManagement;

namespace StateMachines
{
    public class MainGameHandler: StateHandler
    {
        //need to change that, doesnt work with pause state, because we dont want to restart scene everytime we unpause
        public override void OnEnter()
        {
            SceneManager.LoadScene("Main");
        }

        public override void OnExit()
        {
            
        }
    }
}
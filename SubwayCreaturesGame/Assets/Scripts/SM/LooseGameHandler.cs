using UnityEngine;
using UnityEngine.SceneManagement;

namespace StateMachines
{
    public class  LooseGameHandler: StateHandler
    {
        public override void OnEnter()
        {
            SceneManager.LoadScene("EndScreen");
        }

        public override void OnExit()
        {
            
        }
    }
}
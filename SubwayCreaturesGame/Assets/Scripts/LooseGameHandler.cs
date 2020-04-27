using UnityEngine.SceneManagement;

namespace StateMachines
{
    public class LooseGameHandler: StateHandler
    {
        public void OnEnter()
        {
            SceneManager.LoadScene("EndScreen");
        }

        public void OnExit()
        {
            
        }
    }
}
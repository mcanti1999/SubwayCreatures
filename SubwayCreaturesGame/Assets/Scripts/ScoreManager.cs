using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ScoreManager: MonoBehaviour
    {
        public Text coinText;
        private int score;
        private static ScoreManager instance;
        //Singleton stuff
        public static ScoreManager Instance
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
            var gameObjects = FindObjectsOfType<ScoreManager>();
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
            Instance = host.AddComponent<ScoreManager>();
            // prevent accidental scene saving
            host.hideFlags = HideFlags.DontSaveInEditor;
        }

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }

            instance = this;
            //DontDestroyOnLoad(gameObject);
        }

        //adds coin value to existing score
        public void ChangeScore(int coinValue)
        {
            score += coinValue;
            coinText.text = score + " Coins";
        }
    }
}
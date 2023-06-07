using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Base.GameStates
{
    internal static class GameStateService 
    { 
        private static List<IStateDependent> stateDependents = new List<IStateDependent>();
        private static GameStateTypes currentGameState;
        public static GameStateTypes CurrentGameState { get => currentGameState; }
        private static bool isInited = false;

        public static void Init()
        {
            if (isInited)
            {
                Debug.LogError($"GameState is inited!");
                return;
            }

            stateDependents = new List<IStateDependent>();
            var goDependents = GameObject.FindObjectsOfType<MonoBehaviour>();
            foreach (var go in goDependents)
            {
                if (go is IStateDependent dependent) Register(dependent);
            }
            isInited = true;
        }

        public static void Register(IStateDependent stateDependent)
        {
            if (!stateDependents.Contains(stateDependent))
                stateDependents.Add(stateDependent);
            else
                Debug.LogError($"Re-registration entity {stateDependent}");
        }

        public static void Unregister(IStateDependent stateDependent)
        {
            if (stateDependents.Contains(stateDependent))
                stateDependents.Remove(stateDependent);
            else
                Debug.LogError($"Nothing to deregister {stateDependent}");
        }

        public static void Restart()
        {
            stateDependents.ForEach(el => el.Restart());
        }

        public static void ChangeState(GameStateTypes newGameState)
        {

        }
    }
}

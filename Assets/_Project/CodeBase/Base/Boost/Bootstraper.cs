using CodeBase.Base.GameStates;
using UnityEngine;

namespace CodeBase.Base.Boost
{
    internal class Bootstraper : MonoBehaviour
    {
        public static Bootstraper Instance { get => instance; }
        private static Bootstraper instance = null;

        private void Awake()
        {
            if (instance == null) instance = this;
            GameStateService.Init();
        }
    }
}

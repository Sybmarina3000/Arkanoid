using Helper.Patterns;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class RealizationBox : Singleton<RealizationBox>
    {
        [SerializeField] private Racket _Player;
        [FormerlySerializedAs("customUpdater")] [SerializeField] private CustomUpdater _CustomUpdater;
        [SerializeField] private BrickManager _BrickManager;
        public IPlayer Player => _Player;
        public IUpdating CustomUpdater => _CustomUpdater;
        public IManagerForDestroyable ManagerForDestroyable => _BrickManager;
    }
}
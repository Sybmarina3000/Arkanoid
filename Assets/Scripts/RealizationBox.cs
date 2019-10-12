using Helper.Patterns;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class RealizationBox : Singleton<RealizationBox>
    {
        [SerializeField] private Racket _Player;
        [FormerlySerializedAs("_Updater")] [SerializeField] private CustomUpdater customUpdater;
        
        public IPlayer Player => _Player;
        public IUpdating CustomUpdater => customUpdater;

    }
}
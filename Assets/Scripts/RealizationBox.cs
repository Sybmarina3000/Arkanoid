using Helper.Patterns;
using UnityEngine;

namespace DefaultNamespace
{
    public class RealizationBox : Singleton<RealizationBox>
    {
        [SerializeField] private Racket _Player;
        public IPlayer Player => _Player;
        
    }
}
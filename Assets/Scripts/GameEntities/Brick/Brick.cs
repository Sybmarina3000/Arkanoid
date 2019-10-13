using GameEntities.IBehaviour;
using UnityEngine;

namespace GameEntities.Brick
{
    public class Brick : MonoBehaviour, IDestroyable
    {
        private SpriteRenderer _spriteRenderer;
        public GameObject MyGameObject
        {
            get { return gameObject; }
        }

        public Vector3 MyPosition { get => _transform.position; }

        [SerializeField] private uint _startHP;
        public uint HP { get => _currentHP; }
        [SerializeField] private uint _currentHP;

        private Transform _transform;
        private void Awake()
        {
            _currentHP = _startHP;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _transform = transform;
        }

        public bool IsDestroy { get => _currentHP == 0; }

        public void Damage(uint damage)
        {
            _currentHP -= damage;
            if(_currentHP == 0 )
                Destroy();
        }

        public void Destroy()
        {
            MyGameObject.SetActive(false);
        }

        public void VisualUpdate(Color newColor)
        {
            _spriteRenderer.color = newColor;
        }

        public void Reload()
        {
            _currentHP = _startHP;
        }

    }
}

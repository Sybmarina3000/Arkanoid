using UnityEngine;
using UnityEngine.Serialization;

namespace GridCreator
{
    enum TypeCreate
    {
        BrickWork,
        Linear,
    }
    
    public class GridCreator : MonoBehaviour
    {
        [SerializeField] private Transform _StartPoint;
        
        [SerializeField] private int _Row, _Column;
        [SerializeField] private float Gap;

        [SerializeField] private GameObject _Prefab;
        [SerializeField] GameObject[] _generateObjects;

        [SerializeField] private TypeCreate _TypeGenerateBrick;

        private float _gapX, _gapY;
        private Vector3 _shift;
        
        
        #region BUILD GRID IN EDITOR MODE
        [ExecuteInEditMode]
        public void BuildGrid()
        {
            DeleteLastGrid();
            CalculateGap();
            _generateObjects = new GameObject[ _Row * _Column];
            Vector2 startPosition = _StartPoint.position; 
            
            for (int row = 0; row < _Row; row++)
            {
                for (int column = 0; column < _Column; column++)
                {
                    _generateObjects[ column + row * _Column] =  Instantiate(_Prefab, 
                        new Vector2(   _gapX * column + startPosition.x, _gapY * -row  + startPosition.y ),
                        Quaternion.identity, this.transform) ;
                    if (_TypeGenerateBrick == TypeCreate.BrickWork && row % 2 == 0)
                        _generateObjects[column + row * _Column].transform.position += _shift;
                }    
            }
        }
        
        private void DeleteLastGrid( )
        {
            if( ReferenceEquals( _generateObjects, null))
                return;

            foreach (var item in _generateObjects)
            {
                DestroyImmediate(item);
            }
            _generateObjects = null;
        }

        private void CalculateGap()
        {
            var spriteSize = _Prefab.GetComponent<SpriteRenderer>().size;
            var localScale = _Prefab.transform.localScale;
            _gapX = spriteSize.x  * localScale.x + Gap;
            _gapY = spriteSize.y  * localScale.y + Gap;
            _shift = new Vector3( _gapX / 2 , 0,0);
        }
        #endregion

    }
}

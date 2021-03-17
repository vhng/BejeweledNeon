﻿using UnityEngine;

namespace BJW
{
    [System.Serializable]
    public class BoardManager
    {
        #region Variables

        private bool canStartWitchMatches = false;
        [SerializeField] private int _boardRowSize = 8;
        [SerializeField] private int _boardCollumSize = 8;
        
        #endregion
        
        #region Components
    
        [SerializeField] private GemCollectionData _gemCollectionToUse = null;
        private Board _board = null;

        #region Properties

        public Board board => _board;

        #endregion
    
        #endregion
    
        #region Methods
    
        public void OnStart()
        {
            InitializeBoard();
        }
    
        public void OnGizmos()
        {
            DrawBoardGizmosPreview();
        }
        
        private void InitializeBoard()
        {
            _board = new Board(_boardRowSize, _boardCollumSize, _gemCollectionToUse.gemDatas, canStartWitchMatches);
        }
    
        #region Gizmos
    
        public void DrawBoardGizmosPreview()
        {
            var sizeX = 1;
            var sizeY = 1;
            
            var size = new Vector2(sizeX,sizeY);
            
            for (int i = 0; i < _boardRowSize; i++)
            {
                for (int j = 0; j < _boardCollumSize; j++)
                {
                    var position = new Vector3(i*size.x, j*size.y, 0);
                    
                    Gizmos.DrawWireCube(position, size);
                }
            }
        }
    
        #endregion
    
        #endregion
    }
}


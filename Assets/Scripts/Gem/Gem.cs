﻿using System;
using UnityEngine;

namespace BJW
{
    public class Gem
    {
        #region Variables

        private GemType _gemType;
        private GemState _gemState;
        private Vector2 _boardPosition = new Vector2();

        #region Properties

        public Vector2 boardPosition => _boardPosition;
        public GemState gemState => _gemState;

        #endregion
        
        #endregion

        #region Components

        [SerializeField] private GemData _gemData = null;
        
        private GemView _gemView = null;

        #endregion

        #region Events / Actions

        public Action OnClick;

        #endregion

        #region Methods
        
        // Constructor
        public Gem(GemData gemData)
        {
            _gemData = gemData;
            _gemType = gemData.gemType;
            
            CreateView();
        }

        public void SetBoardPosition(Vector2 newPosition)
        {
            _boardPosition = newPosition;
            _gemView.UpdatePosition(newPosition);
        }

        private void CreateView()
        {
            _gemView = new GameObject().AddComponent<GemView>();
            _gemView.SetGemData(_gemData);
            _gemView.SetGem(this);
        }

        #endregion
    }
}
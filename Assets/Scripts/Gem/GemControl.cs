﻿namespace BJW
{
    public class GemControl
    {
        #region Components

        private Board _board = null;
        private Gem _firstSelectedGem = null;
        private Gem _secondSelectedGem = null;

        #endregion
        
        #region Methods
        
        // Constructor
        public GemControl(Board gameBoard)
        {
            _board = gameBoard;
            SetControlOnAllGems();
        }

        private void SetControlOnAllGems()
        {
            foreach (var gem in _board.gemsInGame)
            {
                gem.OnClick = () => OnGemClick(gem);
            }
        }
        private void OnGemClick(Gem gem)
        {
            if (!CanInteractWithGem()) return;

            if (_board.boardState == BoardState.Playing)
            {
                _board.ChangeBoardState(BoardState.GemSelected);
                _firstSelectedGem = gem;
            }
            
            else if (_board.boardState == BoardState.GemSelected)
            {
                _secondSelectedGem = gem;
                
                if (CanSwitchGems())
                    TrySwitchGems();
                else
                    UnselectAllGems();
            }
        }

        private void TrySwitchGems()
        {
            var firstGemPosition = _firstSelectedGem.boardPosition;
            var secondGemPosition = _secondSelectedGem.boardPosition;
            
            _firstSelectedGem.SetBoardPosition(secondGemPosition);
            _secondSelectedGem.SetBoardPosition(firstGemPosition);
            
            UnselectAllGems();
        }

        private void UnselectAllGems()
        {
            _firstSelectedGem = null;
            _secondSelectedGem = null;
            _board.ChangeBoardState(BoardState.Playing);
        }

        private bool CanSwitchGems()
        {
            return true;
        }
        
        private bool CanInteractWithGem()
        {
            switch (_board.boardState)
            {
                case BoardState.Waiting:
                    return false;
            }
            
            
            // True if no negation conditions above
            return true;
        }
        

        #endregion
    }
}
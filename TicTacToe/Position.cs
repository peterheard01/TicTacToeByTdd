namespace TicTacToe
{
    public class Position
    {
        private GameState _gameState;

        public Position(GameState gameStateArg, int visualPosition)
        {
            _gameState = gameStateArg;
            _pos = visualPosition - 1;
        }

        public bool IsCentre
        {
            get { return VisualPosition == 5; }
        }

        public bool IsCorner
        {
            get { return VisualPosition == 1 || VisualPosition == 3 || VisualPosition == 7 || VisualPosition == 9; }
        }

        public bool IsEdge
        {
            get { return VisualPosition == 2 || VisualPosition == 4 || VisualPosition == 6 || VisualPosition == 8; }
        }

        private int _pos { get; set; }

        public int VisualPosition
        {
            get { return _pos + 1; }
        }

        public string Symbol {
            get { return _gameState.Board[_pos].Substring(1, _gameState.Board[_pos].Length-1); }
        }

        internal void Place(string symbolArg)
        {
            _gameState.Board[_pos] = VisualPosition+symbolArg;
        }
    }
}
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
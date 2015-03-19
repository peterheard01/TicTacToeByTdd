using NUnit.Framework;

namespace TicTacToe.Test
{
    public class GameLoopTestsBase
    {
        protected Game _game;
        private string[] _endState;

        private void GameStarted(string[] start,string userInput, string[] end)
        {
            _game = new Game();
            _game.GameState.PlayerSymbol = "o";
            _game.GameState.ComputerSymbol = "x";
            _game.GameState.GameStatus = GameStatus.GameStarted;
            _game.GameState.Board = Helper.Setup(start);
            _game.ReadUserInput(userInput);
            _endState = Helper.Setup(end);
        }

        [TestCase(new[]
        {
            "x", "o", " ", 
            "o", "x", " ", 
            " ", " ", " "
        }, "7", new[]
        {
            "x", "o", " ", 
            "o", "x", " ", 
            "o", " ", "x"
        })]//test win [first diagonal]
        [TestCase(new[]
        {
            " ", "x", "o", 
            " ", "x", " ", 
            " ", " ", "o"
        }, "4", new[]
        {
            " ", "x", "o", 
            "o", "x", " ", 
            " ", "x", "o"
        })]//test win [first vertical]
        [TestCase(new[]
        {
            "x", "x", " ", 
            "o", "o", " ", 
            " ", " ", " "
        }, "8", new[]
        {
            "x", "x", "x", 
            "o", "o", " ", 
            " ", "o", " "
        })]//test win [first horizontal]

        [TestCase(new[]
        {
            "x", "x", " ", 
            "o", "o", " ", 
            "o", "x", " "
        }, "9", new[]
        {
            "x", "x", "x", 
            "o", "o", " ", 
            "o", "x", "o"
        })]//test win [first horizontal]

        public void Test_Win(string[] start, string userInput, string[] end)
        {
            GameStarted(start,userInput,end);
            CollectionAssert.AreEqual(_game.GameState.Board, end);
        }

        [TestCase(new[]
        {
            "o", " ", " ", 
            " ", "x", " ", 
            " ", " ", " "
        }, "2", new[]
        {
            "o", "o", "x", 
            " ", "x", " ", 
            " ", " ", " "
        })]//test block [first horizontal]
        [TestCase(new[]
        {
            "o", " ", " ", 
            " ", "x", " ", 
            " ", " ", " "
        }, "4", new[]
        {
            "o", " ", " ", 
            "o", "x", " ", 
            "x", " ", " "
        })]//test block [first vertical]
        [TestCase(new[]
        {
            "o", "x", " ", 
            " ", " ", " ", 
            " ", " ", " "
        }, "5", new[]
        {
            "o", "x", " ", 
            " ", "o", " ", 
            " ", " ", "x"
        })]//test block [first diagonal]
        public void Test_Block(string[] start, string userInput, string[] end)
        {
            GameStarted(start, userInput, end);
            CollectionAssert.AreEqual(_game.GameState.Board, end);
        }

        [TestCase(new[]
        {
            "o", " ", " ", 
            " ", "x", " ", 
            " ", " ", "x"
        }, "8", new[]
        {
            "o", " ", "x", 
            " ", "x", " ", 
            " ", "o", "x"
        })]//test fork 1
        [TestCase(new[]
        {
            " ", " ", "x", 
            " ", "x", " ", 
            "o", " ", " "
        }, "6", new[]
        {
            "x", " ", "x", 
            " ", "x", "o", 
            "o", " ", " "
        })]//test fork 2
        public void Test_Fork(string[] start, string userInput, string[] end)
        {
            GameStarted(start, userInput, end);
            CollectionAssert.AreEqual(_game.GameState.Board, end);
        }

        [TestCase(new[]
        {
            " ", " ", "x", 
            " ", " ", " ", 
            "o", " ", " "
        }, "6", new[]
        {
            " ", " ", "x", 
            " ", "x", "o", 
            "o", " ", " "
        })]//take centre
        [TestCase(new[]
        {
            " ", " ", "x", 
            " ", " ", " ", 
            "o", " ", " "
        }, "5", new[]
        {
            "x", " ", "x", 
            " ", "o", " ", 
            "o", " ", " "
        })]//take corner
        [TestCase(new[]
        {
            "x", " ", " ", 
            " ", " ", " ", 
            " ", "x", "o"
        }, "5", new[]
        {
            "x", " ", "x", 
            " ", "o", " ", 
            " ", "x", "o"
        })]//take corner
        public void Test_Take_Centre_Or_Edge(string[] start, string userInput, string[] end)
        {
            GameStarted(start, userInput, end);
            CollectionAssert.AreEqual(_game.GameState.Board, end);
        }

        [TestCase(new[]
        {
            " ", " ", " ", 
            " ", "x", " ", 
            " ", " ", " "
        }, "3", new[]
        {
            "x", " ", "o", 
            " ", "x", " ", 
            " ", " ", " "
        })]//take corner
        public void Bugs(string[] start, string userInput, string[] end)
        {
            GameStarted(start, userInput, end);
            CollectionAssert.AreEqual(_game.GameState.Board, end);
        }

    }
}

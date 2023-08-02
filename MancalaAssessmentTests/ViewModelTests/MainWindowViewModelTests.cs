using System.Collections.Generic;
using MancalaAssessment;
using MancalaAssessment.Interfaces;
using MancalaAssessment.Models;
using MancalaAssessment.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MancalaAssessmentTests.ViewModelTests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void BannerText_DefaultValue()
        {
            Assert.AreEqual("Click \"New Game\" to get started!", new MainWindowViewModel().BannerText);
        }

        [TestMethod]
        public void NextPlayeIndexTest()
        {
            var boardState = new BoardState();
            var gameManager = new GameManager(boardState);
            var playerNumber = gameManager.Move(0).PlayerNumber;
            Assert.AreEqual(2, playerNumber);
            //We move 4 away from players 2 pit so he/she comes again.
            playerNumber = gameManager.Move(GameConstants.BOARD_SIZE - 5).PlayerNumber;
            Assert.AreEqual(2, playerNumber);
        }
        [TestMethod]
        public void GameEndedTest()
        {
            //Player 1 won case
            List<int> board = new List<int>() { 0, 0, 0, 0, 0, 1, 12, 0, 0, 0, 0, 0, 1, 2 };

            var boardState = new BoardState(){Board = board };
            var gameManager = new GameManager(boardState);
            gameManager.Move(5);

            Assert.AreEqual(GameStatus.P1Win, gameManager.GetGameStatus());

            //Player 2 won case
            board = new List<int>() { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 12 };
            boardState = new BoardState() { Board = board, PlayerNumber = 2};
            gameManager = new GameManager(boardState);
            gameManager.Move(12);

            Assert.AreEqual(GameStatus.P2Win, gameManager.GetGameStatus());

            //Match still Ongoing case
            board = new List<int>() { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 12 };
            boardState = new BoardState() { Board = board, PlayerNumber = 1 };
            gameManager = new GameManager(boardState);
            gameManager.Move(0);

            Assert.AreEqual(GameStatus.Ongoing, gameManager.GetGameStatus());

            //Draw case
            board = new List<int>() { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1 };
            boardState = new BoardState() { Board = board, PlayerNumber = 1 };
            gameManager = new GameManager(boardState);
            gameManager.Move(5);

            Assert.AreEqual(GameStatus.Draw, gameManager.GetGameStatus());
        }

        [TestMethod]
        public void SpecialRulesTest()
        {
            List<int> board = new List<int>() { 1, 0, 0, 0, 0, 0, 1, 0, 2, 0, 0, 2, 0, 1 };

            var boardState = new BoardState() { Board = board };
            var gameManager = new GameManager(boardState);
            gameManager.Move(0);

            Assert.AreEqual(gameManager.BoardState.Board[1], 0);
            Assert.AreEqual(gameManager.BoardState.Board[6], 4);
        }
       
    }
}
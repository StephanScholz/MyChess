using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chess.Game
{
    public class GameManager : MonoBehaviour
    {
        private BoardUI boardUI;
        public Board board { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            boardUI = FindObjectOfType<BoardUI>();
            board = new Board();
            NewGame();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void NewGame()
        {
            board.LoadStartPosition();
            boardUI.UpdatePosition(board);
            boardUI.ResetSquareColours();
        }
    }
}

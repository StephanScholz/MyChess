using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chess
{
    public class Board
    {
        public const int WhiteIndex = 0;
        public const int BlackIndex = 1;

        //Stores piece code for each square on the board.
        //Piece code is defined as piecetype | color code
        public int[] Square;

        //Index of square of black and white king
        public int[] KingSquare;

        public PieceList[] rooks;
        public PieceList[] bishops;
        public PieceList[] queens;
        public PieceList[] knights;
        public PieceList[] pawns;

        PieceList[] allPieceLists;
        PieceList GetPieceList(int pieceType, int colourIndex)
        {
            return allPieceLists[colourIndex * 8 + pieceType];
        }

        //Load the starting position
        public void LoadStartPosition()
        {
            LoadPosition(FenUtility.startFen);
        }

        private void LoadPosition(string fen)
        {
            Initialize();
            var loadedPosition = FenUtility.PositionFromFen(fen);

            //Load pieces into board array and piece lists
            for (int squareIndex = 0; squareIndex < 64; squareIndex++)
            {
                int piece = loadedPosition.squares[squareIndex];
                Square[squareIndex] = piece;

                if (piece != Piece.None)
                {
                    int pieceType = Piece.PieceType(piece);
                    int pieceColourIndex = (Piece.IsColour(piece, Piece.White)) ? WhiteIndex : BlackIndex;
                    
                    if (Piece.IsSlidingPiece(piece))
                    {
                        if (pieceType == Piece.Queen)
                        {
                            queens[pieceColourIndex].AddPieceAtSquare(squareIndex);
                        }
                        else if (pieceType == Piece.Rook)
                        {
                            rooks[pieceColourIndex].AddPieceAtSquare(squareIndex);
                        }
                        else if (pieceType == Piece.Bishop)
                        {
                            bishops[pieceColourIndex].AddPieceAtSquare(squareIndex);
                        }
                    }
                    else if (pieceType == Piece.Knight)
                    {
                        knights[pieceColourIndex].AddPieceAtSquare(squareIndex);
                    }
                    else if (pieceType == Piece.Pawn)
                    {
                        pawns[pieceColourIndex].AddPieceAtSquare(squareIndex);
                    }
                    else if (pieceType == Piece.King)
                    {
                        KingSquare[pieceColourIndex] = squareIndex;
                    }
                }
            }

            //Side to move

            
        }

        private void Initialize()
        {
            Square = new int[64];
            KingSquare = new int[2];

            knights = new PieceList[] { new PieceList(10), new PieceList(10) };
            pawns = new PieceList[] { new PieceList(8), new PieceList(8) };
            rooks = new PieceList[] { new PieceList(10), new PieceList(10) };
            bishops = new PieceList[] { new PieceList(10), new PieceList(10) };
            queens = new PieceList[] { new PieceList(9), new PieceList(9) };
            PieceList emptyList = new PieceList(0);
            allPieceLists = new PieceList[] {
                emptyList,
                emptyList,
                pawns[WhiteIndex],
                knights[WhiteIndex],
                emptyList,
                bishops[WhiteIndex],
                rooks[WhiteIndex],
                queens[WhiteIndex],
                emptyList,
                emptyList,
                pawns[BlackIndex],
                knights[BlackIndex],
                emptyList,
                bishops[BlackIndex],
                rooks[BlackIndex],
                queens[BlackIndex],
            };
        }
    }
}


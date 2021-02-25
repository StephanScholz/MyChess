using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chess
{
    public static class FenUtility
    {
        static Dictionary<char, int> pieceTypeFromSymbol = new Dictionary<char, int>()
        {
            ['k'] = Piece.King,
            ['p'] = Piece.Pawn,
            ['n'] = Piece.Knight,
            ['b'] = Piece.Bishop,
            ['r'] = Piece.Rook,
            ['q'] = Piece.Queen
        };
        public const string startFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

        //Load position from fen string
        public static LoadedPositionInfo PositionFromFen(string fen)
        {
            LoadedPositionInfo loadedPositionInfo = new LoadedPositionInfo();
            string[] sections = fen.Split(' ');

            int file = 0;
            int rank = 7;

            foreach (char symbol in sections[0])
            {
                if (symbol == '/')
                {
                    file = 0;
                    rank--;
                }
                else
                {
                    if (char.IsDigit(symbol))
                    {
                        file += (int)char.GetNumericValue(symbol);
                    }
                    else
                    {
                        int pieceColour = (char.IsUpper(symbol)) ? Piece.White : Piece.Black;
                        int pieceType = pieceTypeFromSymbol[char.ToLower(symbol)];
                        loadedPositionInfo.squares[rank * 8 + file] = pieceType | pieceColour;
                        file++;
                    }
                }
            }
            loadedPositionInfo.whiteToMove = (sections[1] == "w");

            return loadedPositionInfo;
        }
    }

    public class LoadedPositionInfo
    {
        public int[] squares;
        public bool whiteCastleKingside;
        public bool whiteCastleQueenside;
        public bool blackCastleKingside;
        public bool blackCastleQueenside;
        public int epFile;
        public bool whiteToMove;
        public int plyCount;

        public LoadedPositionInfo()
        {
            squares = new int[64];
        }
    }
}


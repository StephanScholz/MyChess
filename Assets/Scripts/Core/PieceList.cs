﻿namespace Chess
{
    public class PieceList
    {
        // Indices of squares occupied by given piece type (only elements up to Count are valid, the rest are unused/garbage)
        public int[] occupiedSquares;

        // Map to go from index of a square, to the index in the occupiedSquares array where that square is stored
        int[] map;
        int numPieces;

        public PieceList(int maxPieceCount = 16)
        {
            occupiedSquares = new int[maxPieceCount];
            map = new int[64];
            numPieces = 0;
        }

        public int Count
        {
            get
            {
                return numPieces;
            }
        }

        public void AddPieceAtSquare(int square)
        {
            occupiedSquares[numPieces] = square;
            map[square] = numPieces;
            numPieces++;
        }

        public void RemovePieceAtSquare(int square)
        {
            int pieceIndex = map[square]; //Get the index of the square in the occupiedSquares array
            occupiedSquares[pieceIndex] = occupiedSquares[numPieces - 1]; //Move last element in the array to the place of the removed element
            map[occupiedSquares[pieceIndex]] = pieceIndex; //Update map to point to the moved element's new location in the array
            numPieces--;
        }

        public void MovePiece(int startSquare, int targetSquare)
        {
            int pieceIndex = map[startSquare]; //Get the index of the square in the occupiedSquares array
            occupiedSquares[pieceIndex] = targetSquare;
            map[targetSquare] = pieceIndex;
        }

        public int this[int index] => occupiedSquares[index];
    }
}

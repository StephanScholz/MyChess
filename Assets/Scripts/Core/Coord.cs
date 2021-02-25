﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chess
{

}
public class Coord : IComparable<Coord>
{
    public readonly int fileIndex;
    public readonly int rankIndex;

    public Coord(int fileIndex, int rankIndex)
    {
        this.fileIndex = fileIndex;
        this.rankIndex = rankIndex;
    }

    public bool IsLightSquare ()
    {
        return (fileIndex + rankIndex) % 2 != 0;
    }

    public int CompareTo(Coord other)
    {
        return (fileIndex == other.fileIndex && rankIndex == other.rankIndex) ? 0 : 1;
    }
}

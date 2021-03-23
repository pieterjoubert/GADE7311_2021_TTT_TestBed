using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : IPlayable
{
    private Tile team;

    public BoardState MakeMove(BoardState boardState, Vector2Int move)
    {
        boardState.Board[move.x, move.y] = team;
        return boardState;
    }

    public void SetTeam(Tile t)
    {
        team = t;
    }

}


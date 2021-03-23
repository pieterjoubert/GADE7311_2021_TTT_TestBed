using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAI : IPlayable
{
    private Tile team;

    public BoardState MakeMove(BoardState boardState, Vector2Int move)
    {
        // Add Random AI here
        while (true)
        {
            int xPos = Random.Range(0, 3);
            int yPos = Random.Range(0, 3);
            if (boardState.Board[xPos, yPos] == Tile.EMPTY)
            {
                boardState.Board[xPos, yPos] = team;
                break;
            }
        }

        return boardState;
    }

    public void SetTeam(Tile t)
    {
        team = t;
    }

}

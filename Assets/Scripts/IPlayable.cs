using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayable 
{
    BoardState MakeMove(BoardState currentState, Vector2Int move);
    void SetTeam(Tile team);
}

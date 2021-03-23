using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player
{
    HUMAN,
    RANDOM
}

public class BoardManager : MonoBehaviour
{
    public GameObject emptyTile;
    public GameObject crossTile;
    public GameObject noughtTile;

    public int width;
    public int height;

    public Player player1Choice;
    public Player player2Choice;

    private IPlayable player1;
    private IPlayable player2;

    private Tile currentTeam = Tile.CROSS;

    private BoardState boardState;
    private Vector2Int currentMove;

    // Start is called before the first frame update
    void Start()
    {
        boardState = new BoardState(width, height);
        currentMove = new Vector2Int();

        switch(player1Choice) //Crosses
        {
            case Player.HUMAN: player1 = new Human(); break;
            case Player.RANDOM: player1 = new RandomAI();  break;
        }

        player1.SetTeam(Tile.CROSS);

        switch(player2Choice) // Noughts
        {
            case Player.HUMAN: player2 = new Human(); break;
            case Player.RANDOM: player2 = new RandomAI();  break;
        }

        player2.SetTeam(Tile.NOUGHT);

        Draw();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeTurn();
            Draw();
        }
    }

    void TakeTurn()
    {
        if (boardState.Winner() == Tile.EMPTY)
        {
            if (currentTeam == Tile.CROSS)
            {
                boardState = player1.MakeMove(boardState, currentMove);
                currentTeam = Tile.NOUGHT;
            }
            else if (currentTeam == Tile.NOUGHT)
            {
                boardState = player2.MakeMove(boardState, currentMove);
                currentTeam = Tile.CROSS;
            }
        }
        else
        {
            Debug.Log("Winner is: " + boardState.Winner());
        }
    }

    void Draw()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        foreach(GameObject go in tiles) { Destroy(go); }

        for(int x = 0; x < boardState.Width; x++)
        {
            for(int z = 0; z < boardState.Width; z++)
            {
                if(boardState.Board[x,z] == Tile.EMPTY)
                {
                    GameObject go = Instantiate(emptyTile, new Vector3(x, 0f, z), Quaternion.identity);
                    go.GetComponent<TileController>().position = new Vector2Int(x, z);
                }
                else if(boardState.Board[x,z] == Tile.CROSS)
                {
                    Instantiate(crossTile, new Vector3(x, 0f, z), Quaternion.identity);
                }
                else if(boardState.Board[x,z] == Tile.NOUGHT)
                {
                    Instantiate(noughtTile, new Vector3(x, 0f, z), Quaternion.identity);
                }
            }
        }
    }

    public void SetCurrentMove(Vector2Int newMove)
    {
        currentMove = newMove;
        TakeTurn();
        Draw();
    }
}

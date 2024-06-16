using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    public GameObject[,] BoardGameObject = new GameObject[8, 8];
    public GameObject[,] BoardGameObject2 = new GameObject[8, 8];
    public GameObject BoardPiece;
    public GameObject PiecePrefab;
    internal bool IsWhite = false;
    private GameObject Pointer;
    void Start()
    {
        Pointer = GameObject.Instantiate(PiecePrefab);
        Pointer.GetComponent<SpriteRenderer>().color = Color.black;
        bool _black = false;
        for (int i = 0; i < 8; i++)
        {
            if (_black)
                _black = false;
            else
                _black = true;
            for (int j = 0; j < 8; j++)
            {
                GameObject Piece = Instantiate(BoardPiece, new Vector3(i, j, -1), Quaternion.identity);
                Piece.GetComponent<PieceScript>().x = i;
                Piece.GetComponent<PieceScript>().y = j;
                Piece.GetComponent<PieceScript>().MainGame = this.gameObject;
                BoardGameObject2[i, j] = Piece;
                if (_black)
                {
                    Piece.GetComponent<SpriteRenderer>().color = Color.red;
                    _black = false;
                }
                else
                {
                    Piece.GetComponent<SpriteRenderer>().color = Color.green;
                    _black = true;
                }
            }
        }
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                GameObject Piece = Instantiate(PiecePrefab, new Vector3(i, j, -2), Quaternion.identity);
                BoardGameObject[i, j] = Piece;
                Piece.GetComponent<SpriteRenderer>().color = Color.clear;
            }
        }
        BoardGameObject[3, 3].GetComponent<SpriteRenderer>().color = Color.white;
        BoardGameObject[3, 4].GetComponent<SpriteRenderer>().color = Color.black;
        BoardGameObject[4, 4].GetComponent<SpriteRenderer>().color = Color.white;
        BoardGameObject[4, 3].GetComponent<SpriteRenderer>().color = Color.black;
        CheckValid();
    }

    private void Update()
    {
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = -3f;
        Pointer.transform.position = mouseWorldPos;
    }
    public void CheckWhiteMove(int x, int y)
    {
        if (BoardGameObject[x, y].GetComponent<SpriteRenderer>().color == Color.clear)
            BoardGameObject[x, y].GetComponent<SpriteRenderer>().color = Color.white;
        List<GameObject> goList = new List<GameObject>();
        for (int i = 1; i < 8; i++)
        {
            if (i + x < 8)
            {
                if (BoardGameObject[x + i, y].GetComponent<SpriteRenderer>().color == Color.black)
                {
                    goList.Add(BoardGameObject[x + i, y]);
                }
                else if (BoardGameObject[x + i, y].GetComponent<SpriteRenderer>().color == Color.white)
                {
                    if (goList.Count > 0)
                    {
                        for (int j = 0; j < goList.Count; j++)
                        {
                            goList[j].GetComponent<SpriteRenderer>().color = Color.white;
                        }
                        goList.Clear();
                        break;
                    }
                    else
                    {

                        goList.Clear();
                        break;
                    }
                }

                else
                {
                    goList.Clear();
                    break;
                }
            }
        }
        for (int i = 1; i < 8; i++)
        {
            if (x - i > -1)
            {
                if (BoardGameObject[x - i, y].GetComponent<SpriteRenderer>().color == Color.black)
                {
                    goList.Add(BoardGameObject[x - i, y]);
                }
                else if (BoardGameObject[x - i, y].GetComponent<SpriteRenderer>().color == Color.white)
                {
                    if (goList.Count > 0)
                    {
                        for (int j = 0; j < goList.Count; j++)
                        {
                            goList[j].GetComponent<SpriteRenderer>().color = Color.white;
                        }
                        goList.Clear();
                        break;
                    }
                    else
                    {

                        goList.Clear();
                        break;
                    }
                }

                else
                {
                    goList.Clear();
                    break;
                }
            }
        }
        for (int i = 1; i < 8; i++)
        {
            if (i + y < 8)
            {
                if (BoardGameObject[x, y + i].GetComponent<SpriteRenderer>().color == Color.black)
                {
                    goList.Add(BoardGameObject[x, y + i]);
                }
                else if (BoardGameObject[x, y + i].GetComponent<SpriteRenderer>().color == Color.white)
                {
                    if (goList.Count > 0)
                    {
                        for (int j = 0; j < goList.Count; j++)
                        {
                            goList[j].GetComponent<SpriteRenderer>().color = Color.white;
                        }
                        goList.Clear();
                        break;
                    }
                    else
                    {

                        goList.Clear();
                        break;
                    }
                }

                else
                {
                    goList.Clear();
                    break;
                }
            }
        }
        for (int i = 1; i < 8; i++)
        {
            if (y - i > -1)
            {
                if (BoardGameObject[x, y - i].GetComponent<SpriteRenderer>().color == Color.black)
                {
                    goList.Add(BoardGameObject[x, y - i]);
                }
                else if (BoardGameObject[x, y - i].GetComponent<SpriteRenderer>().color == Color.white)
                {
                    if (goList.Count > 0)
                    {
                        for (int j = 0; j < goList.Count; j++)
                        {
                            goList[j].GetComponent<SpriteRenderer>().color = Color.white;
                        }
                        goList.Clear();
                        break;
                    }
                    else
                    {

                        goList.Clear();
                        break;
                    }
                }

                else
                {
                    goList.Clear();
                    break;
                }
            }
        }
        for (int i = 1; i < 8; i++)
        {
            if (i + x < 8 && i + y < 8)
            {
                if (BoardGameObject[x + i, y + i].GetComponent<SpriteRenderer>().color == Color.black)
                {
                    goList.Add(BoardGameObject[x + i, y + i]);
                }
                else if (BoardGameObject[x + i, y + i].GetComponent<SpriteRenderer>().color == Color.white)
                {
                    if (goList.Count > 0)
                    {
                        for (int j = 0; j < goList.Count; j++)
                        {
                            goList[j].GetComponent<SpriteRenderer>().color = Color.white;
                        }
                        goList.Clear();
                        break;
                    }
                    else
                    {

                        goList.Clear();
                        break;
                    }
                }

                else
                {
                    goList.Clear();
                    break;
                }
            }
        }
        for (int i = 1; i < 8; i++)
        {
            if (i + x < 8 && y - i > -1)
            {
                if (BoardGameObject[x + i, y - i].GetComponent<SpriteRenderer>().color == Color.black)
                {
                    goList.Add(BoardGameObject[x + i, y - i]);
                }
                else if (BoardGameObject[x + i, y - i].GetComponent<SpriteRenderer>().color == Color.white)
                {
                    if (goList.Count > 0)
                    {
                        for (int j = 0; j < goList.Count; j++)
                        {
                            goList[j].GetComponent<SpriteRenderer>().color = Color.white;
                        }
                        goList.Clear();
                        break;
                    }
                    else
                    {

                        goList.Clear();
                        break;
                    }
                }

                else
                {
                    goList.Clear();
                    break;
                }
            }
        }
        for (int i = 1; i < 8; i++)
        {
            if (x - i > -1 && y - i > -1)
            {
                if (BoardGameObject[x - i, y - i].GetComponent<SpriteRenderer>().color == Color.black)
                {
                    goList.Add(BoardGameObject[x - i, y - i]);
                }
                else if (BoardGameObject[x - i, y - i].GetComponent<SpriteRenderer>().color == Color.white)
                {
                    if (goList.Count > 0)
                    {
                        for (int j = 0; j < goList.Count; j++)
                        {
                            goList[j].GetComponent<SpriteRenderer>().color = Color.white;
                        }
                        goList.Clear();
                        break;
                    }
                    else
                    {

                        goList.Clear();
                        break;
                    }
                }

                else
                {
                    goList.Clear();
                    break;
                }
            }
        }
        for (int i = 1; i < 8; i++)
        {
            if (x - i > -1 && i + y < 8)
            {
                if (BoardGameObject[x - i, y + i].GetComponent<SpriteRenderer>().color == Color.black)
                {
                    goList.Add(BoardGameObject[x - i, y + i]);
                }
                else if (BoardGameObject[x - i, y + i].GetComponent<SpriteRenderer>().color == Color.white)
                {
                    if (goList.Count > 0)
                    {
                        for (int j = 0; j < goList.Count; j++)
                        {
                            goList[j].GetComponent<SpriteRenderer>().color = Color.white;
                        }
                        goList.Clear();
                        break;
                    }
                    else
                    {

                        goList.Clear();
                        break;
                    }
                }

                else
                {
                    goList.Clear();
                    break;
                }
            }
        }

    }

    public void CheckBlackMove(int x, int y)
    {
        if (BoardGameObject[x, y].GetComponent<SpriteRenderer>().color == Color.clear)
            BoardGameObject[x, y].GetComponent<SpriteRenderer>().color = Color.black;
        List<GameObject> goList = new List<GameObject>();
        for (int i = 1; i < 8; i++)
        {
            if (i + x < 8)
            {
                if (BoardGameObject[x + i, y].GetComponent<SpriteRenderer>().color == Color.white)
                {
                    goList.Add(BoardGameObject[x + i, y]);
                }
                else if (BoardGameObject[x + i, y].GetComponent<SpriteRenderer>().color == Color.black)
                {
                    if (goList.Count > 0)
                    {
                        for (int j = 0; j < goList.Count; j++)
                        {
                            goList[j].GetComponent<SpriteRenderer>().color = Color.black;
                        }
                        goList.Clear();
                        break;
                    }
                    else
                    {

                        goList.Clear();
                        break;
                    }
                }

                else
                {
                    goList.Clear();
                    break;
                }
            }
        }
        for (int i = 1; i < 8; i++)
        {
            if (x - i > -1)
            {
                if (BoardGameObject[x - i, y].GetComponent<SpriteRenderer>().color == Color.white)
                {
                    goList.Add(BoardGameObject[x - i, y]);
                }
                else if (BoardGameObject[x - i, y].GetComponent<SpriteRenderer>().color == Color.black)
                {
                    if (goList.Count > 0)
                    {
                        for (int j = 0; j < goList.Count; j++)
                        {
                            goList[j].GetComponent<SpriteRenderer>().color = Color.black;
                        }
                        goList.Clear();
                        break;
                    }
                    else
                    {

                        goList.Clear();
                        break;
                    }
                }

                else
                {
                    goList.Clear();
                    break;
                }
            }
        }
        for (int i = 1; i < 8; i++)
        {
            if (i + y < 8)
            {
                if (BoardGameObject[x, y + i].GetComponent<SpriteRenderer>().color == Color.white)
                {
                    goList.Add(BoardGameObject[x, y + i]);
                }
                else if (BoardGameObject[x, y + i].GetComponent<SpriteRenderer>().color == Color.black)
                {
                    if (goList.Count > 0)
                    {
                        for (int j = 0; j < goList.Count; j++)
                        {
                            goList[j].GetComponent<SpriteRenderer>().color = Color.black;
                        }
                        goList.Clear();
                        break;
                    }
                    else
                    {

                        goList.Clear();
                        break;
                    }
                }

                else
                {
                    goList.Clear();
                    break;
                }
            }
        }
        for (int i = 1; i < 8; i++)
        {
            if (y - i > -1)
            {
                if (BoardGameObject[x, y - i].GetComponent<SpriteRenderer>().color == Color.white)
                {
                    goList.Add(BoardGameObject[x, y - i]);
                }
                else if (BoardGameObject[x, y - i].GetComponent<SpriteRenderer>().color == Color.black)
                {
                    if (goList.Count > 0)
                    {
                        for (int j = 0; j < goList.Count; j++)
                        {
                            goList[j].GetComponent<SpriteRenderer>().color = Color.black;
                        }
                        goList.Clear();
                        break;
                    }
                    else
                    {

                        goList.Clear();
                        break;
                    }
                }

                else
                {
                    goList.Clear();
                    break;
                }
            }
        }
        for (int i = 1; i < 8; i++)
        {
            if (i + x < 8 && i + y < 8)
            {
                if (BoardGameObject[x + i, y + i].GetComponent<SpriteRenderer>().color == Color.white)
                {
                    goList.Add(BoardGameObject[x + i, y + i]);
                }
                else if (BoardGameObject[x + i, y + i].GetComponent<SpriteRenderer>().color == Color.black)
                {
                    if (goList.Count > 0)
                    {
                        for (int j = 0; j < goList.Count; j++)
                        {
                            goList[j].GetComponent<SpriteRenderer>().color = Color.black;
                        }
                        goList.Clear();
                        break;
                    }
                    else
                    {

                        goList.Clear();
                        break;
                    }
                }

                else
                {
                    goList.Clear();
                    break;
                }
            }
        }
        for (int i = 1; i < 8; i++)
        {
            if (i + x < 8 && y - i > -1)
            {
                if (BoardGameObject[x + i, y - i].GetComponent<SpriteRenderer>().color == Color.white)
                {
                    goList.Add(BoardGameObject[x + i, y - i]);
                }
                else if (BoardGameObject[x + i, y - i].GetComponent<SpriteRenderer>().color == Color.black)
                {
                    if (goList.Count > 0)
                    {
                        for (int j = 0; j < goList.Count; j++)
                        {
                            goList[j].GetComponent<SpriteRenderer>().color = Color.black;
                        }
                        goList.Clear();
                        break;
                    }
                    else
                    {

                        goList.Clear();
                        break;
                    }
                }

                else
                {
                    goList.Clear();
                    break;
                }
            }
        }
        for (int i = 1; i < 8; i++)
        {
            if (x - i > -1 && y - i > -1)
            {
                if (BoardGameObject[x - i, y - i].GetComponent<SpriteRenderer>().color == Color.white)
                {
                    goList.Add(BoardGameObject[x - i, y - i]);
                }
                else if (BoardGameObject[x - i, y - i].GetComponent<SpriteRenderer>().color == Color.black)
                {
                    if (goList.Count > 0)
                    {
                        for (int j = 0; j < goList.Count; j++)
                        {
                            goList[j].GetComponent<SpriteRenderer>().color = Color.black;
                        }
                        goList.Clear();
                        break;
                    }
                    else
                    {

                        goList.Clear();
                        break;
                    }
                }

                else
                {
                    goList.Clear();
                    break;
                }
            }
        }
        for (int i = 1; i < 8; i++)
        {
            if (x - i > -1 && i + y < 8)
            {
                if (BoardGameObject[x - i, y + i].GetComponent<SpriteRenderer>().color == Color.white)
                {
                    goList.Add(BoardGameObject[x - i, y + i]);
                }
                else if (BoardGameObject[x - i, y + i].GetComponent<SpriteRenderer>().color == Color.black)
                {
                    if (goList.Count > 0)
                    {
                        for (int j = 0; j < goList.Count; j++)
                        {
                            goList[j].GetComponent<SpriteRenderer>().color = Color.black;
                        }
                        goList.Clear();
                        break;
                    }
                    else
                    {

                        goList.Clear();
                        break;
                    }
                }

                else
                {
                    goList.Clear();
                    break;
                }
            }
        }

    }


    public void CheckValidWhiteMove(int x, int y)
    {
        if (BoardGameObject[x, y].GetComponent<SpriteRenderer>().color == Color.clear)
        {
            List<GameObject> goList = new List<GameObject>();
            for (int i = 1; i < 8; i++)
            {
                if (i + x < 8)
                {
                    if (BoardGameObject[x + i, y].GetComponent<SpriteRenderer>().color == Color.black)
                    {
                        goList.Add(BoardGameObject[x + i, y]);
                    }
                    else if (BoardGameObject[x + i, y].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        if (goList.Count > 0)
                        {
                            for (int j = 0; j < goList.Count; j++)
                            {
                                BoardGameObject2[x, y].GetComponent<PieceScript>().ValidMove = true;
                            }
                            goList.Clear();
                            break;
                        }
                        else
                        {

                            goList.Clear();
                            break;
                        }
                    }

                    else
                    {
                        goList.Clear();
                        break;
                    }
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (x - i > -1)
                {
                    if (BoardGameObject[x - i, y].GetComponent<SpriteRenderer>().color == Color.black)
                    {
                        goList.Add(BoardGameObject[x - i, y]);
                    }
                    else if (BoardGameObject[x - i, y].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        if (goList.Count > 0)
                        {
                            for (int j = 0; j < goList.Count; j++)
                            {
                                BoardGameObject2[x, y].GetComponent<PieceScript>().ValidMove = true;

                            }
                            goList.Clear();
                            break;
                        }
                        else
                        {

                            goList.Clear();
                            break;
                        }
                    }

                    else
                    {
                        goList.Clear();
                        break;
                    }
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (i + y < 8)
                {
                    if (BoardGameObject[x, y + i].GetComponent<SpriteRenderer>().color == Color.black)
                    {
                        goList.Add(BoardGameObject[x, y + i]);
                    }
                    else if (BoardGameObject[x, y + i].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        if (goList.Count > 0)
                        {
                            for (int j = 0; j < goList.Count; j++)
                            {
                                BoardGameObject2[x, y].GetComponent<PieceScript>().ValidMove = true;

                            }
                            goList.Clear();
                            break;
                        }
                        else
                        {

                            goList.Clear();
                            break;
                        }
                    }

                    else
                    {
                        goList.Clear();
                        break;
                    }
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (y - i > -1)
                {
                    if (BoardGameObject[x, y - i].GetComponent<SpriteRenderer>().color == Color.black)
                    {
                        goList.Add(BoardGameObject[x, y - i]);
                    }
                    else if (BoardGameObject[x, y - i].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        if (goList.Count > 0)
                        {
                            for (int j = 0; j < goList.Count; j++)
                            {
                                BoardGameObject2[x, y].GetComponent<PieceScript>().ValidMove = true;
                            }
                            goList.Clear();
                            break;
                        }
                        else
                        {

                            goList.Clear();
                            break;
                        }
                    }

                    else
                    {
                        goList.Clear();
                        break;
                    }
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (i + x < 8 && i + y < 8)
                {
                    if (BoardGameObject[x + i, y + i].GetComponent<SpriteRenderer>().color == Color.black)
                    {
                        goList.Add(BoardGameObject[x + i, y + i]);
                    }
                    else if (BoardGameObject[x + i, y + i].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        if (goList.Count > 0)
                        {
                            for (int j = 0; j < goList.Count; j++)
                            {
                                BoardGameObject2[x, y].GetComponent<PieceScript>().ValidMove = true;
                            }
                            goList.Clear();
                            break;
                        }
                        else
                        {

                            goList.Clear();
                            break;
                        }
                    }

                    else
                    {
                        goList.Clear();
                        break;
                    }
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (i + x < 8 && y - i > -1)
                {
                    if (BoardGameObject[x + i, y - i].GetComponent<SpriteRenderer>().color == Color.black)
                    {
                        goList.Add(BoardGameObject[x + i, y - i]);
                    }
                    else if (BoardGameObject[x + i, y - i].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        if (goList.Count > 0)
                        {
                            for (int j = 0; j < goList.Count; j++)
                            {
                                BoardGameObject2[x, y].GetComponent<PieceScript>().ValidMove = true;
                            }
                            goList.Clear();
                            break;
                        }
                        else
                        {

                            goList.Clear();
                            break;
                        }
                    }

                    else
                    {
                        goList.Clear();
                        break;
                    }
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (x - i > -1 && y - i > -1)
                {
                    if (BoardGameObject[x - i, y - i].GetComponent<SpriteRenderer>().color == Color.black)
                    {
                        goList.Add(BoardGameObject[x - i, y - i]);
                    }
                    else if (BoardGameObject[x - i, y - i].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        if (goList.Count > 0)
                        {
                            for (int j = 0; j < goList.Count; j++)
                            {
                                BoardGameObject2[x, y].GetComponent<PieceScript>().ValidMove = true;
                            }
                            goList.Clear();
                            break;
                        }
                        else
                        {

                            goList.Clear();
                            break;
                        }
                    }

                    else
                    {
                        goList.Clear();
                        break;
                    }
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (x - i > -1 && i + y < 8)
                {
                    if (BoardGameObject[x - i, y + i].GetComponent<SpriteRenderer>().color == Color.black)
                    {
                        goList.Add(BoardGameObject[x - i, y + i]);
                    }
                    else if (BoardGameObject[x - i, y + i].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        if (goList.Count > 0)
                        {
                            for (int j = 0; j < goList.Count; j++)
                            {
                                BoardGameObject2[x, y].GetComponent<PieceScript>().ValidMove = true;
                            }
                            goList.Clear();
                            break;
                        }
                        else
                        {

                            goList.Clear();
                            break;
                        }
                    }

                    else
                    {
                        goList.Clear();
                        break;
                    }
                }
            }
        }
    }

    public void CheckValidBlackMove(int x, int y)
    {
        List<GameObject> goList = new List<GameObject>();
        if (BoardGameObject[x, y].GetComponent<SpriteRenderer>().color == Color.clear)
        {
            for (int i = 1; i < 8; i++)
            {
                if (i + x < 8)
                {
                    if (BoardGameObject[x + i, y].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        goList.Add(BoardGameObject[x + i, y]);
                    }
                    else if (BoardGameObject[x + i, y].GetComponent<SpriteRenderer>().color == Color.black)
                    {
                        if (goList.Count > 0)
                        {
                            for (int j = 0; j < goList.Count; j++)
                            {
                                BoardGameObject2[x, y].GetComponent<PieceScript>().ValidMove = true;
                            }
                            goList.Clear();
                            break;
                        }
                        else
                        {

                            goList.Clear();
                            break;
                        }
                    }
                    else
                    {
                        goList.Clear();
                        break;
                    }
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (x - i > -1)
                {
                    if (BoardGameObject[x - i, y].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        goList.Add(BoardGameObject[x - i, y]);
                    }
                    else if (BoardGameObject[x - i, y].GetComponent<SpriteRenderer>().color == Color.black)
                    {
                        if (goList.Count > 0)
                        {
                            for (int j = 0; j < goList.Count; j++)
                            {
                                BoardGameObject2[x, y].GetComponent<PieceScript>().ValidMove = true;
                            }
                            goList.Clear();
                            break;
                        }
                        else
                        {

                            goList.Clear();
                            break;
                        }
                    }

                    else
                    {
                        goList.Clear();
                        break;
                    }
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (i + y < 8)
                {
                    if (BoardGameObject[x, y + i].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        goList.Add(BoardGameObject[x, y + i]);
                    }
                    else if (BoardGameObject[x, y + i].GetComponent<SpriteRenderer>().color == Color.black)
                    {
                        if (goList.Count > 0)
                        {
                            for (int j = 0; j < goList.Count; j++)
                            {
                                BoardGameObject2[x, y].GetComponent<PieceScript>().ValidMove = true;
                            }
                            goList.Clear();
                            break;
                        }
                        else
                        {

                            goList.Clear();
                            break;
                        }
                    }

                    else
                    {
                        goList.Clear();
                        break;
                    }
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (y - i > -1)
                {
                    if (BoardGameObject[x, y - i].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        goList.Add(BoardGameObject[x, y - i]);
                    }
                    else if (BoardGameObject[x, y - i].GetComponent<SpriteRenderer>().color == Color.black)
                    {
                        if (goList.Count > 0)
                        {
                            for (int j = 0; j < goList.Count; j++)
                            {
                                BoardGameObject2[x, y].GetComponent<PieceScript>().ValidMove = true;
                            }
                            goList.Clear();
                            break;
                        }
                        else
                        {

                            goList.Clear();
                            break;
                        }
                    }

                    else
                    {
                        goList.Clear();
                        break;
                    }
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (i + x < 8 && i + y < 8)
                {
                    if (BoardGameObject[x + i, y + i].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        goList.Add(BoardGameObject[x + i, y + i]);
                    }
                    else if (BoardGameObject[x + i, y + i].GetComponent<SpriteRenderer>().color == Color.black)
                    {
                        if (goList.Count > 0)
                        {
                            for (int j = 0; j < goList.Count; j++)
                            {
                                BoardGameObject2[x, y].GetComponent<PieceScript>().ValidMove = true;
                            }
                            goList.Clear();
                            break;
                        }
                        else
                        {

                            goList.Clear();
                            break;
                        }
                    }

                    else
                    {
                        goList.Clear();
                        break;
                    }
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (i + x < 8 && y - i > -1)
                {
                    if (BoardGameObject[x + i, y - i].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        goList.Add(BoardGameObject[x + i, y - i]);
                    }
                    else if (BoardGameObject[x + i, y - i].GetComponent<SpriteRenderer>().color == Color.black)
                    {
                        if (goList.Count > 0)
                        {
                            for (int j = 0; j < goList.Count; j++)
                            {
                                BoardGameObject2[x, y].GetComponent<PieceScript>().ValidMove = true;
                            }
                            goList.Clear();
                            break;
                        }
                        else
                        {

                            goList.Clear();
                            break;
                        }
                    }

                    else
                    {
                        goList.Clear();
                        break;
                    }
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (x - i > -1 && y - i > -1)
                {
                    if (BoardGameObject[x - i, y - i].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        goList.Add(BoardGameObject[x - i, y - i]);
                    }
                    else if (BoardGameObject[x - i, y - i].GetComponent<SpriteRenderer>().color == Color.black)
                    {
                        if (goList.Count > 0)
                        {
                            for (int j = 0; j < goList.Count; j++)
                            {
                                BoardGameObject2[x, y].GetComponent<PieceScript>().ValidMove = true;
                            }
                            goList.Clear();
                            break;
                        }
                        else
                        {

                            goList.Clear();
                            break;
                        }
                    }

                    else
                    {
                        goList.Clear();
                        break;
                    }
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (x - i > -1 && i + y < 8)
                {
                    if (BoardGameObject[x - i, y + i].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        goList.Add(BoardGameObject[x - i, y + i]);
                    }
                    else if (BoardGameObject[x - i, y + i].GetComponent<SpriteRenderer>().color == Color.black)
                    {
                        if (goList.Count > 0)
                        {
                            for (int j = 0; j < goList.Count; j++)
                            {
                                BoardGameObject2[x, y].GetComponent<PieceScript>().ValidMove = true;
                            }
                            goList.Clear();
                            break;
                        }
                        else
                        {

                            goList.Clear();
                            break;
                        }
                    }

                    else
                    {
                        goList.Clear();
                        break;
                    }
                }
            }
        }
    }

    public void CheckValid()
    {
        ClearValid();
        if (IsWhite)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    CheckValidWhiteMove(i, j);
                }
            }
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    CheckValidBlackMove(i, j);
                }
            }
        }
    }
    public void ClearValid()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                BoardGameObject2[i, j].GetComponent<PieceScript>().ValidMove = false;
            }
        }
    }
    public void ChangeStatus()
    {
        if (IsWhite)
        {
            Pointer.GetComponent<SpriteRenderer>().color = Color.black;
            IsWhite = false;
        }
        else
        {
            Pointer.GetComponent<SpriteRenderer>().color = Color.white;
            IsWhite = true;
        }

    }
}
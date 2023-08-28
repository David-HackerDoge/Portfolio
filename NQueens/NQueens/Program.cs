using NQueens;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

//checks if two lists of lists have the exact same contents
bool listsEqual(List<List<int>> list1, List<List<int>> list2)
{
    if (list1.Count != list2.Count || list1[0].Count != list2[0].Count)
    {
        return false;
    }
    for(int i = 0; i < list1.Count; i++)
    {
        for(int j = 0; j < list1[0].Count; j++)
        {
            if (list1[i][j] != list2[i][j])
            {
                return false;
            }
        }
    }
    return true;
}

//tests the NQueens algorithm(single solution) against correct hardcoded values
bool testNQueenSingle()
{
    bool working = true;
    ChessBoard cb = new ChessBoard(4);
    List<List<int>> board = cb.QueensSingle();

    //test1
    List<List<int>> correctList1 = new List<List<int>>();
    for (int i = 0; i < 4; i++)
    {
        correctList1.Add(new List<int>());
        for (int j = 0; j < 4; j++)
        {
            correctList1[i].Add(0);
        }
    }
    correctList1[0][2] = 1;
    correctList1[1][0] = 1;
    correctList1[2][3] = 1;
    correctList1[3][1] = 1;
    List<List<int>> correctList2 = new List<List<int>>();
    for (int i = 0; i < 4; i++)
    {
        correctList2.Add(new List<int>());
        for (int j = 0; j < 4; j++)
        {
            correctList2[i].Add(0);
        }
    }
    correctList2[0][1] = 1;
    correctList2[1][3] = 1;
    correctList2[2][0] = 1;
    correctList2[3][2] = 1;

    if (listsEqual(board, correctList1) || listsEqual(board, correctList2))
    {
        Console.WriteLine("NQueens algorithm(single solution) test 1 passed!");
        working = true;
    }
    else
    {
        Console.WriteLine("NQueens algorithm(single solution) test 1 failed...");
        working = false;
    }

    //test2
    cb = new ChessBoard(5);
    board = cb.QueensSingle();

    correctList1 = new List<List<int>>();
    for (int i = 0; i < 5; i++)
    {
        correctList1.Add(new List<int>());
        for (int j = 0; j < 5; j++)
        {
            correctList1[i].Add(0);
        }
    }
    correctList2 = new List<List<int>>();
    for (int i = 0; i < 5; i++)
    {
        correctList2.Add(new List<int>());
        for (int j = 0; j < 5; j++)
        {
            correctList2[i].Add(0);
        }
    }
    List<List<int>> correctList3 = new List<List<int>>();
    for (int i = 0; i < 5; i++)
    {
        correctList3.Add(new List<int>());
        for (int j = 0; j < 5; j++)
        {
            correctList3[i].Add(0);
        }
    }
    List<List<int>> correctList4 = new List<List<int>>();
    for (int i = 0; i < 5; i++)
    {
        correctList4.Add(new List<int>());
        for (int j = 0; j < 5; j++)
        {
            correctList4[i].Add(0);
        }
    }
    List<List<int>> correctList5 = new List<List<int>>();
    for (int i = 0; i < 5; i++)
    {
        correctList5.Add(new List<int>());
        for (int j = 0; j < 5; j++)
        {
            correctList5[i].Add(0);
        }
    }
    List<List<int>> correctList6 = new List<List<int>>();
    for (int i = 0; i < 5; i++)
    {
        correctList6.Add(new List<int>());
        for (int j = 0; j < 5; j++)
        {
            correctList6[i].Add(0);
        }
    }
    List<List<int>> correctList7 = new List<List<int>>();
    for (int i = 0; i < 5; i++)
    {
        correctList7.Add(new List<int>());
        for (int j = 0; j < 5; j++)
        {
            correctList7[i].Add(0);
        }
    }
    List<List<int>> correctList8 = new List<List<int>>();
    for (int i = 0; i < 5; i++)
    {
        correctList8.Add(new List<int>());
        for (int j = 0; j < 5; j++)
        {
            correctList8[i].Add(0);
        }
    }
    List<List<int>> correctList9 = new List<List<int>>();
    for (int i = 0; i < 5; i++)
    {
        correctList9.Add(new List<int>());
        for (int j = 0; j < 5; j++)
        {
            correctList9[i].Add(0);
        }
    }
    List<List<int>> correctList10 = new List<List<int>>();
    for (int i = 0; i < 5; i++)
    {
        correctList10.Add(new List<int>());
        for (int j = 0; j < 5; j++)
        {
            correctList10[i].Add(0);
        }
    }

    correctList1[0][4] = 1;
    correctList1[1][1] = 1;
    correctList1[2][3] = 1;
    correctList1[3][0] = 1;
    correctList1[4][2] = 1;

    correctList2[0][2] = 1;
    correctList2[1][0] = 1;
    correctList2[2][3] = 1;
    correctList2[3][1] = 1;
    correctList2[4][4] = 1;

    correctList3[0][0] = 1;
    correctList3[1][3] = 1;
    correctList3[2][1] = 1;
    correctList3[3][4] = 1;
    correctList3[4][2] = 1;

    correctList4[0][0] = 1;
    correctList4[1][2] = 1;
    correctList4[2][4] = 1;
    correctList4[3][1] = 1;
    correctList4[4][3] = 1;

    correctList5[0][2] = 1;
    correctList5[1][4] = 1;
    correctList5[2][1] = 1;
    correctList5[3][3] = 1;
    correctList5[4][0] = 1;

    correctList6[0][1] = 1;
    correctList6[1][3] = 1;
    correctList6[2][0] = 1;
    correctList6[3][2] = 1;
    correctList6[4][4] = 1;

    correctList7[0][4] = 1;
    correctList7[1][2] = 1;
    correctList7[2][0] = 1;
    correctList7[3][3] = 1;
    correctList7[4][1] = 1;

    correctList8[0][3] = 1;
    correctList8[1][1] = 1;
    correctList8[2][4] = 1;
    correctList8[3][2] = 1;
    correctList8[4][0] = 1;

    correctList9[0][3] = 1;
    correctList9[1][0] = 1;
    correctList9[2][2] = 1;
    correctList9[3][4] = 1;
    correctList9[4][1] = 1;

    correctList10[0][0] = 1;
    correctList10[1][2] = 4;
    correctList10[2][4] = 2;
    correctList10[3][1] = 0;
    correctList10[4][3] = 3;

    if (listsEqual(board, correctList1) || listsEqual(board, correctList2) || listsEqual(board, correctList3)
        || listsEqual(board, correctList4) || listsEqual(board, correctList5) || listsEqual(board, correctList6)
        || listsEqual(board, correctList7) || listsEqual(board, correctList8) || listsEqual(board, correctList9)
        || listsEqual(board, correctList10))
    {
        Console.WriteLine("NQueens algorithm(single solution) test 2 passed!");
        working = true;
    }
    else
    {
        Console.WriteLine("NQueens algorithm(single solution) test 2 failed...");
        working = false;
    }

    return working;
}

//tests the NQueens algorithm(all solutions) against correct hardcoded values
bool testNQueenAll()
{
    bool working = true;
    ChessBoard cb = new ChessBoard(4);
    List<List<List<int>>> boards = cb.QueensAll();

    //test1
    List<List<int>> correctList1 = new List<List<int>>();
    for (int i = 0; i < 4; i++)
    {
        correctList1.Add(new List<int>());
        for (int j = 0; j < 4; j++)
        {
            correctList1[i].Add(0);
        }
    }
    correctList1[0][1] = 1;
    correctList1[1][3] = 1;
    correctList1[2][0] = 1;
    correctList1[3][2] = 1;
    List<List<int>> correctList2 = new List<List<int>>();
    for (int i = 0; i < 4; i++)
    {
        correctList2.Add(new List<int>());
        for (int j = 0; j < 4; j++)
        {
            correctList2[i].Add(0);
        }
    }
    correctList2[0][2] = 1;
    correctList2[1][0] = 1;
    correctList2[2][3] = 1;
    correctList2[3][1] = 1;

    List<List<List<int>>> correctLists = new List<List<List<int>>>();
    correctLists.Add(correctList1);
    correctLists.Add(correctList2);

    bool exact = true;
    for(int i = 0; i < 2; i++)
    {
        if (!listsEqual(boards[i], correctLists[i]))
        {
            exact = false;
        }
    }
    if(exact == true)
    {
        Console.WriteLine("NQueens algorithm(all solutions) test 1 passed!");
        working = true;
    }
    else
    {
        Console.WriteLine("NQueens algorithm(all solutions) test 1 failed...");
        working = false;
    }

    //test2
    cb = new ChessBoard(5);
    boards = cb.QueensAll();

    correctList1 = new List<List<int>>();
    for (int i = 0; i < 5; i++)
    {
        correctList1.Add(new List<int>());
        for (int j = 0; j < 5; j++)
        {
            correctList1[i].Add(0);
        }
    }
    correctList2 = new List<List<int>>();
    for (int i = 0; i < 5; i++)
    {
        correctList2.Add(new List<int>());
        for (int j = 0; j < 5; j++)
        {
            correctList2[i].Add(0);
        }
    }
    List<List<int>> correctList3 = new List<List<int>>();
    for (int i = 0; i < 5; i++)
    {
        correctList3.Add(new List<int>());
        for (int j = 0; j < 5; j++)
        {
            correctList3[i].Add(0);
        }
    }
    List<List<int>> correctList4 = new List<List<int>>();
    for (int i = 0; i < 5; i++)
    {
        correctList4.Add(new List<int>());
        for (int j = 0; j < 5; j++)
        {
            correctList4[i].Add(0);
        }
    }
    List<List<int>> correctList5 = new List<List<int>>();
    for (int i = 0; i < 5; i++)
    {
        correctList5.Add(new List<int>());
        for (int j = 0; j < 5; j++)
        {
            correctList5[i].Add(0);
        }
    }
    List<List<int>> correctList6 = new List<List<int>>();
    for (int i = 0; i < 5; i++)
    {
        correctList6.Add(new List<int>());
        for (int j = 0; j < 5; j++)
        {
            correctList6[i].Add(0);
        }
    }
    List<List<int>> correctList7 = new List<List<int>>();
    for (int i = 0; i < 5; i++)
    {
        correctList7.Add(new List<int>());
        for (int j = 0; j < 5; j++)
        {
            correctList7[i].Add(0);
        }
    }
    List<List<int>> correctList8 = new List<List<int>>();
    for (int i = 0; i < 5; i++)
    {
        correctList8.Add(new List<int>());
        for (int j = 0; j < 5; j++)
        {
            correctList8[i].Add(0);
        }
    }
    List<List<int>> correctList9 = new List<List<int>>();
    for (int i = 0; i < 5; i++)
    {
        correctList9.Add(new List<int>());
        for (int j = 0; j < 5; j++)
        {
            correctList9[i].Add(0);
        }
    }
    List<List<int>> correctList10 = new List<List<int>>();
    for (int i = 0; i < 5; i++)
    {
        correctList10.Add(new List<int>());
        for (int j = 0; j < 5; j++)
        {
            correctList10[i].Add(0);
        }
    }

    correctList1[0][4] = 1;
    correctList1[1][1] = 1;
    correctList1[2][3] = 1;
    correctList1[3][0] = 1;
    correctList1[4][2] = 1;

    correctList2[0][2] = 1;
    correctList2[1][0] = 1;
    correctList2[2][3] = 1;
    correctList2[3][1] = 1;
    correctList2[4][4] = 1;

    correctList3[0][0] = 1;
    correctList3[1][3] = 1;
    correctList3[2][1] = 1;
    correctList3[3][4] = 1;
    correctList3[4][2] = 1;

    correctList4[0][0] = 1;
    correctList4[1][2] = 1;
    correctList4[2][4] = 1;
    correctList4[3][1] = 1;
    correctList4[4][3] = 1;

    correctList5[0][2] = 1;
    correctList5[1][4] = 1;
    correctList5[2][1] = 1;
    correctList5[3][3] = 1;
    correctList5[4][0] = 1;

    correctList6[0][1] = 1;
    correctList6[1][3] = 1;
    correctList6[2][0] = 1;
    correctList6[3][2] = 1;
    correctList6[4][4] = 1;

    correctList7[0][4] = 1;
    correctList7[1][2] = 1;
    correctList7[2][0] = 1;
    correctList7[3][3] = 1;
    correctList7[4][1] = 1;

    correctList8[0][3] = 1;
    correctList8[1][1] = 1;
    correctList8[2][4] = 1;
    correctList8[3][2] = 1;
    correctList8[4][0] = 1;

    correctList9[0][3] = 1;
    correctList9[1][0] = 1;
    correctList9[2][2] = 1;
    correctList9[3][4] = 1;
    correctList9[4][1] = 1;

    correctList10[0][1] = 1;
    correctList10[1][4] = 1;
    correctList10[2][2] = 1;
    correctList10[3][0] = 1;
    correctList10[4][3] = 1;

    correctLists.Clear();
    correctLists.Add(correctList4);
    correctLists.Add(correctList3);
    correctLists.Add(correctList6);
    correctLists.Add(correctList10);
    correctLists.Add(correctList2);
    correctLists.Add(correctList5);
    correctLists.Add(correctList9);
    correctLists.Add(correctList8);
    correctLists.Add(correctList1);
    correctLists.Add(correctList7);
    exact = true;

    for (int i = 0; i < 10; i++)
    {
        if (!listsEqual(boards[i], correctLists[i]))
        {
            exact = false;
        }
    }

    if (exact == true)
    {
        Console.WriteLine("NQueens algorithm(all solutions) test 2 passed!");
        working = true;
    }
    else
    {
        Console.WriteLine("NQueens algorithm(all solutions) test 2 failed...");
        working = false;
    }

    return working;
}

//running tests and displaying results
if (testNQueenSingle() == true)
    Console.WriteLine("NQueens algorithm(single solution) working correctly!");
else
    Console.WriteLine("NQueens algorithm(single solution) NOT working correctly...");
if (testNQueenAll() == true)
    Console.WriteLine("NQueens algorithm(all solutions) working correctly!");
else
    Console.WriteLine("NQueens algorithm(all solutions) NOT working correctly...");

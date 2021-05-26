using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form2 : Form
    {
        private Rectangle[] boardColumns;
        private Rectangle[] boardRow;
        private int[,] board;
        private int turn;
        public Form2()
        {
            InitializeComponent();
            boardColumns = new Rectangle[3];
            boardRow = new Rectangle[3];
            board = new int[3, 3];
            turn = 1;
        }
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Black, 24, 24, 290, 290);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 0)
                    {
                        boardColumns[j] = new Rectangle(24 + 100 * j, 24, 90, 290);
                        boardRow[j] = new Rectangle(24, 24 + 100 * j, 290, 90);
                    }
                    e.Graphics.FillRectangle(Brushes.White, 24 + 100 * j, 24 + 100 * i, 90, 90);
                }
            }
        }
        private int numberOfTurns = 0;
        private int Column0Row0Used = 0;
        private int Column1Row0Used = 0;
        private int Column2Row0Used = 0;
        private int Column0Row1Used = 0;
        private int Column1Row1Used = 0;
        private int Column2Row1Used = 0;
        private int Column0Row2Used = 0;
        private int Column1Row2Used = 0;
        private int Column2Row2Used = 0;

        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {
            int columnIndex = ColumnNumber(e.Location); // check that column is within the game board
            if (columnIndex != -1)
            {
                int rowIndex = RowNumber(e.Location); // check that row is within the game board
                if (rowIndex != -1)
                {
                    if (columnIndex == 0 && rowIndex == 0)
                    {
                        Column0Row0Used++;
                    }
                    else if (columnIndex == 1 && rowIndex == 0)
                    {
                        Column1Row0Used++;
                    }
                    else if (columnIndex == 2 && rowIndex == 0)
                    {
                        Column2Row0Used++;
                    }
                    else if (columnIndex == 0 && rowIndex == 1)
                    {
                        Column0Row1Used++;
                    }
                    else if (columnIndex == 1 && rowIndex == 1)
                    {
                        Column1Row1Used++;
                    }
                    else if (columnIndex == 2 && rowIndex == 1)
                    {
                        Column2Row1Used++;
                    }
                    else if (columnIndex == 0 && rowIndex == 2)
                    {
                        Column0Row2Used++;
                    }
                    else if (columnIndex == 1 && rowIndex == 2)
                    {
                        Column1Row2Used++;
                    }
                    else if (columnIndex == 2 && rowIndex == 2)
                    {
                        Column2Row2Used++;
                    }
                    // Statements are to check whether the row and column is used and if so if the value of column index, row index is 1 it means that it is used
                    if (Column0Row0Used < 2 && Column1Row0Used < 2 && Column2Row0Used < 2 && Column0Row1Used < 2 && Column1Row1Used < 2 && Column2Row1Used < 2 && Column0Row2Used < 2 && Column1Row2Used < 2 && Column2Row2Used < 2)
                    {
                        board[rowIndex, columnIndex] = turn;
                        Graphics g = CreateGraphics();
                        g.FillEllipse(Brushes.Red, 24 + 100 * columnIndex, 24 + 100 * rowIndex, 90, 90);
                        numberOfTurns++; // When a turn is completed there are (9 - numberOfTurns) turns left
                    }
                    else // If a point is clicked more than once
                    {
                        if (Column0Row0Used == 2)
                        {
                            Column0Row0Used--;
                        }
                        else if (Column1Row0Used == 2)
                        {
                            Column1Row0Used--;
                        }
                        else if (Column2Row0Used == 2)
                        {
                            Column2Row0Used--;
                        }
                        else if (Column0Row1Used == 2)
                        {
                            Column0Row1Used--;
                        }
                        else if (Column1Row1Used == 2)
                        {
                            Column1Row1Used--;
                        }
                        else if (Column2Row1Used == 2)
                        {
                            Column2Row1Used--;
                        }
                        else if (Column0Row2Used == 2)
                        {
                            Column0Row2Used--;
                        }
                        else if (Column1Row2Used == 2)
                        {
                            Column1Row2Used--;
                        }
                        else if (Column2Row2Used == 2)
                        {
                            Column2Row2Used--;
                        }
                        // Above statements are to subtract the column index and row index used by 1 so that when the mouse is clicked again the event handler occurs
                        if (turn == 1)
                        {
                            turn = 2;
                        }
                        // Above statements are a trick to change the turn so that when the turn is changed again in the statement below, if the mouse is clicked when the column index, row index is filled, it will not be  valid turn
                    }
                    int winner = WinnerPlayer(turn); // The winner can only be the player whose turn it was
                    if (numberOfTurns == 9 && winner == -1) // All column indexes, row indexes are filled and the game restarts
                    {
                        MessageBox.Show("Both Players Have Tied");
                        Form.ActiveForm.Hide();
                        Form PlayComputer = new Form2();
                        PlayComputer.ShowDialog();
                    }
                    if (winner != -1)
                    {
                        if (textBox1.Text == "")
                        {
                            MessageBox.Show("Congratulations! Red Wins");
                        }
                        else
                        {
                            MessageBox.Show("Congratulations! " + textBox1.Text + " Wins");
                        }
                        Form.ActiveForm.Hide();
                        Form PlayComputer = new Form2();
                        PlayComputer.ShowDialog();
                    }
                    if (turn == 1)
                    {
                        bool Clicked = false;
                        while (Clicked == false)
                        {
                            turn = 2;
                            if (ComputerTurn(turn) == 1)
                            {
                                columnIndex = 0;
                                rowIndex = 0;                
                            }
                            else if (ComputerTurn(turn) == 2)
                            {
                                columnIndex = 1;
                                rowIndex = 0;              
                            }
                            else if (ComputerTurn(turn) == 3)
                            {
                                columnIndex = 2;
                                rowIndex = 0;        
                            }
                            else if (ComputerTurn(turn) == 4)
                            {
                                columnIndex = 0;
                                rowIndex = 1;                        
                            }
                            else if (ComputerTurn(turn) == 5)
                            {
                                columnIndex = 1;
                                rowIndex = 1;                            
                            }
                            else if (ComputerTurn(turn) == 6)
                            {
                                columnIndex = 2;
                                rowIndex = 1;                      
                            }
                            else if (ComputerTurn(turn) == 7)
                            {
                                columnIndex = 0;
                                rowIndex = 2;
                            }
                            else if (ComputerTurn(turn) == 8)
                            {
                                columnIndex = 1;
                                rowIndex = 2;              
                            }
                            else if (ComputerTurn(turn) == 9)
                            {
                                columnIndex = 2;
                                rowIndex = 2;                           
                            }
                            if (columnIndex == 0 && rowIndex == 0)
                            {
                                Column0Row0Used++;
                            }
                            else if (columnIndex == 1 && rowIndex == 0)
                            {
                                Column1Row0Used++;
                            }
                            else if (columnIndex == 2 && rowIndex == 0)
                            {
                                Column2Row0Used++;
                            }
                            else if (columnIndex == 0 && rowIndex == 1)
                            {
                                Column0Row1Used++;
                            }
                            else if (columnIndex == 1 && rowIndex == 1)
                            {
                                Column1Row1Used++;
                            }
                            else if (columnIndex == 2 && rowIndex == 1)
                            {
                                Column2Row1Used++;
                            }
                            else if (columnIndex == 0 && rowIndex == 2)
                            {
                                Column0Row2Used++;
                            }
                            else if (columnIndex == 1 && rowIndex == 2)
                            {
                                Column1Row2Used++;
                            }
                            else if (columnIndex == 2 && rowIndex == 2)
                            {
                                Column2Row2Used++;
                            }
                            if (Column0Row0Used == 2)
                            {
                                Column0Row0Used--;
                            }
                            else if (Column1Row0Used == 2)
                            {
                                Column1Row0Used--;
                            }
                            else if (Column2Row0Used == 2)
                            {
                                Column2Row0Used--;
                            }
                            else if (Column0Row1Used == 2)
                            {
                                Column0Row1Used--;
                            }
                            else if (Column1Row1Used == 2)
                            {
                                Column1Row1Used--;
                            }
                            else if (Column2Row1Used == 2)
                            {
                                Column2Row1Used--;
                            }
                            else if (Column0Row2Used == 2)
                            {
                                Column0Row2Used--;
                            }
                            else if (Column1Row2Used == 2)
                            {
                                Column1Row2Used--;
                            }
                            else if (Column2Row2Used == 2)
                            {
                                Column2Row2Used--;
                            }
                            else
                            {
                                numberOfTurns++;
                                board[rowIndex, columnIndex] = turn;
                                Graphics g = CreateGraphics();
                                g.FillEllipse(Brushes.Yellow, 24 + 100 * columnIndex, 24 + 100 * rowIndex, 90, 90);
                                winner = WinnerPlayer(turn);
                                if (numberOfTurns == 9 && winner == -1) // All column indexes, row indexes are filled and the game restarts
                                {
                                    MessageBox.Show("Both Players Have Tied");
                                    Form.ActiveForm.Hide();
                                    Form PlayComputer = new Form2();
                                    PlayComputer.ShowDialog();
                                }
                                if (winner != -1)
                                {
                                    MessageBox.Show("Game Over! Computer Wins");
                                    Form.ActiveForm.Hide();
                                    Form PlayComputer = new Form2();
                                    PlayComputer.ShowDialog();
                                }
                                Clicked = true;
                            }
                        }
                    }
                    turn = 1;
                }                    
            }
        }
        private int WinnerPlayer(int playerToCheck)
        {
            // vertical win check ( | ) such that index out of range exception does not occur 
            for (int row = 0; row < board.GetLength(0) - 2; row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    if (AllNumbersEqual(playerToCheck, board[row, column], board[row + 1, column], board[row + 2, column]))
                    {
                        return playerToCheck;
                    }
                }
            }
            // horizontal win check ( - ) such that index out of range exception does not occur
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1) - 2; column++)
                {
                    if (AllNumbersEqual(playerToCheck, board[row, column], board[row, column + 1], board[row, column + 2]))
                    {
                        return playerToCheck;
                    }
                }
            }
            // top left diagonal win check ( \ ) such that index out of range exception does not occur
            for (int row = 0; row < board.GetLength(0) - 2; row++)
            {
                for (int column = 0; column < board.GetLength(1) - 2; column++)
                {
                    if (AllNumbersEqual(playerToCheck, board[row, column], board[row + 1, column + 1], board[row + 2, column + 2]))
                    {
                        return playerToCheck;
                    }
                }
            }
            // top right diagonal win check ( / ) such that index out of range exception does not occur
            for (int row = 0; row < board.GetLength(0) - 2; row++)
            {
                for (int column = 2; column < board.GetLength(1); column++)
                {
                    if (AllNumbersEqual(playerToCheck, board[row, column], board[row + 1, column - 1], board[row + 2, column - 2]))
                    {
                        return playerToCheck;
                    }
                }
            }
            return -1;
        }
        private bool AllNumbersEqual(int toCheck, params int[] numbers) // has the parameter of whose turn it is and which row and columns to check
        { // Parameters of whose turn it is and which numbers to check
            foreach (int num in numbers)
            {
                if (num != toCheck)
                {
                    return false;
                }
            }
            return true;
        }
        private int ColumnNumber(Point mouse)
        { // To get the column number after mouse clicked
            for (int i = 0; i < boardColumns.Length; i++)
            {
                if ((mouse.X >= boardColumns[i].X) && (mouse.Y >= boardColumns[i].Y))
                {
                    if ((mouse.X <= boardColumns[i].X + boardColumns[i].Width) && (mouse.Y <= boardColumns[i].Y + boardColumns[i].Height))
                    {
                        return i; // returns column number
                    }
                }
            }
            return -1; // mouse is clicked out of the board area or is clicked on the black lines
        }

        private int ComputerTurn (int turn)
        {
            Random rnd = new Random();
            int spot = rnd.Next(1, 10);
            return spot;
        }
        private int RowNumber(Point mouse)
        { // To get the row number after mouse clicked
            for (int i = 0; i < boardRow.Length; i++)
            {
                if ((mouse.X >= boardRow[i].X) && (mouse.Y >= boardRow[i].Y))
                {
                    if ((mouse.X <= boardRow[i].X + boardRow[i].Width) && (mouse.Y <= boardRow[i].Y + boardRow[i].Height))
                    {
                        return i; // returns row number
                    }
                }
            }
            return -1; // mouse is clicked out of the board area or is clicked on the black lines
        }

        private void PlayerVsPlayerButton_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Hide();
            Form PlayerVsPlayer = new Form1();
            PlayerVsPlayer.ShowDialog();
        }

        private void ComputerPlayer1Button_Click(object sender, EventArgs e)
        {           
            numberOfTurns++;
            turn = 2;
            int columnIndex = -1;
            int rowIndex = -1;
            if (Column0Row0Used == 0 && Column1Row0Used == 0 && Column2Row0Used == 0 && Column0Row1Used == 0 && Column1Row1Used == 0 && Column2Row1Used == 0 && Column0Row2Used == 0 && Column1Row2Used == 0 && Column2Row2Used == 0)
            {
                if (ComputerTurn(turn) == 1)
                {
                    columnIndex = 0;
                    rowIndex = 0;
                    Column0Row0Used++;
                }
                else if (ComputerTurn(turn) == 2)
                {
                    columnIndex = 1;
                    rowIndex = 0;
                    Column1Row0Used++;
                }
                else if (ComputerTurn(turn) == 3)
                {
                    columnIndex = 2;
                    rowIndex = 0;
                    Column2Row0Used++;
                }
                else if (ComputerTurn(turn) == 4)
                {
                    columnIndex = 0;
                    rowIndex = 1;
                    Column0Row1Used++;
                }
                else if (ComputerTurn(turn) == 5)
                {
                    columnIndex = 1;
                    rowIndex = 1;
                    Column1Row1Used++;
                }
                else if (ComputerTurn(turn) == 6)
                {
                    columnIndex = 2;
                    rowIndex = 1;
                    Column2Row1Used++;
                }
                else if (ComputerTurn(turn) == 7)
                {
                    columnIndex = 0;
                    rowIndex = 2;
                    Column0Row2Used++;
                }
                else if (ComputerTurn(turn) == 8)
                {
                    columnIndex = 1;
                    rowIndex = 2;
                    Column1Row2Used++;
                }
                else if (ComputerTurn(turn) == 9)
                {
                    columnIndex = 2;
                    rowIndex = 2;
                    Column2Row2Used++;
                }               
                board[rowIndex, columnIndex] = turn;
                Graphics g = CreateGraphics();
                g.FillEllipse(Brushes.Yellow, 24 + 100 * columnIndex, 24 + 100 * rowIndex, 90, 90);
                turn = 1;
            }
            else
            {
                Form.ActiveForm.Hide();
                Form PlayComputer = new Form2();
                PlayComputer.ShowDialog();
            }
        }

        private void ComputerPlayer2Button_Click(object sender, EventArgs e)
        {
            if (Column0Row0Used == 0 && Column1Row0Used == 0 && Column2Row0Used == 0 && Column0Row1Used == 0 && Column1Row1Used == 0 && Column2Row1Used == 0 && Column0Row2Used == 0 && Column1Row2Used == 0 && Column2Row2Used == 0)
            {
                turn = 1;
            }
            else
            {
                Form.ActiveForm.Hide();
                Form PlayComputer = new Form2();
                PlayComputer.ShowDialog();
            }               
        }
    }
}

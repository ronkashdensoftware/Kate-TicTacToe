using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {

    bool isX = true;


    List<Button> rowTop = new List<Button>();
    List<Button> rowMiddle = new List<Button>();
    List<Button> rowBottom = new List<Button>();

    public MainWindow()
    {
      InitializeComponent();

      //initialize the buttons

      // first 3 buttons
      rowTop.Add(TopL);
      rowTop.Add(TopC);
      rowTop.Add(TopR);

      //middle 3 buttons
      rowMiddle.Add(MidL);
      rowMiddle.Add(MidC);
      rowMiddle.Add(MidR);

      //bottom 3 buttons
      rowBottom.Add(BotL);
      rowBottom.Add(BotC);
      rowBottom.Add(BotR);

    }

    //-----------------------------
    private void Cycle(object sender, RoutedEventArgs e)
    {
      Button clicked = (Button)sender;

      // check to see if the button has been used
      if ((string)clicked.Content != "") { return; }

      if (isX)
      {
        clicked.Content = "X";
      } else
      {
        clicked.Content = "O";
      }

      isX = !(isX);

      string theWinner = LookForWinner();
      if (theWinner != "")
      {
        MessageBox.Show($"The winner is {theWinner}");
      }

    }

    //-----------------------------
 private string LookForWinner()
    {// determines if there is a winner

      //check horizontal
      string priorButton = (string)rowTop[0].Content;
      bool isWinner = false;
      foreach (var but in rowTop)
      {
        if (priorButton == (string)but.Content)
        {
          isWinner = true;
        } else
        {
          isWinner = false;
          break;
        }
      } //forEach
      if ((isWinner) && priorButton != "") { return priorButton; }

      isWinner = false;
      priorButton = (string) rowMiddle[0].Content;
      foreach (var but in rowMiddle)
      {
        if (priorButton == (string)but.Content)
        {
          isWinner = true;
        }
        else
        {
          isWinner = false;
          break;
        }
      } //forEach
      if ((isWinner) && priorButton != "") { return priorButton; }

      isWinner = false;
      priorButton = (string)rowBottom[0].Content;
      foreach (var but in rowBottom)
      {
        if (priorButton == (string)but.Content)
        {
          isWinner = true;
        }
        else
        {
          isWinner = false;
          break;
        }
      } //forEach
      if ((isWinner) && priorButton != "") { return priorButton; }


      //check vertical
      if (((string)rowTop[0].Content != "") && (rowTop[0].Content == rowMiddle[0].Content) && (rowMiddle[0].Content == rowBottom[0].Content)) {
        return (string)rowTop[0].Content;
      }

      if (((string)rowTop[1].Content != "") && (rowTop[1].Content == rowMiddle[1].Content) && (rowMiddle[1].Content == rowBottom[1].Content)) {
        return (string)rowTop[1].Content;
      }

      if (((string)rowTop[2].Content != "") && (rowTop[2].Content == rowMiddle[2].Content) && (rowMiddle[2].Content == rowBottom[2].Content))
      {
        return (string)rowTop[2].Content;
      }


      return "";

    }

        //-----------------------------
        int[] row1 = new int[] { 0, 0 };
        int[] row2 = new int[] { 0, 0 };
        int[] row3 = new int[] { 0, 0 };
        int[] col1 = new int[] { 0, 0 };
        int[] col2 = new int[] { 0, 0 };
        int[] col3 = new int[] { 0, 0 };
        int[] diagLR = new int[] { 0, 0 };
        int[] diagRL = new int[] { 0, 0 };

        private void Score(Button sender)
        {
            Button clicked = sender;
            int location = 0;
            bool X = (string)clicked.Content == "X";
            bool O = (string)clicked.Content == "O";

            if (location == 0)
            {
                if (X)
                {
                    row1[0] += 1;
                    col1[0] += 1;
                    diagLR[0] += 1;
                }
                else if (O)
                {
                    row1[1] += 1;
                    col1[1] += 1;
                    diagLR[1] += 1;
                }
            }
            if (location == 1)
            {
                if (X)
                {
                    row1[0] += 1;
                    col2[0] += 1;
                }
                else if (O)
                {
                    row1[1] += 1;
                    col2[1] += 1;
                }
            }
            if (location == 2)
            {
                if (X)
                {
                    row1[0] += 1;
                    col3[0] += 1;
                    diagRL[0] += 1;
                }
                else if (O)
                {
                    row1[1] += 1;
                    col3[1] += 1;
                    diagRL[1] += 1;
                }
            }
            if (location == 3)
            {
                if (X)
                {
                    row2[0] += 1;
                    col1[0] += 1;
                }
                else if (O)
                {
                    row2[1] += 1;
                    col1[1] += 1;
                }
            }
            if (location == 4)
            {
                if (X)
                {
                    row2[0] += 1;
                    col2[0] += 1;
                    diagLR[0] += 1;
                    diagRL[0] += 1;
                }
                else if (O)
                {
                    row2[1] += 1;
                    col2[1] += 1;
                    diagLR[0] += 1;
                    diagRL[0] += 1;
                }
            }
            if (location == 5)
            {
                if (X)
                {
                    row2[0] += 1;
                    col3[0] += 1;
                }
                else if (O)
                {
                    row2[1] += 1;
                    col3[1] += 1;
                }
            }
            if (location == 6)
            {
                if (X)
                {
                    row3[0] += 1;
                    col1[0] += 1;
                    diagRL[0] += 1;
                }
                else if (O)
                {
                    row3[1] += 1;
                    col1[1] += 1;
                    diagRL[1] += 1;
                }
            }
            if (location == 7)
            {
                if (X)
                {
                    row3[0] += 1;
                    col2[0] += 1;
                }
                else if (O)
                {
                    row3[1] += 1;
                    col2[1] += 1;
                }
            }
            if (location == 8)
            {
                if (X)
                {
                    row3[0] += 1;
                    col3[0] += 1;
                    diagLR[0] += 1;
                }
                else if (O)
                {
                    row3[1] += 1;
                    col3[1] += 1;
                    diagLR[1] += 1;
                }
            }
            if (row1[0] == 3 || row2[0] == 3 || row3[0] == 3 || col1[0] == 3 || col2[0] == 3 || col3[0] == 3 || diagRL[0] == 3 || diagLR[0] == 3)
            {
                MessageBox.Show("Player X has gotten tic tac toe, three in a row!");
            }
            else if (row1[1] == 3 || row2[1] == 3 || row3[1] == 3 || col1[1] == 3 || col2[1] == 3 || col3[1] == 3 || diagRL[1] == 3 || diagLR[1] == 3)
            {
                MessageBox.Show("Player O has gotten tic tac toe, three in a row!");
            }

        }
    }
}

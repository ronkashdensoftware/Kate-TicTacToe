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

      //check diagonal
      if(((string)rowTop[0].Content != "") && (rowTop[0].Content == rowMiddle[1].Content) && (rowMiddle[1].Content == rowBottom[2].Content))
            {
                return (string)rowTop[0].Content;
            }
      if(((string)rowTop[2].Content != "") && (rowTop[2].Content == rowMiddle[1].Content) && (rowMiddle[1].Content == rowBottom[0].Content))
            {
                return (string)rowTop[2].Content;
            }

      return "";

    }

    //-----------------------------
  }
}

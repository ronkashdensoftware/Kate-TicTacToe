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
    public MainWindow()
    {
      InitializeComponent();
    }

    private void Cycle(object sender, RoutedEventArgs e)
    {
      Button clicked = (Button)sender;
      if ((String)clicked.Content == "X")
      {
        clicked.Content = "O";
      }
      else if ((String)clicked.Content == "O")
      {
        clicked.Content = " ";
      }
      else
      {
        clicked.Content = "X";
      }
    }
  }
}

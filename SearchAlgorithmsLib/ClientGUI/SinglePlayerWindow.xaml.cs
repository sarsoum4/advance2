﻿using System;
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
using System.Windows.Shapes;

namespace ClientGUI
{
    /// <summary>
    /// Interaction logic for SinglePlayerWindow1.xaml
    /// </summary>
    public partial class SinglePlayerWindow : Window
    {
        public SinglePlayerWindow(string gameName)
        {
            InitializeComponent();
            this.Title = gameName;
            Grid grid = new Grid();
        }

        private void restartbutton_Click(object sender, RoutedEventArgs e)
        {
            GoBackWindow action = new GoBackWindow();
            action.ShowDialog();
            if (action.getYesNoFlag() == 1)
            {
                
            }
        }

        private void solvebutton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mainbutton_Click(object sender, RoutedEventArgs e)
        {
            GoBackWindow action = new GoBackWindow();
            action.ShowDialog();
            if(action.getYesNoFlag() == 1)
            {
                this.Close();
            }

        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientGUI.V
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



        private void multiplayer_Click(object sender, RoutedEventArgs e)
        {
            MultiplayerMenu menu = new MultiplayerMenu();
            menu.ShowDialog();
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow setting = new SettingsWindow();
            setting.ShowDialog();
        }

        private void singalPlayer_Click(object sender, RoutedEventArgs e)
        {
            SinglePlayerMenu menu = new SinglePlayerMenu();
            menu.ShowDialog();

            
        }
    }
}

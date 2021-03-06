﻿using MazeLib;
using Server.TheModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controler
{
    public class GenerateMazeCommand : ICommand
    {

        private IModel model;

        public GenerateMazeCommand(IModel model) {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            if (this.model.CheckIfMazeInDictionary(name))
            {
                return "the maze with the given name already exists";
            }
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);
            Maze maze = model.GenerateMaze(name, rows, cols);
            //this.model.AddMaze(name, maze);
            return maze.ToJSON();
        }
    }
}

﻿using System;
using MazeLib;
using MazeGeneratorLib;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace ClientGUI.M
{
    class Model : IModel
    {
        

        private String userCommand;
        private String answer;
        private Position playerPosition;
        private string playerPositionStr;
        private string solved;

        private int port;
        private bool connectionActive = false;
        private IPEndPoint endPonit = null;
        private TcpClient client = null;
        private NetworkStream stream = null;
        private StreamReader reader = null;
        private StreamWriter writer = null;

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public string Json
        {
            get
            {
                return answer;
            }

            set
            {
                this.answer = value;
                NotifyPropertyChanged("Json");
            }
        }



        public Model()
        {

            this.connectionActive = false;
            this.endPonit = null;
            this.client = null;
            this.stream = null;
            this.reader = null;
            this.writer = null;
        }





        public void getCommandFromServer(string command)
        {
            //this.currentCommand = command;
        }

        public String commandToSend()
        {
            return null;
        }






        public void connect(string ip, int port)
        {
            Console.WriteLine(ip);
            Console.WriteLine(port);
            this.endPonit = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6677);

            if (!connectionActive)
            {
                connectionActive = true;
                client = new TcpClient();
                client.Connect(endPonit);
                stream = client.GetStream();
                this.writer = new StreamWriter(stream);
                this.reader = new StreamReader(stream);
            }
        }













        //string
        public string Recieve()
        {

            bool flag = true;
            string current = "";

            while (flag)
            {
                try
                {

                    this.answer = reader.ReadLine();
                    if (answer == "  }")
                    {
                        current += "  }";
                        current += "}";
                        break;
                    }

                    else if (answer.Equals("close"))
                    {
                        // Close the connection.
                        writer.WriteLine("close");
                        writer.Flush();
                        this.connectionActive = false;
                        client.Close();
                        return "Close";
                    }

                    else if (answer.Equals("-1"))
                    {
                        this.connectionActive = false;
                        client.Close();
                        return "-1";
                    }

                }
                // Server closed the connection.
                catch
                {
                    this.connectionActive = false;
                    client.Close();
                }
                current += answer;
            }
            return current;

        }



        //send to server
        public void send(string s)
        {
            this.userCommand = s;
            writer.WriteLine(s);
            writer.Flush();
        }


        public void movePlayer(int row, int col)
        {
            PlayerPosition = new Position(row, col);
            PlayerPositionStr = playerPosition.ToString();
        }


        public Position PlayerPosition
        {
            get { return playerPosition; }
            set
            {
                playerPosition = value;
                NotifyPropertyChanged("PlayerPosition");
            }
        }

        public string PlayerPositionStr
        {
            get { return playerPositionStr; }
            set
            {
                playerPositionStr = value;
                NotifyPropertyChanged("PlayerPositionStr");

            }
        }

        //TODO: check how to get the diffault algo?#################################################3
        public string SolveMaze()
        {

            bool flag = true;
            string current = "";

            while (flag)
            {
                try
                {
                    for (int i = 0; i < 4; i++)
                    {
                        this.answer = reader.ReadLine();
                        if (answer == "  }")
                        {
                            current += "  }";
                            current += "}";
                            break;
                        }

                        else if (answer.Equals("close"))
                        {
                            // Close the connection.
                            writer.WriteLine("close");
                            writer.Flush();
                            this.connectionActive = false;
                            client.Close();
                            return "Close";
                        }

                        else if (answer.Equals("-1"))
                        {
                            this.connectionActive = false;
                            client.Close();
                            return "-1";
                        }
                        current += answer;
                    }
                    break;
                }
                // Server closed the connection.
                catch
                {
                    this.connectionActive = false;
                    client.Close();
                }
                
            }
            
            return current;
        }

        public string SolvedMazeRep {
            get { return solved; }
            set
            {
                solved = value;
                NotifyPropertyChanged("SolvedMazeRep");
            }
        }

        public List<string> GamesList {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public void generateNewMaze(string name, int rows, int cols)
        {
            throw new NotImplementedException();
        }

        public void GetGamesList()
        {
            //this.currentCommand = "list";
        }



        public void disconnect()
        {
            throw new NotImplementedException();
        }

        public void start()
        {
            throw new NotImplementedException();
        }


    }
}
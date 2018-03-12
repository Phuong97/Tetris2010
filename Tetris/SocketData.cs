using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    [Serializable]
    public class SocketData
    {       
        private int[,] Arrboard;
        private string name;
        private int speed;
        private int level;
        private int score;
        private int command;
        

        public int Command
        {
            get { return command; }
            set { command = value; }
        }
       public int[,] Board { get => Arrboard; set => Arrboard = value; }
        public int Speed { get => speed; set => speed = value; }
        public int Level { get => level; set => level = value; }
        public int Score { get => score; set => score = value; }
        public string Name { get => name; set => name = value; }
      

        public SocketData(int command, int[,] board ,string name,int level,int speed,int score)//
        {
            this.Command = command;
            this.Board = board;
            this.Name = name;
            this.Level = level;
            this.Score = score;
            this.Speed = speed;
        }
        
    }
    public enum SocketCommand
    {
        SEND_DATA,
        NEW_GAME,
        PAUSE,
        QUIT,
        END_GAME
    }

}

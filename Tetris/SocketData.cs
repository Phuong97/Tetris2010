using System;

namespace Tetris
{
    [Serializable]
    public class SocketData
    {
        private int[,] Arrboard; //mảng ma trận kết quả

        public int[,] Board
        {
            get { return Arrboard; }
            set { Arrboard = value; }
        }
        private int[,] block; // từng block
        public int[,] Block
        {
            get { return block; }
            set { block = value; }
        }
        private string name; // tên người chơi hiện tại
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int speed;
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        private int level;
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        private int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        private int command;
        public int Command
        {
            get { return command; }
            set { command = value; }
        }
        private string messenger;
        public string Messenger
        {
            get { return messenger; }
            set { messenger = value; }
        }

        public SocketData(int command, int[,] board, int[,] block, string name, int level, int speed, int score,string messenger)//
        {
            this.Command = command;
            this.Board = board;
            this.Block = block;
            this.Name = name;
            this.Level = level;
            this.Score = score;
            this.Speed = speed;
            this.messenger = messenger;
        }

    }
    public enum SocketCommand
    {
        MODETIME,
        MODECLASSIC,
        SEND_DATA,
        NEW_GAME,
        PAUSE,
        QUIT,
        END_GAME,
        MESSENGER
    }
}

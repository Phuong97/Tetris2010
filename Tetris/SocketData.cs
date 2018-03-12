using System;

namespace Tetris
{
    [Serializable]
    public class SocketData
    {
        private int[,] Arrboard; //mảng ma trận kết quả
        private int[,] block; // từng block
        private string name; // tên người chơi hiện tại
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
        public int[,] Block { get => block; set => block = value; }

        public SocketData(int command, int[,] board, int[,] block, string name, int level, int speed, int score)//
        {
            this.Command = command;
            this.Board = board;
            this.Block = block;
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

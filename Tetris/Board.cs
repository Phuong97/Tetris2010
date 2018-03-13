using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public class Board
    {
        //Attribute
        private int Row;
        private int Column;
        private Label[,] MapServer;
        private Label[,] MapClient;
        private int[,] MapPlayClient;
        private int[,] MapPlayServer;


        //Property
        public Label[,] MapServer1 { get => MapServer; set => MapServer = value; }
        public int Column1 { get => Column; set => Column = value; }
        public int Row1 { get => Row; set => Row = value; }
        public int[,] MapPlayClient1 { get => MapPlayClient; set => MapPlayClient = value; } //lưu giá trị 1 0
        public Label[,] MapClient1 { get => MapClient; set => MapClient = value; }
        public int[,] MapPlayServer1 { get => MapPlayServer; set => MapPlayServer = value; }



        //Constructor
        public Board()
        {
            Row1 = 22;
            Column1 = 10;
            MapServer1 = new Label[Row1, Column1];
            MapClient1 = new Label[Row1, Column1];
            MapPlayClient1 = new int[Row1, Column1];
            MapPlayServer1 = new int[Row1, Column1];
        }

        public void DeleteNextBlock(Player player)
        {
            if (player.Name == "Player_Server")
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        MapServer1[i, j].Hide();
                        MapServer1[i, j].BackColor = Color.White;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        MapClient1[i, j].Hide();
                        MapClient1[i, j].BackColor = Color.White;
                    }
                }
            }
        }


        public void DrawBlockNext(Player player, Block block) // vẽ luôn trên panel hoặc panel mới
        {
            DeleteNextBlock(player);
            if (player.Name == "Player_Server")
            {
                for (int i = 0; i < block.Row1; i++)
                {
                    for (int j = 0; j < block.Column1; j++)
                    {
                        MapServer1[i, j].Show();
                        if (block.Arr[i, j] == 1)
                        {
                            MapServer1[i, j].BackColor = block.Color;
                            player.Panel.Controls.Add(MapServer1[i, j]);
                        }
                        if (block.Arr[i, j] == 0)
                        {
                            MapServer1[i, j].BackColor = Color.White;
                            player.Panel.Controls.Add(MapServer1[i, j]);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < block.Row1; i++)
                {
                    for (int j = 0; j < block.Column1; j++)
                    {
                        MapClient1[i, j].Show();
                        if (block.Arr[i, j] == 1)
                        {
                            MapClient1[i, j].BackColor = block.Color;
                            player.Panel.Controls.Add(MapClient1[i, j]);
                        }
                        if (block.Arr[i, j] == 0)
                        {
                            MapClient[i, j].BackColor = Color.White;
                            player.Panel.Controls.Add(MapClient1[i, j]);
                        }
                    }
                }
            }
        }

        //Vẽ block
        public void DrawBlock(Player player, Block block)
        {
            if (player.Name == "Player_Server")
            {
                for (int i = 0; i < block.Row1; i++)
                {
                    for (int j = 0; j < block.Column1; j++)
                    {
                        if (block.Arr[i, j] == 1)
                        {
                            MapServer1[i + block.IBoard, j + block.JBoard].BackColor = block.Color;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < block.Row1; i++)
                {
                    for (int j = 0; j < block.Column1; j++)
                    {
                        if (block.Arr[i, j] == 1)
                        {
                            MapClient1[i + block.IBoard, j + block.JBoard].BackColor = block.Color;
                        }
                    }
                }
            }
        }
        int x, y;
        Point point;
        // Vẽ bảng mặc định khởi tạo 1 lần duy nhất
        public void DrawBoard(Panel panel)
        {
            point = panel.Location;
            x = point.X - 17;
            y = point.Y - 20;
            for (int i = 0; i < Row1; i++)
            {
                y += 30;
                x = 9;
                for (int j = 0; j < Column1; j++)
                {
                    point = new Point(x, y);
                    MapServer1[i, j] = new Label();
                    MapServer1[i, j].Location = point;
                    MapServer1[i, j].Width = MapServer1[i, j].Height = 30;
                    MapPlayServer1[i, j] = 0;
                    if (j % 2 == 0)
                    {
                        MapServer1[i, j].BackColor = Color.Silver;
                    }
                    else
                    {
                        MapServer1[i, j].BackColor = Color.LightGray;
                    }

                    MapServer1[i, j].BorderStyle = BorderStyle.FixedSingle;
                    panel.Controls.Add(MapServer1[i, j]);
                    x += 30;
                }

            }

        }

        int xtemp;
        public void DrawBoard2(Panel pnl)
        {
            point = pnl.Location;
            x = xtemp = point.X - 490;
            y = point.Y - 20;

            for (int i = 0; i < 22; i++)
            {
                y += 30;
                x = xtemp;
                for (int j = 0; j < 10; j++)
                {
                    MapPlayClient1[i, j] = 0;
                    point = new Point(x, y);
                    MapClient1[i, j] = new Label();
                    MapClient1[i, j].Location = point;
                    MapClient1[i, j].Width = MapClient1[i, j].Height = 30;
                    if (j % 2 == 0)
                    {
                        MapClient1[i, j].BackColor = Color.Silver;
                    }
                    else
                    {
                        MapClient1[i, j].BackColor = Color.LightGray;
                    }

                    MapClient1[i, j].BorderStyle = BorderStyle.FixedSingle;
                    pnl.Controls.Add(MapClient1[i, j]);
                    x += 30;
                }

            }

        }


        //SHOW// 2 người chơi show 2 cái kkhac nhau
        public void ShowBoard1(Panel panel, int[,] arr)//Xóa các control và vẽ lại sau mỗi lần cập nhập
        {
            //xóa cũ tạo mới.
            //panel.Controls.Clear();
            for (int i = 4; i < Row1; i++)
            {
                for (int j = 0; j < Column1; j++)
                {
                    panel.Controls.Remove(MapServer1[i, j]);
                }
            }
            point = panel.Location;
            x = point.X - 20;
            y = point.Y + 85;
            for (int i = 4; i < Row1; i++)
            {
                y += 30;
                x = 9;
                for (int j = 0; j < Column1; j++)
                {
                    point = new Point(x, y);
                    MapServer1[i, j] = new Label();
                    MapServer1[i, j].Location = point;
                    MapServer1[i, j].Width = MapServer1[i, j].Height = 30;
                    // MapPlayServer1[i, j] = 0;
                    if (arr[i, j] == 0)
                    {

                        if (j % 2 == 0)
                        {
                            MapServer1[i, j].BackColor = Color.Silver;
                        }
                        else
                        {
                            MapServer1[i, j].BackColor = Color.LightGray;
                        }
                    }
                    else
                    {
                        MapServer1[i, j].BackColor = Color.Black;
                    }

                    MapServer1[i, j].BorderStyle = BorderStyle.FixedSingle;
                    panel.Controls.Add(MapServer1[i, j]);
                    x += 30;
                }
            }
        }

        public void ResetBoard(Player player)
        {

            if (player.Name == "Player_Server")
            {
                for (int i = 0; i < 4; i++) //Xóa các control và vẽ lại sau mỗi lần cập nhập
                {
                    for (int j = 0; j < Column1; j++)
                    {
                        MapServer1[i, j].Hide();
                    }
                }
                for (int i = 0; i < Row1; i++) //Xóa các control và vẽ lại sau mỗi lần cập nhập
                {
                    for (int j = 0; j < Column1; j++)
                    {
                        MapPlayServer1[i, j] = 0;
                        if (j % 2 == 0)
                        {
                            MapServer1[i, j].BackColor = Color.Silver;
                        }
                        else
                        {
                            MapServer1[i, j].BackColor = Color.LightGray;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < 4; i++) //Xóa các control và vẽ lại sau mỗi lần cập nhập
                {
                    for (int j = 0; j < Column1; j++)
                    {
                        MapClient1[i, j].Hide();
                    }
                }
                for (int i = 4; i < Row1; i++) //Xóa các control và vẽ lại sau mỗi lần cập nhập
                {
                    for (int j = 0; j < Column1; j++)
                    {
                        MapPlayClient1[i, j] = 0;
                        if (j % 2 == 0)
                        {
                            MapClient1[i, j].BackColor = Color.Silver;
                        }
                        else
                        {
                            MapClient1[i, j].BackColor = Color.LightGray;
                        }
                    }
                }
            }
        }

        public void ShowBoard2(Panel pnl, int[,] arr)
        {
            //pnl.Controls.Clear();
            for (int i = 4; i < Row1; i++) //Xóa các control và vẽ lại sau mỗi lần cập nhập
            {
                for (int j = 0; j < Column1; j++)
                {
                    pnl.Controls.Remove(MapClient1[i, j]);
                }
            }
            point = pnl.Location;
            x = xtemp = point.X - 480;
            y = point.Y + 85;
            for (int i = 4; i < 22; i++)
            {
                y += 30;
                x = xtemp;
                for (int j = 0; j < 10; j++)
                {
                    //MapPlayClient1[i, j] = 0;
                    point = new Point(x, y);
                    MapClient1[i, j] = new Label();
                    MapClient1[i, j].Location = point;
                    MapClient1[i, j].Width = MapClient1[i, j].Height = 30;
                    if (arr[i, j] == 0)
                    {
                        if (j % 2 == 0)
                        {
                            MapClient1[i, j].BackColor = Color.Silver;
                        }
                        else
                        {
                            MapClient1[i, j].BackColor = Color.LightGray;
                        }
                    }
                    else
                    {
                        //MessageBox.Show(i.ToString() + " / " + j.ToString());
                        MapClient1[i, j].BackColor = Color.Red;
                    }

                    MapClient1[i, j].BorderStyle = BorderStyle.FixedSingle;
                    pnl.Controls.Add(MapClient1[i, j]);
                    x += 30;
                }

            }

        }

        //==========SOCKET===============//
        public void UpdatePanelAfterReceive(string playerName, int[,] arr, Panel pnls, Panel pnlc)
        {
            if (playerName == "Player_Server")
            {
                pnls.BackColor = Color.White;
                ShowBoard1(pnls, arr); //show thông tin nhận đc từ phía playerName
            }
            else
            {
                pnlc.BackColor = Color.White;
                ShowBoard2(pnlc, arr);
            }
        }

        // Vẽ block Send 
        public void DrawBlockSend(string playerName, int[,] arr, Panel pnls, Panel pnlc)
        {
            pnlc.Controls.Clear(); // Xóa các control hiện tại để tạo control mới
            pnls.Controls.Clear();
            int r = arr.GetLength(0);
            int c = arr.GetLength(1);
            Label[,] block = new Label[r, c];
            if (playerName == "Player_Server") //nếu nhận được thông tin gửi từ server thì vẽ 
            {                               //panel server trên client và ngc lại
                point = pnls.Location;
                x = point.X; // xác định vị trí
                y = point.Y;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    y += 30;
                    x = 9;
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        point = new Point(x, y);
                        block[i, j] = new Label();
                        block[i, j].Location = point;
                        block[i, j].Width = block[i, j].Height = 30;
                        if (arr[i, j] == 1)
                        {
                            block[i, j].BackColor = Color.Red;
                            pnls.Controls.Add(block[i, j]);
                        }
                        else
                        {
                            block[i, j].BackColor = Color.White;
                            pnls.Controls.Add(block[i, j]);
                        }
                        x += 30;
                    }
                }
            }
            else
            {
                point = pnlc.Location;
                x = xtemp = point.X - 480;
                y = point.Y - 20;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    y += 30;
                    x = 9;
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        point = new Point(x, y);
                        block[i, j] = new Label();
                        block[i, j].Location = point;
                        block[i, j].Width = block[i, j].Height = 30;
                        if (arr[i, j] == 1)
                        {
                            block[i, j].BackColor = Color.Red;
                            pnlc.Controls.Add(block[i, j]);
                        }
                        else
                        {
                            block[i, j].BackColor = Color.White;
                            pnlc.Controls.Add(block[i, j]);
                        }
                        x += 30;
                    }
                }
            }
        }

    }
}

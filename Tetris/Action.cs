using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public class Action
    {
        Board board = new Board();//để vẽ map và những thứ liên quan
        Info info = new Info();//thông tin trong quá trình chơi
        Player player;//set người chơi
        //1. Khoi tao
        public Action()
        {
        }
        public Player setPlayer(bool isServer, Panel p1, Panel p2)//set người chơi với pnl và name
        {
            if (isServer == true)//biến truyền bên socket iSserver
                player = new Player("Player_Server", p1);
            else
                player = new Player("Player_Client", p2);
            return player;
        }

        public void Init(Panel panel)//vẽ map server trên pnl server
        {
            board.DrawBoard(panel);
        }
        public void Init2(Panel pnl)//vẽ map client trên pnl client
        {
            board.DrawBoard2(pnl);
        }

        //2. Khoi tao Block
        public Block CreatBlock() //tạo khối gạch
        {
            Block block = new Block();
            block = block.ShapeBlock();
            return block;
        }

        //Delete block

        //Xóa ở phần panel2 mỗi khi tạo cái mới xóa cái cũ
        //chia làm 2. if server và else cho client
        //xóa block cũ vẽ block mới sau mỗi lần thay đổi vị trí & hình dạng block
        public void DeleteBlock(Player player, Block block)
        {
            if (player.Name == "Player_Server")
            {
                for (int i = 0; i < block.Row1; i++)//duyệt hết dòng
                {
                    for (int j = 0; j < block.Column1; j++)//duyệt hết cột
                    {
                        if (block.Arr[i, j] == 1)//nếu giá trị block =1
                        {
                            if ((block.JBoard + j) % 2 == 0) //tô lại màu của  map
                            {
                                board.MapServer1[i + block.IBoard, j + block.JBoard].BackColor = Color.Silver;
                            }
                            else
                            {
                                board.MapServer1[i + block.IBoard, j + block.JBoard].BackColor = Color.LightGray;
                            }
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
                            if ((block.JBoard + j) % 2 == 0)
                            {
                                board.MapClient1[i + block.IBoard, j + block.JBoard].BackColor = Color.Silver;
                            }
                            else
                            {
                                board.MapClient1[i + block.IBoard, j + block.JBoard].BackColor = Color.LightGray;
                            }
                        }
                    }
                }
            }
        }

        // Update index for board 
        public void DrawBlockInMap(Player player, Block block) //cập nhập tọa độ giá trị 0 1 
            //của block lên map // 2 trường hợp : server và client
        {
            int[,] arr = block.Arr;
            int Iboard = block.IBoard;
            int Jboard = block.JBoard;
            int rowBlock = block.Row1;
            int columnBlock = block.Column1;
            if (player.Name == "Player_Server")
            {
                for (int i = 0; i < rowBlock; i++)
                {
                    for (int j = 0; j < columnBlock; j++)
                    {
                        if (arr[i, j] == 1)
                            board.MapPlayServer1[i + Iboard, j + Jboard] = 1;
                    }
                }
            }
            else
            {
                for (int i = 0; i < rowBlock; i++)
                {
                    for (int j = 0; j < columnBlock; j++)
                    {
                        if (arr[i, j] == 1)
                            board.MapPlayClient1[i + Iboard, j + Jboard] = 1;
                    }
                }
            }
        }

        //Draw
        public void Draw(Player player)
        {
            if (player.Name == "Player_Server")
            {
                for (int i = 4; i < board.Row1; i++) // Bắt đầu từ 4 để không bị mất ở ô hiện trước panel 2
                                                     //4 dòng đầu để hiện trước
                {
                    for (int j = 0; j < board.Column1; j++)
                    {
                        if (board.MapPlayServer1[i, j] == 1)
                        {
                            //Update rồi nó sẽ thụt lại
                            board.MapServer1[i, j].BackColor = board.MapServer1[i, j].BackColor;
                        }
                        else
                        {
                            if (j % 2 == 0)
                                board.MapServer1[i, j].BackColor = Color.Silver;
                            else
                                board.MapServer1[i, j].BackColor = Color.LightGray;
                        }
                    }
                }
            }
            else
            {
                for (int i = 4; i < board.Row1; i++) // Bắt đầu từ 4 để không bị mất ở ô hiện trước panel 2
                                                    //4 dòng đầu để hiện trước
                {
                    for (int j = 0; j < board.Column1; j++)
                    {
                        if (board.MapPlayClient1[i, j] == 1)
                        {
                            //Update rồi nó sẽ thụt lại
                            board.MapClient1[i, j].BackColor = board.MapClient1[i, j].BackColor;
                        }
                        else
                        {
                            if (j % 2 == 0)
                                board.MapClient1[i, j].BackColor = Color.Silver;
                            else
                                board.MapClient1[i, j].BackColor = Color.LightGray;
                        }
                    }
                }
            }
        }

        //DrawBlock
        public void DrawBlock(Player player, Block block)
        {
            board.DrawBlock(player, block);
        }

        public void DrawBlockNext(Player player, Block block)
        {
            board.DrawBlockNext(player, block);
        }

        // 3.Rotate
        public bool ConditionRotate(Player player, Block b)
        {
            if (player.Name == "Player_Server")
            {
                for (int i = 0; i < b.Row1; i++)
                {
                    for (int j = 0; j < b.Column1; j++)
                    {
                        if (b.ConditionBoard(b.IBoard + i, b.JBoard + j) == false || board.MapPlayServer1[b.IBoard + i, b.JBoard + j] == 1 || b.JBoard + b.Row1 > 10 || b.IBoard + b.Row1 > 21)
                            return false;
                    }
                }
                return true;
            }
            else
            {
                for (int i = 0; i < b.Row1; i++)
                {
                    for (int j = 0; j < b.Column1; j++)
                    {
                        if (b.ConditionBoard(b.IBoard + i, b.JBoard + j) == false || board.MapPlayClient1[b.IBoard + i, b.JBoard + j] == 1 || b.JBoard + b.Row1 > 10 || b.IBoard + b.Row1 > 21)
                            return false;
                    }
                }
                return true;
            }
        }
        public Block Rotate(Player player, ref Block block)
        {
            if (ConditionRotate(player, block))
                return block.Rotate(ref block);
            else
                return block;
        }

        // Condiontion
        public bool ConditionLeft(Player player, Block block)
        {
            if (player.Name == "Player_Server")
            {
                for (int i = 0; i < block.Row1; i++)
                {
                    for (int j = 0; j < block.Column1; j++)
                    {
                        if (block.Arr[i, j] == 1)
                        {
                            if (block.ConditionLeft(block.IBoard + i, block.JBoard + j) == false || block.JBoard - 1 < 0 || block.IBoard <= 3 || board.MapPlayServer1[block.IBoard + i, block.JBoard + j - 1] == 1)
                                return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                for (int i = 0; i < block.Row1; i++)
                {
                    for (int j = 0; j < block.Column1; j++)
                    {
                        if (block.Arr[i, j] == 1)
                        {
                            if (block.ConditionLeft(block.IBoard + i, block.JBoard + j) == false || block.JBoard - 1 < 0 || block.IBoard <= 3 || board.MapPlayClient1[block.IBoard + i, block.JBoard + j - 1] == 1)
                                return false;
                        }
                    }
                }
                return true;
            }
        }

        public bool ConditionRight(Player player, Block block)
        {
            if (player.Name == "Player_Server")
            {
                for (int i = 0; i < block.Row1; i++)
                {
                    for (int j = 0; j < block.Column1; j++)
                    {
                        if (block.Arr[i, j] == 1)
                        {
                            if (block.ConditionRight(block.IBoard + i, block.JBoard + j) == false || board.MapPlayServer1[block.IBoard + i, block.JBoard + j + 1] == 1 || block.IBoard <= 3)
                                return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                for (int i = 0; i < block.Row1; i++)
                {
                    for (int j = 0; j < block.Column1; j++)
                    {
                        if (block.Arr[i, j] == 1)
                        {
                            if (block.ConditionRight(block.IBoard + i, block.JBoard + j) == false || board.MapPlayClient1[block.IBoard + i, block.JBoard + j + 1] == 1 || block.IBoard <= 3)
                                return false;
                        }
                    }
                }
                return true;

            }
        }

        public bool ConditionDown(Player player, Block block)
        {
            if (player.Name == "Player_Server")
            {
                for (int i = 0; i < block.Row1; i++)
                {
                    for (int j = 0; j < block.Column1; j++)
                    {
                        if (block.Arr[i, j] == 1)
                        {
                            if (block.ConditionDown(block.IBoard + i, block.JBoard + j) == false || board.MapPlayServer1[block.IBoard + i + 1, block.JBoard + j] == 1)
                                return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                for (int i = 0; i < block.Row1; i++)
                {
                    for (int j = 0; j < block.Column1; j++)
                    {
                        if (block.Arr[i, j] == 1)
                        {
                            if (block.ConditionDown(block.IBoard + i, block.JBoard + j) == false || board.MapPlayClient1[block.IBoard + i + 1, block.JBoard + j] == 1)
                                return false;
                        }
                    }
                }
                return true;
            }
        }
        //Move
        public Block MoveLeft(Player player, ref Block block)
        {
            if (ConditionLeft(player, block))
                return block.Left(ref block);
            else
                return block;
        }

        public Block MoveRight(Player player, ref Block block)
        {
            if (ConditionRight(player, block))
                return block.Right(ref block);
            else
                return block;
        }

        public Block MoveDown(Player player, ref Block block)
        {
            if (ConditionDown(player, block))
                return block.Down(ref block);
            else
                return block;
        }

        //Info
        public void setInfo(Info info, int t)
        {
            info.Speed = t;
        }

        //WIN LOSEEEEE
        public void UpdateMap(Player player, int row)
        {
            if (player.Name == "Player_Server")
            {
                for (int i = row; i > 0; i--)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        board.MapPlayServer1[i, j] = board.MapPlayServer1[i - 1, j];
                        if (player.Name == "Player_Server")
                            board.MapServer1[i, j].BackColor = board.MapServer1[i - 1, j].BackColor;
                        else
                            board.MapClient1[i, j].BackColor = board.MapClient1[i - 1, j].BackColor;
                    }
                }
            }
            else
            {
                for (int i = row; i > 0; i--)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        board.MapPlayClient1[i, j] = board.MapPlayClient1[i - 1, j];
                        if (player.Name == "Player_Server")
                            board.MapServer1[i, j].BackColor = board.MapServer1[i - 1, j].BackColor;
                        else
                            board.MapClient1[i, j].BackColor = board.MapClient1[i - 1, j].BackColor;
                    }
                }
            }

        }
        //
        public int[,] getMap(Player player)//lấy các giá trị 1 0 hiện tại của map
        {
            int[,] arr = new int[22, 10];
            if (player.Name == "Player_Server")
            {
                for (int i = 21; i > 3; i--)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (board.MapPlayServer1[i, j] == 1)
                            arr[i, j] = 1;
                        else
                            arr[i, j] = 0;
                    }
                }
                return arr;
            }
            else
            {
                for (int i = 21; i > 3; i--)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (board.MapPlayClient1[i, j] == 1)
                            arr[i, j] = 1;
                        else
                            arr[i, j] = 0;
                    }
                }
                return arr;
            }
        }
        public int Check(Player player, Block block, Info info)//kiểm tra để có điểm 
        {
            if (player.Name == "Player_Server")
            {
                int i = block.Row1 - 1;
                if (block.IBoard <= 3) return -1;
                if (info.Speed < 100) return 0;
                int count, j, score;
                do
                {
                    count = 0;
                    for (j = 0; j < board.Column1; j++)
                    {
                        if (board.MapPlayServer1[block.IBoard + i, j] == 1)
                        {
                            count++;
                        }

                    }
                    if (count == 10)
                    {
                        score = 100;
                        info.UpLevel(info, score);
                        UpdateMap(player, block.IBoard + i);
                        Draw(player);
                    }
                    else
                        i--;
                } while (i >= 0);
                return 1;
            }
            else
            {
                int i = block.Row1 - 1;
                if (block.IBoard <= 3) return -1;
                if (info.Speed <= 100) return 0;
                int count, j, score;
                do
                {
                    count = 0;
                    for (j = 0; j < board.Column1; j++)
                    {
                        if (board.MapPlayClient1[block.IBoard + i, j] == 1)
                        {
                            count++;
                        }

                    }
                    if (count == 10)
                    {
                        score = 100;
                        info.UpLevel(info, score);
                        UpdateMap(player, block.IBoard + i);
                        Draw(player);
                    }
                    else
                        i--;
                } while (i >= 0);
                return 1;
            }
        }

        //DRAW AFTER SENDDATA
        /// <summary>
        ///  vẽ map của đối thủ lên màn hình của mình sau khi nhận dữ liệu
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arr"></param>
        /// <param name="pnls"></param>
        /// <param name="pnlc"></param>
        public void UpdatePanelAfterReceive(string name, int[,] arr, Panel pnls, Panel pnlc)
        {
            board.UpdatePanelAfterReceive(name, arr, pnls, pnlc);
        }

        // vẽ block đang di chuyển của đối thủ
        public void DrawBlockSend(string playerName, int[,] arr, Panel pnls, Panel pnlc)
        {
            board.DrawBlockSend(playerName, arr, pnls, pnlc);
        }
        //Làm mới bàn cờ sau mỗi lần new
        public void ResetBoard(Player player)
        {
            board.ResetBoard(player);
        }

    }
}

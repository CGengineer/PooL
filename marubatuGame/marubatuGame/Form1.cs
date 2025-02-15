using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace marubatuGame
{
    public partial class Form1 : Form
    {
        public Space[,] _Spaces = new Space[3, 3];

        public List<Space> _SpaceList = new List<Space>();
        public enum Space
        {
            CrossSpace = 1,
            CircleSpace = 2,
            NoneSpace = 3,
        }
        public Space _TurnEnum = Space.CircleSpace;

        public enum Direction
        {
            LeftUp = 1,
            Up = 2,
            RightUp = 3,
            Left = 4,
            Right = 5,
            LeftDown = 6,
            Down = 7,
            RightDown = 8,
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int x = 0; x < _Spaces.GetLength(0); x++)
            {
                for (int y = 0; y < _Spaces.GetLength(1); y++)
                {
                    _Spaces[x, y] = Space.NoneSpace;
                }
            }
        }

        private void AllButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;

            #region クリックしたボタンの位置情報を取得して配列に入れる
            var btnPositionXY = button.Name.Substring(button.Name.Length - 2);
            var btnPositionY = btnPositionXY.Substring(1, 1);
            var btnPositionX = btnPositionXY.Substring(0, 1);

            var btnPositionYInt = default(int);
            if (int.TryParse(btnPositionY, out btnPositionYInt)) { }
            var btnPositionXInt = default(int);
            if (int.TryParse(btnPositionX, out btnPositionXInt)) { }


            #endregion
            btnPositionXInt = btnPositionXInt - 1;
            btnPositionYInt = btnPositionYInt - 1;
            _Spaces[btnPositionXInt, btnPositionYInt] = _TurnEnum;
            aaa(btnPositionXInt, btnPositionYInt);

            switch (_TurnEnum)
            {
                case Space.CircleSpace:

                    button.Text = "○";
                    _TurnEnum = Space.CrossSpace;
                    break;

                case Space.CrossSpace:
                    button.Text = "✖";
                    _TurnEnum = Space.CircleSpace;
                    break;
            }

            if (_SpaceList.Count() >= 2)
            {
                switch (_TurnEnum)
                {
                    case Space.CircleSpace:
                        MessageBox.Show("あなたの勝ちです", "黒の勝利", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case Space.CrossSpace:
                        MessageBox.Show("あなたの勝ちです", "白の勝利", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }

                DialogResult result = MessageBox.Show("もう一度プレイしますか?", "Replay", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);


                if (result == DialogResult.OK)
                {
                    foreach (Control control in this.Controls)
                    {
                        if (control is Button btn)
                        {
                            btn.Text = "";
                        }
                    }
                    _SpaceList.Clear();

                    for (int x = 0; x < _Spaces.GetLength(0); x++)
                    {
                        for (int y = 0; y < _Spaces.GetLength(1); y++)
                        {
                            _Spaces[x, y] = Space.NoneSpace;
                        }
                    }
                    _TurnEnum = Space.CircleSpace;
                }
                else
                {
                    // キャンセルがクリックされた場合の処理
                    MessageBox.Show("プレイを終了します。");
                    Application.Exit(); // アプリケーションを終了
                }

            }
        }
        private void aaa(int X, int Y)
        {
            for (var direction = Direction.LeftUp; direction <= Direction.RightDown; direction++)
            {
                switch (direction)
                {
                    case Direction.LeftUp:
                        for (int i = 1; i <= 2; i++)
                        {
                            var x = X - i;
                            var y = Y + i;
                            bbb(x, y);
                        }
                        break;

                    case Direction.Up:
                        for (int i = 1; i <= 2; i++)
                        {
                            var y = Y + i;
                            bbb(X, y);
                        }
                        break;

                    case Direction.RightUp:
                        for (int i = 1; i <= 2; i++)
                        {

                            var x = X + i;
                            var y = Y + i;

                            bbb(x, y);
                        }
                        break;

                    case Direction.Left:
                        for (int i = 1; i <= 2; i++)
                        {
                            var x = X - i;
                            bbb(x, Y);
                        }
                        break;

                    case Direction.Right:
                        for (int i = 1; i <= 2; i++)
                        {
                            var x = X + i;
                            bbb(x, Y);
                        }
                        break;

                    case Direction.LeftDown:
                        for (int i = 1; i <= 2; i++)
                        {
                            var x = X - i;
                            var y = Y - i;
                            bbb(x, y);
                        }
                        break;

                    case Direction.Down:
                        for (int i = 1; i <= 2; i++)
                        {
                            var y = Y - i;
                            bbb(X, y);
                        }
                        break;

                    case Direction.RightDown:
                        for (int i = 1; i <= 2; i++)
                        {
                            var x = X + i;
                            var y = Y - i;
                            bbb(x, y);
                        }
                        break;
                }
                if (_SpaceList.Count() >= 2)
                {
                    return;
                }

            }
        }

        private void bbb(int X, int Y)
        {

            //同じ色のものが指定した場所にあれば、続ける　なければループを終わる
            if (X >= 0 &&
                X <= 2 &&
                Y >= 0 &&
                Y <= 2)
            {
                if (_Spaces[X, Y] == _TurnEnum)
                {
                    _SpaceList.Add(_TurnEnum);
                }
                else
                {
                    _SpaceList.Clear();
                }
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 全域變數
        float firstNumber, secondNumber; // firstNumber 儲存第一個數字，secondNumber 儲存第二個數字
        int operators = -1; // 記錄選擇哪一種運算符號？0:加、1:減、2:乘、3:除、-1:重新設定

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNumber.Text = "0";
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            //另一種寫法
            ////if (!txtNumber.Text.Contains("."))
            ////    txtNumber.Text = txtNumber.Text + ".";

            // 確認輸入文字框中完全沒有小數點
            if (txtNumber.Text.IndexOf(".") == -1)
                txtNumber.Text = txtNumber.Text + ".";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            float finalResults = 0f; //宣告最後計算結果變數
            secondNumber = Convert.ToSingle(txtNumber.Text); //將輸入文字框轉換成浮點數，存入第二個數字的全域變數

            //依照四則運算符號的選擇，進行加減乘除
            switch (operators)
            {
                case 0:
                    finalResults = firstNumber + secondNumber;
                    break;
                case 1:
                    finalResults = firstNumber - secondNumber;
                    break;
                case 2:
                    finalResults = firstNumber * secondNumber;
                    break;
                case 3:
                    finalResults = firstNumber / secondNumber;
                    break;
            }

            txtNumber.Text = string.Format("{0:0.##########}", finalResults); //在輸入文字框中，顯示最後計算結果，並且轉換成格式化的字串內容

            //重置所有全域變數
            firstNumber = 0f;
            secondNumber = 0f;
            operators = -1;
        }

        private void Select_Operator(int _operator)
        {
            firstNumber = Convert.ToSingle(txtNumber.Text); //將輸入文字框轉換成浮點數，存入第一個數字的全域變數
            txtNumber.Text = "0"; //重新將輸入文字框重新設定為0
            operators = _operator; //選擇「加」號
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Select_Operator(0);
            //firstNumber = Convert.ToSingle(txtNumber.Text); //將輸入文字框轉換成浮點數，存入第一個數字的全域變數
            //txtNumber.Text = "0"; //重新將輸入文字框重新設定為0
            //operators = 0; //選擇「加」號
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            Select_Operator(1);
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Select_Operator(2);
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            Select_Operator(3);
        }

        private void Add_Number(string _number)
        {
            if (txtNumber.Text == "0")
                txtNumber.Text = "";
            txtNumber.Text = txtNumber.Text + _number;
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            Add_Number("0");
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            Add_Number("1");
            //if (txtNumber.Text == "0")
            //txtNumber.Text = ""; // 如果你的判斷式簡單到只有一行程式，可以把 { } 大刮號省略掉
            //txtNumber.Text += "1";
            // 這種寫法和這段「txtNumber.Text = txtNumber.Text + "1";」是一樣的        }
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            Add_Number("2");
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            Add_Number("3");
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            Add_Number("4");
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            Add_Number("5");
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            Add_Number("6");
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            Add_Number("7");
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            Add_Number("8");
        }
        private void btnNine_Click(object sender, EventArgs e)
        {
            Add_Number("9");
        }

        private void btnFallback_Click(object sender, EventArgs e)
        {
            string current = txtNumber.Text;

            if (current.Length > 1)
            {
                // 移除最後一個字元
                txtNumber.Text = current.Substring(0, current.Length - 1);
            }
            else
            {
                // 如果只剩一位就設回 0
                txtNumber.Text = "0";
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            // 將目前顯示的文字轉成 float
            float number = Convert.ToSingle(txtNumber.Text);

            // 除以 100，取得百分比值
            float percentValue = number / 100f;

            // 顯示計算後的數值（不加 %，避免後續運算錯誤）
            txtNumber.Text = percentValue.ToString("0.##########");
        }

    }



}

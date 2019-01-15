using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TokenQueue"] == null)
            {
                Queue<int> tokenQueue = new Queue<int>();
                Session["TokenQueue"] = tokenQueue;
            }
            if(Session["listStatus"] == null)
            {
                List<bool> listStatus = new List<bool>() { false , false ,false };
                Session["listStatus"] = listStatus;
            }
            if (Session["listValue"] == null)
            {
                List<int> listValue = new List<int>() { 0,0,0};
                Session["listValue"] = listValue;
            }
        }

        protected void Floor1_Click(object sender, EventArgs e)
        {
            PressedFloor(1);
        }

        protected void Floor2_Click(object sender, EventArgs e)
        {
            PressedFloor(2);
        }

        protected void Floor3_Click(object sender, EventArgs e)
        {
            PressedFloor(3);
        }
        protected void Floor4_Click(object sender, EventArgs e)
        {
            PressedFloor(4);
        }
        protected void Floor5_Click(object sender, EventArgs e)
        {
            PressedFloor(5);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
           
        }
        private int checkOutputFloor(int elevatorNumber)
        {
            List<bool> listStatus = (List<bool>)Session["listStatus"];
            List<int> listValue = (List<int>)Session["listValue"];
            if (TextBox4.Text.Equals(""))
            {
                lblCurrentStatus.Text = "Please enter the output floor";
                Thread.Sleep(500);
                lblCurrentStatus.Text = "failed to read inputs";
                return 0;
            }
            else
            {
                lblCurrentStatus.Text = "";
                listValue[elevatorNumber] = Convert.ToInt32(TextBox4.Text);
                listStatus[elevatorNumber] = false;
                return Convert.ToInt32(TextBox4.Text);
            }
        }
        private void AddTokenNumbersToListBox(Queue<int> tokenQueue)
        {
            ListBox1.Items.Clear();
            foreach (int token in tokenQueue)
            {
                ListBox1.Items.Add(token.ToString());
            }
        }
        private void Assign(int counterNumber)
        {
            List<bool> listStatus = (List<bool>)Session["listStatus"];
            List<int> listValue = (List<int>)Session["listValue"];
            List<int> test = new List<int>();
            for (int i =0; i <= 2; i++)
            {
                test.Insert(i, Math.Abs(listValue[i] - counterNumber));
            }
            List<int> test2 = new List<int>();
            List<int> test3 = new List<int>();
            test2 = test;
            test.Sort();
            for(int i=0; i <= 2; i++)
            {
                int b = test2.IndexOf(test[i]);
                if (listStatus[b]== false)
                {
                    listValue[b] = counterNumber;
                    listStatus[b] = true;
                    int a = checkOutputFloor(b);
                    display.Text = "Elevator " + b.ToString() + "Floor Number assigned" + counterNumber.ToString() + "to " + a.ToString();
                    break;
                }
            }
            
            
            
        }
        private void PressedFloor( int counterNumnber)
        {
            Queue<int> tokenQueue = (Queue<int>)Session["TokenQueue"];
            tokenQueue.Enqueue(counterNumnber);
            ListBox1.Items.Add(counterNumnber.ToString());
            int a = tokenQueue.Dequeue();
            Assign(a);
        }

    }
}
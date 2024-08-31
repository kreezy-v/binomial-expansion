namespace BinomialExpansion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
          
            int a = int.Parse(txtA.Text);

            int b = int.Parse(txtB.Text);
            
            int n = int.Parse(txtExpa.Text);

            char op = char.Parse(txtOperator.Text);
                       
            lblFormula.Text = series(a, b, n, op);
            lblFormula.MaximumSize = new Size(680, 0);
            lblFormula.AutoSize = true;
        }
        static int factorial(int n)
        {
            int f = 1;
            for (int i = 2; i <= n; i++)
                f *= i;

            return f;
        }
        static string series(int A, int X, int n, char op)
        {

            // calculating the value of n!
            int nFact = factorial(n);
            string printer = "";
            int powers = n;
            int pw = 0;
            // loop to display the series
            for (int i = 0; i < n + 1; i++)
            {

                // For calculating the
                // value of nCr
                int niFact = factorial(n - i);
                int iFact = factorial(i);

                // calculating the value of
                // A to the power k and X to
                // the power k
                int aPow = (int)Math.Pow(A, n - i);
                int xPow = (int)Math.Pow(X, i);

                // display the series
                if (op == '+')
                {
                   
                    if (i == n)
                    {
                        printer += (nFact * aPow * xPow) / (niFact * iFact);
                    }
                    else
                    {
                        printer += (nFact * aPow * xPow) / (niFact * iFact) + "x";
                    }
                    if (i != n && powers != 1 && powers != 0)                    {

                        printer += ("^"+powers);
                    }    
                    if (i != 0)
                    {
                        if (i == 1)
                        {
                            printer += ("y");
                        }
                        else
                            printer += ("y^" + pw);
                    }
                    if (i < n)
                    {
                        printer += " + ";
                    }
                }
                else if (op == '-')
                {
                    if (i==n)
                    {
                        if (i % 2 == 0)
                        {
                            printer += " + ";
                        }
                        else
                        {
                            printer += " - ";
                        }
                        printer += (nFact * aPow * xPow) / (niFact * iFact);

                    }
                    if (i == 0)
                    {

                        if(A == 1)
                        {
                            printer += "x";
                        }
                        else
                        {
                            printer += (nFact * aPow * xPow) / (niFact * iFact) + "x";
                        }
                       
                        if (i != n && powers != 1 && powers != 0)
                        {
                            printer += ("^" + powers);
                        }
                    }
                    else
                    {

                        if (i != n)
                        {
                            if (i % 2 == 0)
                            {
                                printer += " + ";
                            }
                            else
                            {
                                printer += " - ";
                            }

                            printer += ((nFact * aPow * xPow) / (niFact * iFact) + "x");
                            if (i != n && powers != 1 && powers != 0)
                            {
                                printer += ("^" + powers);
                            }
                        }
                    }
                    if (i != 0)
                    {

                        if (i == 1)
                        {
                            printer += ("y");
                        }
                        else
                            printer += ("y^" + pw);
                    }
                }
                powers--;
                pw++;


            }
            return printer;
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            lblFormula.Text = "";
            txtOperator.Text = "";
            txtExpa.Text = "";
            txtA.Text = "";
            txtB.Text = "";
            
        }
    }

}
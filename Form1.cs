/* ********************************************************************
 * Project:     Square Root Approximation
 * File:        Form Square Root
 * Language:    C#
 * 
 * Description: This program will approximate the square root of an entered
 *              number using a couple of different algorithms.
 * College:     Husson University
 * Course:      IT 325 - Dr. Gerald Wright
 * 
 * Edit History:
 * Ver  Who Date       Notes
 * ---- --- ---------- -----------------------------------------------------
 * 0.1  KMC 09/07/2022 - initial writing
 *                     - GUI design
 * 0.2  KMC 09/07/2022 - added brute force algorithm
 * 0.3  KMC 09/12/2022 - finished brute force alg and made it pretty
 * 0.4  KMC 09/12/2022 - added Heron Method for square root method
 * ********************************************************************/
using System;
using System.Windows.Forms;

namespace SquareRoot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// When the user clicks the button, read the number from the form
        /// and calculate the square root.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            String userText;
            double number;
            double answer;

            // get the number from the form
            userText = textBox1.Text;
            number = Convert.ToDouble(userText);

            // calculate the answer
            answer = SquareRoot_BruteForce(number);


            //display to the user
            MessageBox.Show(answer.ToString());

        }

        /// <summary>
        /// This routine calculates the square root of the number passed in 
        /// to the desired precision using a brute force algorithm.
        /// </summary>
        /// <param name="number">Find the square root of number</param>
        /// <param name="precision">The desired precision for the result</param>
        /// <returns>The square root of the number to the desired precision</returns>
        private double SquareRoot_BruteForce(double number, double precision = 0.01)
        {
            double difference;                   ///difference between out result and current guess
            double result;                       /// current result
            double guess;                        /// result squared

            result = 0.0;
            difference = double.MaxValue;

            //set up the output
            listBoxResult.Items.Clear();
            listBoxResult.Items.Add("         Result           Guess      Difference");
            listBoxResult.Items.Add("=============== =============== ===============");

            while (difference > precision)
            {
                /// compute the intermediate results

                guess = result * result;
                difference = number - guess;

                listBoxResult.Items.Add(String.Format("{0,15:f10} {1,15:f10} {2,15:f10}", result, guess, difference));

                if (difference > precision)
                {
                    result = result + precision;
                }
            }

            return result;
        }


        /// <summary>
        /// This routine calculates the square root of the number passed in 
        /// to the desired precision using Heron / Babylonian algorithm.
        /// 
        /// The algorithm was taken by (HTTPS)
        /// </summary>
        /// <param name="sender">Find the square root of number</param>
        /// <param name="e">The desired precision for the result</param>
        /// <returns>The square root of the number to the desired precision</returns>

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double answer = SquareRoot(Convert.ToDouble(textBox1.Text));

                MessageBox.Show(answer.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private double SquareRoot(double number, double precision = 0.01)
        {
            double guess;
            double result = 0.0;

            if (number < 0.9)
            {
                throw new ArgumentException("The number must be greater than 0");
            }
            else
            {

                result = 0.0000000001;
                guess = number / result;

                do
                {
                    listBoxResult.Items.Add(String.Format("{0,15:f10} {1,15:f10}", result, guess));

                    result = (result + guess) / 2.0;
                    guess = number / result;


                } while (result - guess > precision);

                return result;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rnd;             // Declare it
            rnd = new Random();     // Instaniate it

            // Get a random integer
            int randomNumber = rnd.Next();
            MessageBox.Show(randomNumber.ToString());

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
        }
    }
}

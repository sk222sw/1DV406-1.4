using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Secret.Model;

namespace Secret
{
    public partial class Default : System.Web.UI.Page
    {

        private SecretNumber SecretN
        {
            get 
            {   
                return Session["previousGuesses"] as SecretNumber ?? (SecretNumber)(Session["previousGuesses"] = new SecretNumber());
                //return Session["previousGuesses"] as SecretNumber;
            }
            set
            {
                Session["previousGuesses"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (IsPostBack)
                {
                    SecretNumber thisGuess = SecretN;

                    Outcome guess = thisGuess.MakeGuess(int.Parse(InputTextBox.Text));
                    if (thisGuess.CanMakeGuess)
                    {
                        Button1.Enabled = true;
                        InputTextBox.Enabled = true;
                        InputTextBox.Focus();

                        int currentGuess = int.Parse(InputTextBox.Text);
                        bool exists = thisGuess._previousGuesses.Contains(currentGuess);

                        if (!exists)
                        {
                            thisGuess._previousGuesses.Add(int.Parse(InputTextBox.Text));

                            //guessLabel.Text = thisGuess.Number.ToString();

                            if (guess == Outcome.High)
                            {
                                Label2.Text = "Du gissade för högt.";
                            }
                            else if (guess == Outcome.Low)
                            {
                                Label2.Text = "Du gissade för lågt.";
                            }
                        }
                        else
                        {
                            Label2.Text = "Du har redan gissat på " + currentGuess;
                        }
                    }
                    else if (guess == Outcome.Correct)
                    {
                        Button1.Enabled = false;
                        InputTextBox.Enabled = false;
                        Label2.Text = "GRATTIS";
                        ResetPlaceHolder.Visible = true;
                        ResetButton.Focus();
                        Session.Clear();
                        thisGuess.Initialize();

                    }
                    else if (guess == Outcome.NoMoreGuesses)
                    {
                        Button1.Enabled = false;
                        InputTextBox.Enabled = false;
                        Label2.Text = "Ledsen, inga gissningar kvar. Talet var " + thisGuess.Number;
                        ResetPlaceHolder.Visible = true;
                        ResetButton.Focus();
                        thisGuess.Initialize();
                    }

                    SecretN = thisGuess;
                    guessLabel.Text = "Tidigare gissningar: " + String.Join(", ", thisGuess.PreviousGuesses);
                }
            }
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
                SecretN.Initialize();
                SecretN._previousGuesses.Clear();
                Button1.Enabled = true;
        }
    }
}
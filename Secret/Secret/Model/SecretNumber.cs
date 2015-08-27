using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Secret.Model
{

    public enum Outcome 
    {
        Indefinite,
        Low,
        High,
        Correct,
        NoMoreGuesses,
        PreviousGuesses
    }

    public class SecretNumber
    {
        private int? _number;
        public List<int> _previousGuesses;
        private const int MaxNumberOfGuesses = 7;

        public bool CanMakeGuess
        { get; private set; } // om man kan gissa eller inte.
        public static int Count { get; private set; } // räknar antalet gissningar
        public int? Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public Outcome Outcome{ get; set; }
        public IEnumerable<int> PreviousGuesses { get { return _previousGuesses.AsReadOnly(); } }

        public void Initialize()
        {
            Outcome = Outcome.Indefinite;   //Ev återställ Outcome
            CanMakeGuess = true;

            //slumpa ett tal till Number
            Random myRandom = new Random();
            _number = myRandom.Next(1, 100);
        }
        public Outcome MakeGuess (int guess) 
        {
            if (_previousGuesses.Count < MaxNumberOfGuesses)
            {
                if (guess == Number)
                {
                    CanMakeGuess = false;
                    return Outcome.Correct;
                }
                else if (guess < Number)
                {
                    return Outcome.Low;
                }
                else
                {
                    return Outcome.High;
                }
            }
            else 
            {
                CanMakeGuess = false;
                return Outcome.NoMoreGuesses;
            }

        }

        //konstruktor
        public SecretNumber ()
	    {
            Initialize();
            _previousGuesses = new List<int>(MaxNumberOfGuesses);
            CanMakeGuess = true;
	    }
    }



}
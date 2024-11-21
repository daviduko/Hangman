using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hangman
{
    public partial class _Default : Page
    {
        private const int MaxLives = 6;
        private List<string> WordList = new List<string> { "elephant", "giraffe", "programming", "developer" };

        private string Word
        {
            get { return (string)Session["Word"]; }
            set { Session["Word"] = value; }
        }

        private string DisplayWord
        {
            get { return (string)Session["DisplayWord"]; }
            set { Session["DisplayWord"] = value; }
        }

        private List<char> GuessedLetters
        {
            get { return (List<char>)Session["GuessedLetters"]; }
            set { Session["GuessedLetters"] = value; }
        }

        private int Lives
        {
            get { return (int)Session["Lives"]; }
            set { Session["Lives"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StartNewGame();
            }
            UpdateUI();
        }

        private void StartNewGame()
        {
            Random random = new Random();
            Word = WordList[random.Next(WordList.Count)];
            DisplayWord = new string('_', Word.Length);
            GuessedLetters = new List<char>();
            Lives = MaxLives;
            lblMessage.Text = string.Empty;
            UpdateUI();
        }

        private void UpdateUI()
        {
            lblWord.Text = "Word: " + DisplayWord;
            lblLives.Text = "Lives Remaining: " + Lives;
            lblGuessedLetters.Text = "Guessed Letters: " + string.Join(", ", GuessedLetters);
        }

        protected void BtnGuess_Click(object sender, EventArgs e)
        {
            char letter;
            if (!char.TryParse(txtLetter.Text, out letter))
            {
                lblMessage.Text = "Please enter a valid letter.";
                return;
            }

            letter = char.ToLower(letter);
            if (GuessedLetters.Contains(letter))
            {
                lblMessage.Text = "You already guessed that letter!";
                return;
            }

            GuessedLetters.Add(letter);

            if (Word.Contains(letter))
            {
                var updatedWord = DisplayWord.ToCharArray();
                for (int i = 0; i < Word.Length; i++)
                {
                    if (Word[i] == letter)
                    {
                        updatedWord[i] = letter;
                    }
                }
                DisplayWord = new string(updatedWord);
            }
            else
            {
                Lives--;
            }

            if (Lives <= 0)
            {
                lblMessage.Text = "Game Over! The word was: " + Word;
                btnGuess.Enabled = false;
            }
            else if (!DisplayWord.Contains('_'))
            {
                lblMessage.Text = "Congratulations! You guessed the word!";
                btnGuess.Enabled = false;
            }

            txtLetter.Text = string.Empty;
            UpdateUI();
        }

        protected void BtnNewGame_Click(object sender, EventArgs e)
        {
            StartNewGame();
            btnGuess.Enabled = true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HJD.Pexeso.Engine;
using HJD.Pexeso.Engine.DTO;
using HJD.Pexeso.FormGUI.Helpers;

namespace HJD.Pexeso.FormGUI
{
	public partial class MainForm : Form
	{
		private PexesoGame game;
		private Dictionary<Guid, PictureCard> cards;
		private int cardsCount = 64;
		private int groupSize = 2;
		private List<Player> players = new List<Player>();

		public MainForm()
		{
			InitializeComponent();
			players.Add(new Player() { Name = "Player 1" });
			players.Add(new Player() { Name = "Player 2" });
			game = new PexesoGame();
			game.GameController.OnGameChanged += new EventHandler(GameController_OnGameChanged);
		}

		void pictureCard_Click(object sender, EventArgs e)
		{
			if (game.Model.GetGameState() == HJD.Pexeso.Engine.Model.GameState.WaitingForNextRoundApproval)
			{
				game.GameController.ApproveNextRound(game.Model.GetActivePlayer());
			}
			else
			{
				game.GameController.CardSelected(game.Model.GetActivePlayer(), ((PictureCard)sender).Id);
			}
		}

		void GameController_OnGameChanged(object sender, EventArgs e)
		{
			if (this.cards != null)
			{
				BoardHelper.UpdateCards(this.cards, game.Model.GetCards());
			}

			if (game.Model.GetGameState() != HJD.Pexeso.Engine.Model.GameState.Initialzed)
			{
				Player activePlayer = game.Model.GetPlayer(game.Model.GetActivePlayer());
				lstPlayers.Items.Clear();
				ListViewItem item;
				int groupSize = game.Model.GetGameBoard().CardGroupSize;
				foreach (Player player in game.Model.GetPlayers())
				{
					item = new ListViewItem(new string[] {player.Name, (player.FoundCards.Count() / groupSize).ToString()});
					if (game.Model.GetActivePlayer() == player.Id)
					{
						item.BackColor = Color.LightBlue;
					}
					lstPlayers.Items.Add(item);
				}

				if (game.Model.GetGameState() == HJD.Pexeso.Engine.Model.GameState.Finished)
				{
					MessageBox.Show("Game over", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (MessageBox.Show("Do you really want to quit ?", "Quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				e.Cancel = true;
			}
		}

		private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.cards != null)
			{
				BoardHelper.ClearPictureCards(this.cards);
			}

			this.game.GameController.RemovePlayers();

			foreach (Player player in this.players)
			{
				this.game.GameController.AddPlayer(player.Name);
			}

			this.players = this.game.Model.GetPlayers();

			this.game.GameController.NewGame(this.cardsCount, this.groupSize);

			GameBoard gameBoard = game.Model.GetGameBoard();
			List<Card> cards = game.Model.GetCards();

			List<Bitmap> frontPictures = null;
			Bitmap backPicture = null;
			//int cardWidth = this.pnlGameBoard.Width / gameBoard.Width - BoardHelper.PICTURE_PADDING;
			try
			{
				frontPictures = BoardHelper.LoadFrontPictures(cards.Count / gameBoard.CardGroupSize);
				backPicture = BoardHelper.LoadBackPicture();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + " -- " + ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			this.cards = BoardHelper.CreateCards(cards, frontPictures, backPicture, BoardHelper.PICTURE_WIDTH, new EventHandler(pictureCard_Click));
			foreach (PictureCard pictureCard in this.cards.Values)
			{
				pnlGameBoard.Controls.Add(pictureCard);
			}
			BoardHelper.DealCards(gameBoard.Cards, gameBoard.Width, gameBoard.Height, this.cards);
			ResizeBoard(gameBoard.Width, gameBoard.Height);
		}

		private void ResizeBoard(int width, int heigth)
		{
			this.pnlGameBoard.Size = new Size(BoardHelper.PICTURE_PADDING * (width + 1) + BoardHelper.PICTURE_WIDTH * width, BoardHelper.PICTURE_PADDING * (heigth + 1) + BoardHelper.PICTURE_WIDTH * heigth);
			this.Size = new Size(this.pnlGameBoard.Width + (this.pnlGameBoard.Location.X * 3) + this.lstPlayers.Width + 10, this.pnlGameBoard.Height + (this.pnlGameBoard.Location.Y * 3));
			this.lstPlayers.Height = this.pnlGameBoard.Height;
		}

		private void playersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PlayerSettingsForm psf = new PlayerSettingsForm(this.players);
			psf.ShowDialog(this);
			if (psf.DialogResult == DialogResult.OK)
			{
				this.players = new List<Player>(psf.Players);
				newGameToolStripMenuItem.Enabled = this.players.Count > 0 ? true : false;
			}
		}

		private void boardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BoardSettingsForm bsf = new BoardSettingsForm(this.cardsCount, this.groupSize);
			bsf.ShowDialog(this);
			if (bsf.DialogResult == DialogResult.OK)
			{
				this.cardsCount = bsf.CardsCount;
				this.groupSize = bsf.GroupSize;
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{

		}
	}
}

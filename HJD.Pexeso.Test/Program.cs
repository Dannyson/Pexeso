using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HJD.Pexeso.Engine;
using HJD.Pexeso.Engine.Interface;
using HJD.Pexeso.Engine.DTO;

namespace HJD.Pexeso.Test
{
	class Program
	{
		private static PexesoGame game = new PexesoGame();
		private static int pocetSloupecku = 8;

		static void Main(string[] args)
		{
			Console.WriteLine("Zadejte jména hráčů, přidávání ukončíte prázdným jménem");
			string playerName = string.Empty;
			do
			{
				Console.Write("Jméno hráče: ");
				playerName = Console.ReadLine();
				if (!string.IsNullOrEmpty(playerName))
				{
					game.GameController.AddPlayer(playerName);
				}
			} while (!string.IsNullOrEmpty(playerName));

			Console.Clear();
			Console.Write("Zadejte celkový počet kartiček: ");
			int pocetKarticek = int.Parse(Console.ReadLine());
			Console.Write("Zadejte počet kartiček v jedné skupině pro nalezení (Default=2): ");
			int velikostSkupin = int.Parse(Console.ReadLine());

			game.GameController.OnGameChanged += new EventHandler(GameController_OnGameChanged);
			try
			{
				game.GameController.NewGame(pocetKarticek, velikostSkupin);
			}
			catch (PexesoException e)
			{
				Console.WriteLine(e.Message);
			}

			List<Player> players = game.Model.GetPlayers();
			List<Card> cards = game.Model.GetCards();
			int x, y;
			while (game.Model.GetGameState() != HJD.Pexeso.Engine.Model.GameState.Finished)
			{
				Console.WriteLine();
				Console.WriteLine();
				if (game.Model.GetGameState() == HJD.Pexeso.Engine.Model.GameState.WaitingForNextRoundApproval)
				{
					Console.WriteLine("Pro pokračování stiskněte klávesu.");
					Console.ReadKey();
					game.GameController.ApproveNextRound(game.Model.GetActivePlayer());
				}
				else
				{
					Console.WriteLine("Otočit kartičku:");
					Console.Write("Sloupeček> ");
					x = int.Parse(Console.ReadLine());
					Console.Write("Řádek> ");
					y = int.Parse(Console.ReadLine());

					game.GameController.CardSelected(game.Model.GetActivePlayer(), game.Model.GetGameBoard().Cards[x-1,y-1]);
					//game.GameController.CardSelected(game.Model.GetActivePlayer(), game.Model.GetCards()[(y - 1) * pocetSloupecku + x - 1].Id);
				}
			}

			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("Konec");
			Console.ReadKey();
		}

		static void GameController_OnGameChanged(object sender, EventArgs e)
		{
			Console.Clear();
			Console.WriteLine("Na řadě je hráč:  " + game.Model.GetPlayer(game.Model.GetActivePlayer()).Name);
			Console.WriteLine("Hráči: ");
			foreach (Player player in game.Model.GetPlayers())
			{
				Console.WriteLine(string.Format("- {0} / {1}", player.Name, player.FoundCards.Count.ToString()));
			}

			Console.WriteLine("-------------------------------------");
			Console.WriteLine("-----------HERNI POLE----------------");
			Console.Write("    ");

			GameBoard gameBoard = game.Model.GetGameBoard();

			for (int x = 1; x <= gameBoard.Width; x++)
			{
				Console.Write(string.Format("{0,3} ", x.ToString()));
			}
			Console.WriteLine();

			int i = 0;
			string stav;
			for (int y = 0; y < gameBoard.Height; y++)
			{
				Console.Write(string.Format("{0,2} ", (y+1).ToString()));

				for (int x = 0; x < gameBoard.Width; x++)
				{
					if (game.Model.GetCard(gameBoard.Cards[x, y]).Removed)
					{
						stav = " ";
					}
					else
					{
						stav = game.Model.GetCard(gameBoard.Cards[x, y]).IsTurnedFaceUp ? game.Model.GetCard(gameBoard.Cards[x, y]).GroupId.ToString() : "D";
					}

					Console.Write(string.Format(" {0,3}", stav));
					i++;
					if (i == gameBoard.CardCount)
					{
						break;
					}
				}

				Console.WriteLine();
			}
		}
	}
}

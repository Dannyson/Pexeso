using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HJD.Pexeso.Engine.DTO;

namespace HJD.Pexeso.FormGUI
{
	public partial class PlayerSettingsForm : Form
	{
		private BindingList<Player> players;

		public BindingList<Player> Players
		{
			get { return players; }
		}

		public PlayerSettingsForm(List<Player> players)
		{
			this.players = new BindingList<Player>(new List<Player>(players));

			InitializeComponent();

			lstPlayers.DataSource = this.players;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{

			this.DialogResult = DialogResult.OK;
		}

		private void lstPlayers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (((ListBox)sender).SelectedItem != null)
			{
				txtName.Text = ((Player)(((ListBox)sender).SelectedItem)).Name;
				btnEdit.Enabled = true;
				btnDelete.Enabled = true;
			}
			else
			{
				btnEdit.Enabled = false;
				btnDelete.Enabled = false;
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			players.Remove((Player)lstPlayers.SelectedItem);
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtName.Text))
			{
				Player player = lstPlayers.SelectedItem as Player;
				player.Name = txtName.Text;
				players.ResetBindings();
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtName.Text))
			{
				players.Add(new Player() { Name = txtName.Text });
				txtName.Text = string.Empty;
			}
		}
	}
}

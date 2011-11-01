using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HJD.Pexeso.FormGUI
{
	public partial class BoardSettingsForm : Form
	{
		private int cardsCount;
		private int groupSize;

		public int GroupSize
		{
			get { return groupSize; }
		}

		public int CardsCount
		{
			get { return cardsCount; }
		}

		public BoardSettingsForm(int cardsCount, int groupSize)
		{
			this.cardsCount = cardsCount;
			this.groupSize = groupSize;

			InitializeComponent();

			numCardsCount.Value = cardsCount;
			numGroupSize.Value = groupSize;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.cardsCount = (int)numCardsCount.Value;
			this.groupSize = (int)numGroupSize.Value;

			this.DialogResult = DialogResult.OK;
		}
	}
}

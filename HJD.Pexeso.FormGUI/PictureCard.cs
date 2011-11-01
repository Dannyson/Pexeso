using System;
// using System.Collections.Generic;
// using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace HJD.Pexeso.FormGUI
{
	public class PictureCard : PictureBox
	{
		private Guid id;
		private Image frontPicture;
		private Image backPicture;

		public Guid Id
		{
			get { return id; }
		}

		public Image FrontPicture
		{
			get { return frontPicture; }
		}

		public Image BackPicture
		{
			get { return backPicture; }
		}

		public Point Position
		{
			get { return this.Location; }
			set { this.Location = value; }
		}

		public PictureCard(Image frontPicture, Image backPicture, Guid id, int size)
		{
			this.Size = new Size(size, size);
			this.frontPicture = frontPicture;
			this.backPicture = backPicture;
			this.Image = FitImage(backPicture);
			this.id = id;
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BorderStyle = BorderStyle.FixedSingle;
		}

		private Image FitImage(Image original)
		{
			Image changed = new Bitmap(this.Width, this.Height);
			Rectangle source = new Rectangle(0, 0, original.Width, original.Height);
			Rectangle destination = new Rectangle(0, 0, this.Width, this.Height);
			Graphics g = Graphics.FromImage(changed);
			g.DrawImage(original, destination, source, GraphicsUnit.Pixel);
			return changed;
		}

		public void TurnFrontSideUp()
		{
			this.Image = FitImage(this.frontPicture);
		}

		public void TurnBackSideUp()
		{
			this.Image = FitImage(this.backPicture);
		}
	}
}

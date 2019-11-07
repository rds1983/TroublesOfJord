/* Generated by MyraPad at 08.11.2019 0:54:34 */
using Myra.Graphics2D.UI;

#if !XENKO
using Microsoft.Xna.Framework;
#else
using Xenko.Core.Mathematics;
#endif

namespace Wanderers.UI
{
	partial class GameView: HorizontalStackPanel
	{
		private void BuildUI()
		{
			_mapViewContainer = new Panel();
			_mapViewContainer.Id = "_mapViewContainer";

			var horizontalSeparator1 = new HorizontalSeparator();

			_skillsContainer = new HorizontalStackPanel();
			_skillsContainer.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Center;
			_skillsContainer.Id = "_skillsContainer";
			_skillsContainer.Height = 60;

			var horizontalSeparator2 = new HorizontalSeparator();

			var verticalStackPanel1 = new VerticalStackPanel();
			verticalStackPanel1.Proportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Fill,
			});
			verticalStackPanel1.Widgets.Add(_mapViewContainer);
			verticalStackPanel1.Widgets.Add(horizontalSeparator1);
			verticalStackPanel1.Widgets.Add(_skillsContainer);
			verticalStackPanel1.Widgets.Add(horizontalSeparator2);

			var verticalSeparator1 = new VerticalSeparator();

			_labelHp = new Label();
			_labelHp.Text = "H: 50/100";
			_labelHp.Id = "_labelHp";
			_labelHp.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Center;

			var verticalSeparator2 = new VerticalSeparator();

			_labelMana = new Label();
			_labelMana.Text = "M: 50/100";
			_labelMana.Id = "_labelMana";
			_labelMana.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Center;

			var verticalSeparator3 = new VerticalSeparator();

			_labelStamina = new Label();
			_labelStamina.Text = "E: 50/100";
			_labelStamina.Id = "_labelStamina";
			_labelStamina.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Center;

			var horizontalStackPanel1 = new HorizontalStackPanel();
			horizontalStackPanel1.Proportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Part,
			});
			horizontalStackPanel1.Proportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Auto,
			});
			horizontalStackPanel1.Proportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Part,
			});
			horizontalStackPanel1.Proportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Auto,
			});
			horizontalStackPanel1.Proportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Part,
			});
			horizontalStackPanel1.Widgets.Add(_labelHp);
			horizontalStackPanel1.Widgets.Add(verticalSeparator2);
			horizontalStackPanel1.Widgets.Add(_labelMana);
			horizontalStackPanel1.Widgets.Add(verticalSeparator3);
			horizontalStackPanel1.Widgets.Add(_labelStamina);

			var horizontalSeparator3 = new HorizontalSeparator();

			_mapContainer = new Panel();
			_mapContainer.Id = "_mapContainer";
			_mapContainer.Height = 247;

			var horizontalSeparator4 = new HorizontalSeparator();

			_logContainer = new Panel();
			_logContainer.Id = "_logContainer";

			var verticalStackPanel2 = new VerticalStackPanel();
			verticalStackPanel2.Widgets.Add(horizontalStackPanel1);
			verticalStackPanel2.Widgets.Add(horizontalSeparator3);
			verticalStackPanel2.Widgets.Add(_mapContainer);
			verticalStackPanel2.Widgets.Add(horizontalSeparator4);
			verticalStackPanel2.Widgets.Add(_logContainer);

			
			Proportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Part,
				Value = 2,
			});
			Proportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Auto,
			});
			Proportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Part,
			});
			Widgets.Add(verticalStackPanel1);
			Widgets.Add(verticalSeparator1);
			Widgets.Add(verticalStackPanel2);
		}

		
		public Panel _mapViewContainer;
		public HorizontalStackPanel _skillsContainer;
		public Label _labelHp;
		public Label _labelMana;
		public Label _labelStamina;
		public Panel _mapContainer;
		public Panel _logContainer;
	}
}
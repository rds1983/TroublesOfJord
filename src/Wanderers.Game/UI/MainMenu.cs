/* Generated by Myra UI Editor at 7/26/2017 12:21:01 AM */

using System;
using Wanderers.Storage;
using Myra;
using Myra.Graphics2D.UI;
using Wanderers.Core;
using System.Linq;
using System.Collections.Generic;

namespace Wanderers.UI
{
	public partial class MainMenu : Grid
	{
		private VerticalMenu _selectSlotMenu;
		private int _selectedSlotIndex;
		
		public MainMenu()
		{
			BuildUI();

			_startNewGameMenuItem.Selected += StartNewGameMenuItemOnSelected;

			_quitMenuItem.Selected += QuitMenuItemOnSelected;

			_textVersion.Text = "Version " + TJ.Version;
		}

		private void StartNewGameMenuItemOnSelected(object sender, EventArgs eventArgs)
		{
			_selectSlotMenu = new VerticalMenu
			{
				VerticalAlignment = VerticalAlignment.Center,
				HorizontalAlignment = HorizontalAlignment.Center
			};

			for (var i = 0; i < StorageService.SlotsCount; ++i)
			{
				var slot = TJ.StorageService.Slots[i];
				var name = slot.CharacterData == null ? Strings.EmptySlotName :
					slot.CharacterData.Name + ", " + slot.CharacterData.ClassId;
				var menuItem = new MenuItem(string.Empty, name);

				var i1 = i;
				menuItem.Selected += (o, args) =>
				{
					StartNewGame(i1);
				};
				_selectSlotMenu.Items.Add(menuItem);
			}

			var back = new MenuItem(string.Empty, Strings.BackName);
			back.Selected += (o, args) =>
			{
				Widgets.Remove(_selectSlotMenu);
				Widgets.Add(_mainMenu);
			};
			_selectSlotMenu.Items.Add(back);

			Widgets.Remove(_mainMenu);
			Widgets.Add(_selectSlotMenu);
		}

		private void StartNewGame(int slotIndex)
		{
			_selectedSlotIndex = slotIndex;
			var slot = TJ.StorageService.Slots[slotIndex];
			if (slot.CharacterData == null)
			{
				var dlg = new CharacterGenerationDialog();

				dlg.Closed += (s, a) =>
				{
					if (!dlg.Result)
					{
						return;
					}

					var data = new CharacterData
					{
						Name = dlg._textName.Text,
						ClassId = (string)dlg._comboClass.SelectedItem.Tag,
						Inventory = new Dictionary<string, int>()
					};

					slot.CharacterData = data;
					slot.Save();

					Play(slotIndex);
				};

				dlg.ShowModal(Desktop);
			}
			else
			{
				Play(slotIndex);
			}
		}

		private void Play(int slotIndex)
		{
			TJ.Session = new GameSession(slotIndex);

			WanderersGame.Instance.Desktop.Widgets.Remove(this);

			var gameView = new GameView();
			gameView.MapView.Map = TJ.Session.Player.Map;

			WanderersGame.Instance.Desktop.Widgets.Add(gameView);
		}

		private void QuitMenuItemOnSelected(object sender, EventArgs eventArgs)
		{
			MyraEnvironment.Game.Exit();
		}
	}
}
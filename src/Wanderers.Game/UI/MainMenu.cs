/* Generated by Myra UI Editor at 7/26/2017 12:21:01 AM */

using System;
using Wanderers.Storage;
using Myra;
using Myra.Graphics2D.UI;
using Wanderers.Core;

namespace Wanderers.UI
{
	public partial class MainMenu : Grid
	{
		private VerticalMenu _selectSlotMenu;
		private int _selectedSlotIndex;
		
		public MainMenu()
		{
			BuildUI();

			_playItem.Selected += PlayOnSelected;

			_quitMenuItem.Selected += QuitMenuItemOnSelected;

			_textVersion.Text = "Version " + TJ.Version;
		}

		private void PlayOnSelected(object sender, EventArgs eventArgs)
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
					Play(i1);
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

		private void Play(int slotIndex)
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
						ClassId = (string)dlg._comboClass.SelectedItem.Tag
					};

					slot.CharacterData = data;
					slot.Save();

					WanderersGame.Instance.Play(slotIndex);
				};

				dlg.ShowModal(Desktop);
				Desktop.FocusedKeyboardWidget = dlg._textName;
			}
			else
			{
				WanderersGame.Instance.Play(slotIndex);
			}
		}

		private void QuitMenuItemOnSelected(object sender, EventArgs eventArgs)
		{
			MyraEnvironment.Game.Exit();
		}
	}
}
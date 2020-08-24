/* Generated by Myra UI Editor at 27.02.2019 2:05:40 */
using Myra.Graphics2D.UI;
using Myra.Utility;

namespace TroublesOfJord.UI
{
	public partial class CharacterGenerationDialog: Dialog
	{
		public CharacterGenerationDialog()
		{
			BuildUI();

			_comboClass.Items.Clear();
			foreach (var cls in TJ.Module.Classes)
			{
				_comboClass.Items.Add(new ListItem(cls.Value.Name, null, cls.Key));
			}
			_comboClass.SelectedIndex = 0;

			_textName.TextChanged += _textName_TextChanged;

			UpdateEnabled();
		}

		private void _textName_TextChanged(object sender, ValueChangedEventArgs<string> e)
		{
			UpdateEnabled();
		}

		public void UpdateEnabled()
		{
			ButtonOk.Enabled = !string.IsNullOrEmpty(_textName.Text);
		}
	}
}
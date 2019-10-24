/* Generated by MyraPad at 24.10.2019 23:08:50 */
using Myra.Graphics2D.UI;

#if !XENKO
using Microsoft.Xna.Framework;
#else
using Xenko.Core.Mathematics;
#endif

namespace Wanderers.MapEditor.UI
{
	partial class ChooseMapDialog: Dialog
	{
		private void BuildUI()
		{
			_listMaps = new ListBox();
			_listMaps.Id = "_listMaps";
			_listMaps.Width = 200;
			_listMaps.Height = 300;

			
			Title = "Choose Map";
			Left = 424;
			Top = 62;
			Content = _listMaps;
		}

		
		public ListBox _listMaps;
	}
}
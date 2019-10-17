/* Generated by MyraPad at 16.03.2019 1:32:50 */
using Myra.Graphics2D.UI;
using System;
using Wanderers.Core;
using Wanderers.Core.Items;
using Wanderers.Utils;

namespace Wanderers.UI
{
	public partial class InventoryWindow: Window
	{
		public Player Player
		{
			get
			{
				return TJ.Session.Player;
			}
		}

		public InventoryWindow()
		{
			BuildUI();

			_gridEquipment.SetGridStyle();
			_gridInventory.SetGridStyle();

			_gridEquipment.HoverIndexChanged += OnEquipmentHoverIndexChanged;
			_gridEquipment.SelectedIndexChanged += OnEquipmentSelectedIndexChanged;

			_gridInventory.HoverIndexChanged += OnInventoryHoverIndexChanged;
			_gridInventory.SelectedIndexChanged += OnInventorySelectedIndexChanged;

			Rebuild();
		}

		private void Rebuild()
		{
			_gridEquipment.Widgets.Clear();
			_gridEquipment.RowsProportions.Clear();

			foreach (var item in Player.Equipment.Items)
			{
				var row = _gridEquipment.RowsProportions.Count;

				var textSlot = new Label
				{
					Text = "<" + item.Slot.ToString().ToLower() + ">",
					GridRow = row
				};
				_gridEquipment.Widgets.Add(textSlot);

				if (item.Item != null)
				{
					var textItem = new Label
					{
						Text = item.Item.Info.Name,
						GridColumn = 1,
						GridRow = row
					};

					_gridEquipment.Widgets.Add(textItem);
				}

				_gridEquipment.RowsProportions.Add(new Proportion());
			}

			_gridInventory.Widgets.Clear();
			_gridInventory.RowsProportions.Clear();

			foreach (var item in Player.Inventory.Items)
			{
				var row = _gridInventory.RowsProportions.Count;

				var textSlot = new Label
				{
					Text = item.ToString(),
					GridRow = row
				};
				_gridInventory.Widgets.Add(textSlot);

				_gridInventory.RowsProportions.Add(new Proportion());
			}
		}

		private void OnHoverIndexChanged(Grid grid, Item item)
		{
			if (grid.HoverRowIndex == null)
			{
				return;
			}

			_textDescription.Text = item.BuildDescription();
		}

		private void OnInventoryHoverIndexChanged(object sender, EventArgs e)
		{
			if (_gridInventory.HoverRowIndex == null)
			{
				return;
			}

			var item = Player.Inventory.Items[_gridInventory.HoverRowIndex.Value].Item;
			_textDescription.Text = item.BuildDescription();
		}

		private void OnEquipmentHoverIndexChanged(object sender, EventArgs e)
		{
			if (_gridEquipment.HoverRowIndex == null)
			{
				return;
			}

			var item = Player.Equipment.Items[_gridEquipment.HoverRowIndex.Value].Item;
			_textDescription.Text = item != null?item.BuildDescription():string.Empty;
		}

		private void OnInventorySelectedIndexChanged(object sender, EventArgs e)
		{
			if (_gridInventory.SelectedRowIndex == null)
			{
				return;
			}

			var index = _gridInventory.SelectedRowIndex.Value;
			_gridInventory.SelectedRowIndex = null;

			var item = Player.Inventory.Items[index].Item;
			var asEquip = item.Info as EquipInfo;
			if (asEquip == null)
			{
				return;
			}

			// Wear
			Player.Equipment.Equip(item);

			// Remove from inventory
			Player.Inventory.Add(item, -1);

			Rebuild();
		}

		private void OnEquipmentSelectedIndexChanged(object sender, EventArgs e)
		{
			if (_gridEquipment.SelectedRowIndex == null)
			{
				return;
			}

			var index = _gridEquipment.SelectedRowIndex.Value;
			_gridEquipment.SelectedRowIndex = null;

			var item = Player.Equipment.Items[index].Item;
			if (item == null)
			{
				return;
			}

			// Remove from equipment
			Player.Equipment.Remove(index);

			// Add to inventory
			Player.Inventory.Add(item, 1);

			Rebuild();
		}
	}
}
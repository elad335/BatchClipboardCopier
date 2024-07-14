using System.ComponentModel;
using System.Diagnostics;
using CliboardCopy.Models;

namespace CliboardCopy.UserControls
{
    /// <summary>
    /// Clipboard history text display mode view
    /// </summary>
    public partial class HistoryTextViewMode : UserControl
    {
        private const string IMAGE_LINK_PREFIX = "file://image_";

        public HistoryTextViewMode()
        {
            InitializeComponent();
        }

        private BindingList<ClipboardHistoryItemBase>? _items;

        /// <summary>
        /// Bind property to clipboard history log items collection
        /// </summary>
        [Description("Log items")]
        public BindingList<ClipboardHistoryItemBase>? Items
        {
            get => _items;
            set
            {
                if (_items != null)
                {
                    _items.ListChanged -= _items_ListChanged;
                }

                _items = value;
                if (_items != null)
                {
                    _items.ListChanged += _items_ListChanged;
                }
            }
        }

        private void _items_ListChanged(object? sender, ListChangedEventArgs e)
        {
            try
            {
                if (_items == null) return;

                switch (e.ListChangedType)
                {
                    case ListChangedType.ItemAdded:
                        DrawItem(_items[e.NewIndex]);
                        break;

                    default:
                        RedrawView();
                        return;
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private void RedrawView()
        {
            try
            {
                txtContent.Clear();
                if (_items == null) return;

                foreach (var item in _items)
                {
                    DrawItem(item);
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private void DrawItem(ClipboardHistoryItemBase item)
        {
            try
            {
                switch (item)
                {
                    case ClipboardHistoryItemText textItem:
                        txtContent.AppendText($" {textItem.Text}\r");
                        break;

                    case ClipboardHistoryItemImage imageItem:
                        txtContent.AppendText($"{imageItem.Time.ToShortDateString()} {imageItem.Time.ToShortTimeString()} {IMAGE_LINK_PREFIX}{imageItem.Id}\r");
                        break;
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private void DisplayError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtContent_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(e.LinkText)) return;

                if (e.LinkText.StartsWith(IMAGE_LINK_PREFIX))
                {
                    if (!Guid.TryParse(e.LinkText.Substring(IMAGE_LINK_PREFIX.Length), out Guid itemId)) return;

                    var item = _items?.FirstOrDefault(x => x.Id == itemId) as ClipboardHistoryItemImage;
                    if (item == null) return;

                    using (var displayImageForm = new ViewImageForm())
                    {
                        displayImageForm.Intialize(item.Image);
                        displayImageForm.ShowDialog();
                    }
                    return;
                }

                Process.Start("explorer.exe", e.LinkText);
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }
    }
}
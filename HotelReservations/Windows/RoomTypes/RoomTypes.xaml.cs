using HotelReservations.Model;
using HotelReservations.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelReservations.Windows
{
    /// <summary>
    /// Interaction logic for RoomTypes.xaml
    /// </summary>
    public partial class RoomTypes : Window
    {
        public RoomTypes()
        {
            InitializeComponent();
            FillData();
        }

        public void FillData()
        {
            var roomTypeService = new RoomTypeService();
            var roomTypes = Hotel.GetInstance().RoomTypes.Where(roomType => roomType.IsActive).ToList();

            RoomTypesDataGrid.ItemsSource = null;
            RoomTypesDataGrid.ItemsSource = roomTypes;
            RoomTypesDataGrid.IsSynchronizedWithCurrentItem = true;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addRoomTypeWindow = new AddRoomType();
            Hide();
            if (addRoomTypeWindow.ShowDialog() == true)
            {
                FillData();
            }
            Show();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var editRoomType = (RoomType)RoomTypesDataGrid.SelectedItem;
            if (editRoomType == null)
            {
                return;
            }
            var editRoomWindow = new EditRoomType(editRoomType);
            Hide();
            if (editRoomWindow.ShowDialog() == true)
            {
                FillData();
            }
            Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var deleteRoomType = (RoomType)RoomTypesDataGrid.SelectedItem;
            if (deleteRoomType == null)
            {
                return;
            }
            var deleteRoomWindow = new DeleteRoomType(deleteRoomType);
            Hide();
            if (deleteRoomWindow.ShowDialog() == true)
            {
                FillData();
            }
            Show();
        }

        private void RoomTypesDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.ToLower() == "IsActive".ToLower())
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

    }
}

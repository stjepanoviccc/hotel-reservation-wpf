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
            var roomTypes = roomTypeService.GetAllRoomTypes();

            RoomTypesDataGrid.ItemsSource = null;
            RoomTypesDataGrid.ItemsSource = roomTypes;
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

    }
}

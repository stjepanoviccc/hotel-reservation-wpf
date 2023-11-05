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
    /// Interaction logic for AddRoomType.xaml
    /// </summary>
    public partial class AddRoomType : Window
    {
        private RoomTypeService roomTypeService;
        private RoomType newRoomType;
        public AddRoomType()
        {
            InitializeComponent();
            roomTypeService = new RoomTypeService();
            newRoomType = new RoomType();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            newRoomType.Id = roomTypeService.GetNextId();
            newRoomType.Name = RoomTypeTextBox.Text;
            roomTypeService.SaveRoomType(newRoomType);
            DialogResult = true;
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}

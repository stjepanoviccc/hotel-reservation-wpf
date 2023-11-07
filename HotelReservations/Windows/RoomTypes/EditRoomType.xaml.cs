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
    /// Interaction logic for EditRoomType.xaml
    /// </summary>
    public partial class EditRoomType : Window
    {
        private RoomTypeService roomTypeService;
        private RoomType contextRoomType;
        public EditRoomType(RoomType roomType)
        {
            InitializeComponent();
            contextRoomType = new RoomType();
            roomTypeService = new RoomTypeService();
            contextRoomType = roomType.Clone();
            this.DataContext = contextRoomType;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            roomTypeService.EditRoomType(contextRoomType);
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

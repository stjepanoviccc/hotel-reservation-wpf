using HotelReservations.Service;
using HotelReservations.Model;
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
    /// Interaction logic for AddEditRoom.xaml
    /// </summary>
    public partial class AddEditRoom : Window
    {
        private RoomTypeService roomTypeService;
        private RoomService roomService;
        private Room contextRoom;
        public AddEditRoom(Room? room = null)
        {
            if (room == null)
            {
                contextRoom = new Room();
            }
            else
            {
                contextRoom = room.Clone();
            }
            InitializeComponent();
            roomTypeService = new RoomTypeService();
            roomService = new RoomService();
            AdjustWindow(room);
            this.DataContext = contextRoom;
        }

        public void AdjustWindow(Room? room = null)
        {
            if (room != null)
            {
                Title = "Edit Room";
            }
            else
            {
                Title = "Add Room";
            }

            var roomTypeList = Hotel.GetInstance().RoomTypes.Where(roomType => roomType.IsActive).ToList();
            RoomTypeComboBox.ItemsSource = roomTypeList;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            roomService.SaveRoom(contextRoom);
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

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
        public AddEditRoom(Room? room = null)
        {
            InitializeComponent();
            roomTypeService = new RoomTypeService();
            roomService = new RoomService();
            AdjustWindow(room);
        }

        public void AdjustWindow(Room? room = null)
        {

            if (room != null)
            {
                Title = "Edit Room";
               // FillFormWithEditRoom(room);
            }
            else
            {
                Title = "Add Room";

                var roomTypeList = roomTypeService.GetAllRoomTypes();

                foreach (var roomType in roomTypeList)
                {
                    RoomTypeComboBox.Items.Add(roomType.Name);
                }
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

            var newRoom = new Room();
            newRoom.Id = roomService.GetNextId();
            newRoom.RoomNumber = RoomNumberTextBox.Text;
            newRoom.HasTV = HasTvCheckBox.IsChecked ?? false;
            newRoom.HasMiniBar = HasMiniBarCheckBox.IsChecked ?? false;
            newRoom.IsActive = true;

            var selectedRoomTypeName = (string)RoomTypeComboBox.SelectedItem;
            if (selectedRoomTypeName != null)
            {
                newRoom.RoomType = roomTypeService.GetRoomTypeByName(selectedRoomTypeName);
                
            }
            roomService.SaveRoom(newRoom);
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

using HotelReservations.Model;
using HotelReservations.Service;
using System.Linq;
using System.Windows;

namespace HotelReservations.Windows
{
    /// <summary>
    /// Interaction logic for AddEditPrices.xaml
    /// </summary>
    public partial class AddEditPrices : Window
    {
        private PriceService priceService;
        private Price contextPrice;
        private bool isEditing;
        public AddEditPrices(Price? price = null)
        {
            if (price == null)
            {
                contextPrice = new Price();
                isEditing = false;
            }
            else
            {
                contextPrice = price.Clone();
                isEditing = true;
            }
            InitializeComponent();
            priceService = new PriceService();
            AdjustWindow(price);
            this.DataContext = contextPrice;
        }

        private void AdjustWindow(Price? price = null)
        {
            if (price != null)
            {
                Title = "Edit price";
                // UserTypeCB.SelectedItem = user.GetType().Name;
                //  UserTypeCB.IsEnabled = false;
            }
            else
            {
                Title = "Add price";
                //   UserTypeCB.SelectedValue = "User";
            }
            var roomTypeList = Hotel.GetInstance().RoomTypes.Where(roomType => roomType.IsActive).ToList();
            var reservationTypeList = Hotel.GetInstance().ReservationTypes.ToList();
            RoomTypeCB.ItemsSource = roomTypeList;
            ReservationTypeCB.ItemsSource = reservationTypeList;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // validation passed
            priceService.SavePrice(contextPrice);
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}

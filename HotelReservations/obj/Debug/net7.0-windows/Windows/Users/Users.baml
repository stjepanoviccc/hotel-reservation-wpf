   M S B A M L   `   `   `  ����L  HHotelReservations, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:HotelReservations.WindowsHotelReservations.Windows  5   	   %    HotelReservations.Windows.Users   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:HotelReservations.Windows     5   	     � Title$  Users��5   	   $	��450��6   $	��800��6$   .��5	      �  � RowDefinitions 5
   
   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� $��	Username:��6   $��Center=�6(   �� 5      -   5        $��UsernameSearchTextBox��5      $��24��63   $	��150��6?   $��3q�6K   $��Center=�6V   6x   5      c� 5   
   $��1��6   .@�5      �� -   5        $��	AddButton��5      $	��Add��6&   
���   �$��5,0,5,0q�6H   $��5,0,0,0q�6Z   6�   �� 5      -   5        $��
EditButton��5      $
��Edit��6'   
���   �$��5,0,5,0q�6J   $��5,0,0,0q�6\   6�   �� 5      -   5        $��DeleteButton��5      $��Delete��6)   
���   �$��5,0,5,0q�6N   $��5,0,0,0q�6`   6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��UsersDataGrid��5   7      SelectionMode$ Single=�6   $��2��6*      
IsReadOnly$
 True��6L   5      5      5      
   M S B A M L   `   `   `  ����J  FCarRentalClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CarRentalClientCarRentalClient  5   	   #    CarRentalClient.RentCarWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:CarRentalClient     5   	     � Title$  Wypożycz samochód��5   	   $	��450��6#   $	��800��60   .��5	      �  � ColumnDefinitions 5
   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   .+�5   
   �� $��0��6   .+�5      �� -   5        $��Namelb��5      $��Imię��6"   63   �� 5      -   5        $��Nametb��5      6&   �� 5      -   5        $��
SureNamelb��5      $��Nazwisko��6&   6;   �� 5      -   5        $��
SureNametb��5      6*   �� 5      -   5        $��Datelb��5      $��Data urodzenia��6"   6=   (  "System.Windows.Controls.DatePicker  5      -   5        $��dp��5      6%   �� 5      -   5        $��CarIDlb��5      $��
ID pojazdu��6#   6:   �� 5      -   5        $��CarIDtb��5      6'   �� 5      -	   5        $
��Rent��5      $��Wypożycz samochód��6!   6R   �� 5      -
   5        $
��idlb��5      $��ID��6    6/   �� 5      -   5        $
��idtb��5      6$   �� 5      -   5        $��EndRent��5      $&�� Zakończ wypożyczenie samochodu��6$   6e   �� 5      -   5        $��CarList��5      $��Lista Pojazdów��6$   6U   �� 5      -   5        $
��Back��5      $��Powrót��6!   6G   5       &   System.Windows.Controls.DataGrid  5!   
   -   5        $��DataGrid��5!      $��1��6#   65   5"      5#      
   M S B A M L   `   `   `  ����J  FCarRentalClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CarRentalClientCarRentalClient  5   	   "    CarRentalClient.AddCarWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:CarRentalClient     5   	     � Title$  Baza samochodów��5   	   $	��450��6!   $	��800��6.   .��5	      �  � ColumnDefinitions 5
   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� $��0��6   $��0��6%   $��5��62   .+�5      �� -   5         ��Name$ 
carbrandlb��5      $��Marka pojazdu��6(   6C   �� 5      -   5        $��
carbrandtb��5      �� 5      -   5        $��
carmodellb��5      $��Model pojazdu��6&   6@   �� 5      -   5        $��
carmodeltb��5      6+   �� 5      -   5        $��productionyearlb��5      $��Rok produkcji pojazdu��6,   6O   �� 5      -   5        $��productionyeartb��5      60   �� 5      -   5        $��enginepowerlb��5      $��Moc silnika pojazdu [KM]��6)   6N   �� 5      -   5        $��enginepowertb��5      6-   �� 5       -	   5        $��
fueltypelb��5       $��Typ paliwa pojazdu��6&   6E   �� 5!      -
   5        $
��cBox��5!      5"      �� 5$      -   5        $��	AddCarbtn��5$      $��Dodaj��6&   6P   �� 5%      -   5        $
��Idlb��5%      $��Id��6    60   �� 5&      -   5        $
��Idtb��5&      6$   �� 5'      -   5        $��UpdateCarbtn��5'      $��Zmień��6)   5)      �� 5+      -   5        $��DeleteCarbtn��5+      $��Usuń��6)   68   �� 5,      -   5        $��Backbtn��5,      $��Powrót��6$   6M   5-      &   System.Windows.Controls.DataGrid  50   
   -   5        $��DataGrid��50      $��1��6#   $��0��63   $��5��6@   6S   52      53      
   M S B A M L   `   `   `  ����E  ALogisticDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:LogisticDB
LogisticDB  5   	       LogisticDB.BuyCarWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:LogisticDB     5   	     � Title$  BuyCarWindow��5   	   $	��500��6   $	��600��6+   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6   $��City:��6-   $��4q�6=   �� 5   
   -   5        $��CitiesComboBox��5   0   $��0��6   $��1��6    $��4q�6F    �� DisplayMemberPath$
 name��6Q   $	��100��6j   �� 5   
   $��0��6   $��2��6   $��Type:��6-   $��4q�6=   �� 5    
   -   5        $��CarTypeComboBox��5    0   $��0��6   $��3��6    $��4q�6G   $
 name��6R   $	��100��6k   �� 5!   
   $��1��6   $��0��6   $��Date:��6-   $��4q�6=   &   System.Windows.Controls.Calendar  5"   
   -   5        $��DateCalender��5"      $��1��6'   $��1��64   $��2��6D   �� 5#   
   $��2��6   $��0��6   $��Number:��6-   $��4q�6?   �� 5$   
   -   5        $��NumberTextBox��5$   /   $��2��6   $��1��6   $��4q�6D   $	��100��6O   �� 5%   
   $��3��6   $��0��6   $��Cost:��6-   $��4q�6=   �� 5&   
   -   5        $��CostTextBox��5&   /   $��3��6   $��1��6   $��4q�6B   $	��100��6M   �� 5'   
   $	��100��6   $	��100��6'    �� Orientation$ 
Horizontal=�66   .+�5(      �� -   5        $��OkButton��5(      $��OK��6<   $	��100��6I   $��30��6U   $��8q�6a   �� 5)      -   5        $��CancelButton��5)      $��Cancel��6D   $	��100��6U   $��30��6a   $��8q�6m   5*      5+      5,      
   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��20 �6   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   o� .@�5      m� $��Soubor��6   .@�5      m� -   5        $��	Otevřít��5      6,   m� 5      -   5        $��Uložit��5      6+   5      5      �� 5   
   -   5         ��Name$ drawingCanvas��5      
�������$��2��6;   5   0   �� 5   
   
�������$��2��6!   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   .+�5      ��    
BrushImage#��[  6   �� 5      $��Tloušťka štětce��6   $��Center=�6.   �� 5      -   5         ��Name$ 	BrushSize��5       � Minimum$ 1Q�6(    � Maximum$ 25Q�64   $	��180��6A   $��Center=�6M   �� 5      $��Barva��6   $��Center=�6$   �� 5      -   5         ��Name$ ButtonColor��5      $��70��6*   
���   �6O   5!      5"      5#      
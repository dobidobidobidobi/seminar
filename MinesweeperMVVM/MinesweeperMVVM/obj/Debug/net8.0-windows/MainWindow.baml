   M S B A M L   `   `   `  ����J  FMinesweeperMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MinesweeperMVVMMinesweeperMVVM  5   	        MinesweeperMVVM.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:MinesweeperMVVM     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   $	��132��5	   	   $	��400��6   ���#181920 � 	Resources 5       �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value   CustomComboBoxItemTemplate �� Padding  CustomComboBoxTemplate	 �� 
TargetType
 d�Name �� 	ClickMode d� 	IsChecked �� Mode �� RelativeSource ��Name J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate �Name �� IsDropDownOpen � AllowsTransparency �Name J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight ��Name K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation �� Triggers �� 
TargetName��%�  '��       &	  �     &	 D    �� 5   
   " ��6    5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � ��
 �   �63   5      5      �� 5   
   .R�5      �� ���#333333$ 5q�6*   
���   �$��1q�6J   ._�5      �� 
�������$��16(�6@   $
��Bold"�6N   ��6   �� 6N   5      5      �� 5   
   "	 ��69   .R�5      � .+�5      d� $
 ToggleButton��6   $��2��5       $|�false��5!      $ Press=�5#      ���#20203A$��Stretch=�5%      $��Right=�5&       5"      �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+��5'      �� 5(      " d�6    .�5)      ��  � �� 5*   "   �� 5+   &   "	 d�66   .R�5,   *   �� #��z��61   
���   �$��1q�5-   1   ._�5.   .   � .+�5/   2   �� $��Right=�6C   $��Center=�6_   F� 50   2   "����        � 	=  	= � z     	
�������$��Center=�52   7   $��Right=�53   7   $��0,0,10,0q�54   7   55   /   56   +   57   '   59      5;      5=      �� 5@      $ ContentSite��6#   $ False��5A   #   #��z 5B   #   #��z 5C   #   #��z��5D   #   $��4,2,25,2q�5E   #   $��Center=�5F   #   $
��Left=�5G   #   � 5J      $ Popup��6   $��Bottom=�5K      #��z 5L      $
 True��5M      $|�False��5N      $��Slide=�5O      .��5P      � $ DropDown��6   $
 True��5Q      #��z 5R      #��z 5S      .+�5T      �� $ DropDownBorder��6!   ���#20203A
���   �$��1q�5W   !   �� 5X      $��4q�6'   $
 True��5Y   '   .��5[      �� $
 True��6)   $ 	Contained=�5\   )   5]      5^      5_      5`       5b      P� 5c       �@��HasItems$ false��6.   . �5d      �� $ DropDownBorder��6    � ��$ 95��6N   5e      P� 5f       � {�$ false��6/   . �5g      ��  � ��
 �   �63   5h      P� 5i       �@J�IsMouseOver$
 true��61   . �5j      �� $ DropDownBorder��6    � �� �#20203A6O   �� 5k      $ ToggleButton��6    � �� �#20203A6M   5l      P� 5o       �@��
IsGrouping$
 true��60   . �5p      ��  � ��$ false��6F   5q      5t      5u      .��5w      �  � RowDefinitions 5x   
   �� 5y      $��82 �6   �� 5z      $��* �6   .+�5|   
   �� $��0��6   ���#181920$��
8, 8, 8, 4q�5}      ���#20203A._�5~      A�   A� Columns$  3��6   .+�5      �� ! �� Orientation$! 
Horizontal=�6   $��Center=�66   .+�5�      �� $	��200��6   $��60��6+   $��Center=�67   $��Center=�6R   
�������$��16(�5�   2   $
��Bold"�6@   #��[  5�      #��[ 5�      ��5�      �� *Difficulties+" �� SelectedItem" 5�      �� *SelectedDifficulty+$ TwoWay=�5�      d� 5�      $��50��6#   5�      5�      5�      5�      �� 5�   
   $��1��6   ���#181920$��
8, 4, 8, 8q�5�      ���#20203A._�5�      �� $
}�True��6   .+�5�      A� 5�      5�      5�      5�      5�      
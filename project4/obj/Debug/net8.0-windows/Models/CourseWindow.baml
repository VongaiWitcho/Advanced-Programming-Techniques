   M S B A M L   `   `   `  ����  project4    project4.CourseWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Add/Edit Course��5   	   $	��400��6!   $	��600��6.   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��* �6   �� 5
      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6"   $��0,0,0,10q�69   .+�5      �� $��Course Name:��6   $��0,0,0,5q�6,   �� 5      -   5         ��Name$ CourseNameTextBox��5      5      �� 5   
   $��1��6   $ Vertical=�6"   $��0,0,0,10q�69   .+�5      �� $��Select Teacher:��6   $��0,0,0,5q�6/   �� 5      -   5         ��Name$ TeacherComboBox��5      $��25��60   5      � 5   
   $��2��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5      �� $��0��6   .+�5      �� $��Available Students��6   $��0,0,0,5q�66   �� 5       -   5         ��Name$ AvailableStudentsListBox��5       $	��200��5"      5#      �� 5%      $��1��6   $��Center=�6)   $
��10,0q�6D   .+�5&      �� -   5        $��>>��5&      $��5q�6I   �� 5'      -   5        $��<<��5'      $��5q�6J   5(      �� 5+      $��2��6   .+�5,      �� $��Selected Students��6   $��0,0,0,5q�65   �� 5-      -   5        $ SelectedStudentsListBox��5-      $	��200��5/      50      51      �� 53   
   -   5         ��Name$ 
SaveButton��53      $	��Add��54      $��3��55      $��Right=�57      $��0,10,0,0q�58      $��80��59      5:      5;      
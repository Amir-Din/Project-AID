   M S B A M L   `   `   `  ����>  :AID, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:AIDAID  5   	   =#clr-namespace:AID.View.UserControlsAID.View.UserControls  5   	       AID.CharityMange   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:AID     5   	   <userControls#clr-namespace:AID.View.UserControls     5   	     � Title$  CharityMange��5	   	   $	��425��5
   	   $	��500��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � Icon$ /Red-Cross.ico��5   	    � WindowStyle$ 
ToolWindow=�5   	   .��5      � ���	#FFE5E5E5 � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��1 �6   �� 5      .+�5   
   �� $��0��6   
������� �� Orientation$ 
Horizontal=�5      .+�5      �� -   5         ��Name$ btnAdd��5      $��افزودن��5         
btnCharity#��[  5      �� 5      -   5        $ 	btnUpdate��5      $��ویرایش��5      $��0,5,5,5q�5!      #��[  5"      �� 5#      -   5        $ 	btnDelete��5#      $��حذف��5$      $��0,5,7,5q�5&      #��[  5'      $   AID.View.UserControls.TextBox1  5(      -   5          Name$ 
txtCharity��5(   $   $��60��5)   $   $	��220��5*   $   	   MaxLen$	 25��5+   $   
   Placeholder$
 ...عنوان خیریه��5,   $      RtoL$ Right��5-   $   5.      �� 5/   
   $��1��6   
�������50      �� 51   
   -   5         ��Name$ 
lstCharity��51      $	��400��52      $��2��53      $��20(�54      $��Center=�56      $��25q�57      59      5:      5;      
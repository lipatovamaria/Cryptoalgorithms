   M S B A M L   `   `   `  ����B  >practic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:practicpractic  5   	       practic.SaveKeysWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:practic     5   	     � Icon$  	/icon.png��5   	    � Title$( "Введите имя файла: ��5	   	   $	��135��6%   $	��200��62    � 
ResizeMode$ NoResize=�6>   ���#E1DFFF � 	Resources 5
       �� 
TargetType   ButtonTemplate ��Name �� CornerRadius � Cursor �� Triggers	 P� Property
 P� Value �� 
TargetName �� Property �� Value��%�  &	        �� 5   
   " ��6   .R�5      �� $ buttonBorder��6   $ 15��5      ���#39acac$��2q�5      ���#a1c5e5$
 Hand��5      ._�5      �� #��z��6!   #��z��5   !   #��z��5   !   #��z��5   !   
�������#��z��5   !   $��14(�5   !   5       5      P� 5      	 � ��$

 true��6/   . �5      �� $ buttonBorder��6    � �� �#67a2d56M   �� 5      $ buttonBorder��6    � �� �#3194946N   5      5       5!      .��5#      � .+�5$   
   �� -   5         ��Name$ Save_Button��5$   <   #��[  6   $��Сохранить��6Q   $��35��6e   $	��Top=�6q   $��Center=�6�   $	��100��6�   $��0,50,0,0q�6�   6�   �� 5%   
   -   5         ��Name$ SaveFileName_TextBox��5%      $��Center=�60   $��0,20,0,0q�6M    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��140��6�   $��20��6�   5&      5'      
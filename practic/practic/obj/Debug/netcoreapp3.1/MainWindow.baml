   M S B A M L   `   `   `  ����B  >practic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:practicpractic  5   	       practic.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:practic     5   	     � Icon$  	/icon.png��5   	    � Title$ Ввод текста��5	   	   $	��600��6   $	��800��6*    � 
ResizeMode$ NoResize=�66   ���#E1DFFF � 	Resources 5
       �� 
TargetType   ButtonTemplate ��Name �� CornerRadius � Cursor �� Triggers	 P� Property
 P� Value �� 
TargetName �� Property �� Value��%  &	        �� 5   
   " ��6   .R�5      �� $ buttonBorder��6   $ 15��5      ���#39acac$��2q�5      ���#a1c5e5$��50��5      $	��150��5      $
 Hand��5      ._�5      �� #��z��6!   #��z��5   !   #��z��5   !   #��z��5   !   
�������#��z��5   !   $��14(�5   !   5       5      P� 5      	 � ��$

 true��6/   . �5      �� $ buttonBorder��6    � �� �#67a2d56M   �� 5      $ buttonBorder��6    � �� �#3194946N   5       5"      5#      .��5%      � -   5         �Name$ 
MyMainGrid��5%      .+�5&   
   �� ���#92A1FF$��1q�6&   $��Center=�6:   $	��470��6W   $��Center=�6d   $	��670��6   $ 20,20,20,20��6�   ._�5'      � .+�5(      �� $J��D*Двойной клик очищает текстовое поле.��6   $��12(�6H   
�������$
��Left=�6i   $��
50,421,0,0q�6�   $	��Top=�6�   $	��274��6�   $��30��6�   �� 5)      -   5         ��Name$
 Text��5)       �� TextWrapping$
 Wrap=�6T   $@��:Введите текст или откройте файл��6h   
�������$��12(�6�   $��50,40,230,40q�6�   �� 5*      -   5         ��Name$
 Next��5*   D   #��[  6   $��
Далее��6R   $��485,378,0,0q�6b   $
��Left=�6w   $	��Top=�6�   $
��Bold"�6�   6�   �� 5+      -   5        $ ReadFile��5+   D   #��[  6   $"��Чтение из файла��6V   $��
485,40,0,0q�6p   $
��Left=�6�   $	��Top=�6�   $
��Bold"�6�   6�   5,      5-      �� 5.   
   $
��Left=�6   $��120,111,0,0q�6+   $	��Top=�6@   5/      50      
   M S B A M L   `   `   `  ����H  DWpfAppDataSet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WpfAppDataSet.VentanasWpfAppDataSet.Ventanas  5   	   -    'WpfAppDataSet.Ventanas.EliminarPrestamo   5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:WpfAppDataSet.Ventanas     5   	     � Title$  Eliminar Prestamo��5	   	   $	��600��6#   $	��485��60   $	��600��6<   $	��485��6L    � WindowStartupLocation$ CenterScreen=�6[    � 
ResizeMode$ CanMinimize=�6�   .��5
      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63    �� Opacity$ 0.905Q�6F    �� RelativeTransform 5      V� 5      .~�5      ��  �� CenterY$	 0.5Q�6)    �� CenterX$	 0.5Q�67   	 �� ScaleY$	 -3Q�6E   
 �� ScaleX$
 3Q�6Q   �� 5       �� AngleY$ 0Q�6(    �� AngleX$ 0Q�63    �� CenterY$	 0.5Q�6>    �� CenterX$	 0.5Q�6L   �� 5       �� Angle$	 -30Q�6*    �� CenterY$	 0.5Q�66    �� CenterX$	 0.5Q�6D   T� 5      5      .��5      �  � Color$ White��6   � 5      $ 	#FF7AB6FF��6    � Offset$ 1Q�61   � 5      $ 	#FF7AB6FF��6   $
 0.65Q�61   � 5      $ 	#FF7AB6FF��6   $ 0.475Q�61   � 5      $ White��6   $ 0.811Q�6-   � 5      $ 	#FF7AB6FF��6   $
 0.25Q�61   5      .+�5   
   �� $
��Left=�6   $��	98,10,0,0q�6/   $
��Wrap=�6B   $��Datos del Préstamo��6V   $��30(�6p   $	��Top=�6~   $8��2/WpfAppDataSet;component/Fonts/#Noto Sans TC Black)�6�   �� 5   
   $
��Left=�6   $��
88,100,0,0q�6/   $
��Wrap=�6C   $��ID Préstamo��6W   $	��Top=�6j   $��17(�6�   $9��3/WpfAppDataSet;component/Fonts/#Noto Sans TC Medium)�6�   �� 5   
   $
��Left=�6   $��
88,169,0,0q�6/   $
��Wrap=�6C   $��Libro��6W   $	��Top=�6d   $��17(�6|   $9��3/WpfAppDataSet;component/Fonts/#Noto Sans TC Medium)�6�   �� 5    
   $
��Left=�6   $��
88,239,0,0q�6/   $
��Wrap=�6C   $��Usuario��6W   $	��Top=�6f   $��17(�6~   $9��3/WpfAppDataSet;component/Fonts/#Noto Sans TC Medium)�6�   �� 5!   
   $
��Left=�6   $��
88,318,0,0q�6/   $
��Wrap=�6C   $��Fecha Préstamo��6W   $	��Top=�6m   $��17(�6�   $9��3/WpfAppDataSet;component/Fonts/#Noto Sans TC Medium)�6�   �� 5"   
   $
��Left=�6   $��
88,402,0,0q�6/   $
��Wrap=�6C   $��Fecha Devolución��6W   $	��Top=�6o   $��17(�6�   $9��3/WpfAppDataSet;component/Fonts/#Noto Sans TC Medium)�6�   �� 5#   
   -   5         ��Name$ tbxidPrestamo��5#      $
��Left=�6+   $��246,100,0,0q�6F   $
��Wrap=�6[   $��	TextBlock��6o   $	��Top=�6�   $��17(�6�   $8��2/WpfAppDataSet;component/Fonts/#Noto Sans TC Light)�6�   �� 5$   
   -   5        $ tbxLibro��5$      $
��Left=�6&   $��246,169,0,0q�6A   $
��Wrap=�6V   $��	TextBlock��6j   $	��Top=�6{   $��17(�6�   $8��2/WpfAppDataSet;component/Fonts/#Noto Sans TC Light)�6�   �� 5%   
   -   5        $ 
tbxUsuario��5%      $
��Left=�6(   $��246,239,0,0q�6C   $
��Wrap=�6X   $��	TextBlock��6l   $	��Top=�6}   $��17(�6�   $8��2/WpfAppDataSet;component/Fonts/#Noto Sans TC Light)�6�   �� 5&   
   -   5        $ 
tbxFecPres��5&      $
��Left=�6(   $��246,318,0,0q�6C   $
��Wrap=�6X   $��	TextBlock��6l   $	��Top=�6}   $��17(�6�   $8��2/WpfAppDataSet;component/Fonts/#Noto Sans TC Light)�6�   �� 5'   
   -   5        $ 	tbxFecDev��5'      $
��Left=�6'   $��246,402,0,0q�6B   $
��Wrap=�6W   $��	TextBlock��6k   $	��Top=�6|   $��17(�6�   $8��2/WpfAppDataSet;component/Fonts/#Noto Sans TC Light)�6�   �� 5(   
   -   5         ��Name$ btnEliminar��5(      $��Eliminar��6@   $
��Left=�6S   $��
88,478,0,0q�6n   $	��Top=�6�   $	��130��6�   $��54��6�   $��17(�6�   $2��,/WpfAppDataSet;component/Fonts/#Noto Sans TC)�6�   �� 5)   
   -   5        $ btnCancelar��5)      $��Cancelar��6@   $
��Left=�6S   $��262,478,0,0q�6n   $	��Top=�6�   $	��130��6�   $��54��6�   $��17(�6�   $2��,/WpfAppDataSet;component/Fonts/#Noto Sans TC)�6�   5+      5,      
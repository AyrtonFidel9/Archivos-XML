   M S B A M L   `   `   `  ����H  DWpfAppDataSet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WpfAppDataSet.VentanasWpfAppDataSet.Ventanas  5   	   *    $WpfAppDataSet.Ventanas.EliminarLibro   5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:WpfAppDataSet.Ventanas     5   	   -   5          � Title$  Eliminar Libro��5	   	   $	��452��6    $	��520��6-   $	��452��69   $	��520��6I   $	��452��5
   	   $	��520��6    � WindowStartupLocation$ CenterScreen=�6(    � 
ResizeMode$ CanMinimize=�6s   .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63    �� Opacity$ 0.905Q�6F    �� RelativeTransform 5      V� 5      .~�5      ��  �� CenterY$	 0.5Q�6)    �� CenterX$	 0.5Q�67   	 �� ScaleY$	 -3Q�6E   
 �� ScaleX$
 3Q�6Q   �� 5       �� AngleY$ 0Q�6(    �� AngleX$ 0Q�63    �� CenterY$	 0.5Q�6>    �� CenterX$	 0.5Q�6L   �� 5       �� Angle$	 -30Q�6*    �� CenterY$	 0.5Q�66    �� CenterX$	 0.5Q�6D   T� 5      5      .��5      �  � Color$ White��6   � 5      $ 	#FF7AB6FF��6    � Offset$ 1Q�61   � 5      $ 	#FF7AB6FF��6   $
 0.65Q�61   � 5      $ 	#FF7AB6FF��6   $ 0.475Q�61   � 5      $ White��6   $ 0.811Q�6-   � 5      $ 	#FF7AB6FF��6   $
 0.25Q�61   5      .+�5   
   �� $
��Left=�6   $��
147,10,0,0q�6/   $
��Wrap=�6C   $��30(�6W   $��Datos del Libro��6e   $	��Top=�6|   $8��2/WpfAppDataSet;component/Fonts/#Noto Sans TC Black)�6�   �� 5   
   $
��Left=�6   $��	57,85,0,0q�6/   $
��Wrap=�6B   $��ID Libro��6V   $	��Top=�6f   $��17(�6~   $9��3/WpfAppDataSet;component/Fonts/#Noto Sans TC Medium)�6�   �� 5    
   $
��Left=�6   $��
57,131,0,0q�6/   $
��Wrap=�6C   $��Título��6W   $	��Top=�6e   $��17(�6}   $9��3/WpfAppDataSet;component/Fonts/#Noto Sans TC Medium)�6�   �� 5!   
   $
��Left=�6   $��
57,209,0,0q�6/   $
��Wrap=�6C   $��	Editorial��6W   $	��Top=�6h   $��17(�6�   $9��3/WpfAppDataSet;component/Fonts/#Noto Sans TC Medium)�6�   �� 5"   
   $
��Left=�6   $��
57,267,0,0q�6/   $
��Wrap=�6C   $��N° Páginas��6W   $	��Top=�6i   $��17(�6�   $9��3/WpfAppDataSet;component/Fonts/#Noto Sans TC Medium)�6�   �� 5#   
   -   5         ��Name$ 
tbxIdLibro��5#      $
��Left=�6(   $��
157,85,0,0q�6C   $
��Wrap=�6W   $��	TextBlock��6k   $	��Top=�6|   $��17(�6�   $8��2/WpfAppDataSet;component/Fonts/#Noto Sans TC Light)�6�   �� 5$   
   -   5        $ 	tbxTitulo��5$      $
��Left=�6(   $��
57,166,0,0q�6C   $
��Wrap=�6W   $��	TextBlock��6k   $	��Top=�6|   $��17(�6�   $8��2/WpfAppDataSet;component/Fonts/#Noto Sans TC Light)�6�   $	��236��6�   �� 5%   
   -   5        $ tbxEditorial��5%      $
��Left=�6+   $��157,209,0,0q�6F   $
��Wrap=�6[   $��	TextBlock��6o   $	��Top=�6�   $��17(�6�   $8��2/WpfAppDataSet;component/Fonts/#Noto Sans TC Light)�6�   �� 5&   
   -   5        $ 
tbxPaginas��5&      $
��Left=�6)   $��157,267,0,0q�6D   $
��Wrap=�6Y   $��	TextBlock��6m   $	��Top=�6~   $��17(�6�   $8��2/WpfAppDataSet;component/Fonts/#Noto Sans TC Light)�6�   &   System.Windows.Controls.DataGrid  5'   
   -   5          Name$ 	dgAutores��5'         AutoGenerateColumns .  $
��Left=�6B   $	��191��6]   $��304,101,0,0q�6j   $	��Top=�6   $	��163��6�      Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre Completo��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6>   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *Nombre+6e   5+      �� 5,   
   -   5         ��Name$ btnEliminar��5,      $��Eliminar��6&   $
��Left=�69   $��101,343,0,0q�6T   $	��Top=�6i   $	��130��6�   $��46��6�   $��16(�6�   $2��,/WpfAppDataSet;component/Fonts/#Noto Sans TC)�6�   6�   �� 5-   
   -   5        $ btnRegresar��5-      $��Regresar��6&   $
��Left=�69   $��284,343,0,0q�6T   $	��Top=�6i   $	��130��6�   $��46��6�   $��16(�6�   $2��,/WpfAppDataSet;component/Fonts/#Noto Sans TC)�6�   6�   �� 5.   
   $
��Left=�6   $��
304,76,0,0q�6/   $
��Wrap=�6C   $��Autores��6W   $	��Top=�6f   $��17(�6~   $9��3/WpfAppDataSet;component/Fonts/#Noto Sans TC Medium)�6�   50      51      
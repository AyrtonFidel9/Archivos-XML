   M S B A M L   `   `   `  ����H  DWpfAppDataSet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WpfAppDataSet.VentanasWpfAppDataSet.Ventanas  5   	   ;"clr-namespace:WpfAppDataSet.ClasesWpfAppDataSet.Clases  5	   	   )    #WpfAppDataSet.Ventanas.AgregarLibro   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:WpfAppDataSet.Ventanas     5   	   h dMahApps.Metro.IconPacks.Fontaudio, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.RemixIcon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah	 dMahApps.Metro.IconPacks.Zondicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag
 cMahApps.Metro.IconPacks.Typicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.FeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae aMahApps.Metro.IconPacks.Modern, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am iMahApps.Metro.IconPacks.BootstrapIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Codicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.PixelartIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.WeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.MaterialLight, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Octicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae aMahApps.Metro.IconPacks.Entypo, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Unicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Microns, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.RadixIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.VaadinIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.SimpleIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.FileIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Ionicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.BoxIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.EvaIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.RPGAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai  eMahApps.Metro.IconPacks.PicolIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a^! ZMahApps.Metro.IconPacks, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am" iMahApps.Metro.IconPacks.MaterialDesign, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag# cMahApps.Metro.IconPacks.JamIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj$ fMahApps.Metro.IconPacks.ForkAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ay	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks    	 
                        ! " # $ 5   	   T% PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls % 5   	   *c"clr-namespace:WpfAppDataSet.Clases % 5	   	   -   5        ( % "MahApps.Metro.Controls.MetroWindow   Name$  VentanaIngreso��5   (    � Title$ Agregar Libro��5   	   $	��540��6   $	��630��6,   $	��630��68   $	��540��6G   $	��630��5   	   $	��540��6    � WindowStartupLocation$ CenterScreen=�6@    � 
ResizeMode$ CanMinimize=�6e    � 	Resources 5      '  !WpfAppDataSet.Clases.Validaciones   
validacion �� 
TargetType  validacion1 �� Property �� Value �� CornerRadius	 � ToolTip
 �� ElementName �� Path��%�  &	        &	        5   
   6.   �� 5   
   " ��6   .�5      ��  � ��$ Center=�62   �� 5       �@=�ErrorTemplate 5      �� 5      .R�5      ]� ��. .+�5      �� ���	#FFF20000$��right=�6<   $��5,0,0,0q�6S   $��20��6d   $��20��6o   $ 10��6{   	 5   $   �� $
 customAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�._�5   "   �� $��!��6,   $��center=�65   $��center=�6P   $
��Bold"�6m   
�������5   #   5      �� 5      $��customAdorner��68   $��Center=�6M   .v�5   "   �� ���	#FFF00101$��1q�6A   5      5      5      5       5!      5"      .��5#      � ��5$   
   �� 5%       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63    �� Opacity$ 0.905Q�6F    �� RelativeTransform 5&      V� 5'      .~�5(      ��  �� CenterY$	 0.5Q�6)    �� CenterX$	 0.5Q�67    �� ScaleY$ -3Q�6E    �� ScaleX$ 3Q�6Q   �� 5)       �� AngleY$ 0Q�6(    �� AngleX$ 0Q�63    �� CenterY$	 0.5Q�6>    �� CenterX$	 0.5Q�6L   �� 5*       �� Angle$	 -30Q�6*    �� CenterY$	 0.5Q�66    �� CenterX$	 0.5Q�6D   T� 5+      5,      .��5.      �  � Color$ White��6   � 5/      $ 	#FF7AB6FF��6    � Offset$ 1Q�61   � 50      $ 	#FF7AB6FF��6   $
 0.65Q�61   � 51      $ 	#FF7AB6FF��6   $ 0.475Q�61   � 52      $ White��6   $ 0.811Q�6-   � 53      $ 	#FF7AB6FF��6   $
 0.25Q�61   54      .+�56   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	dgAutores��56         SelectionMode$ Extended=�6&      AutoGenerateColumns .  $
��Left=�6�   $��1q�6�   $	��201��6�   $��332,146,0,0q�6�   $	��Top=�6�   $	��260��6�       Columns  57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn!   Header$! ID Autor��6%   "   Width5  /System.Windows.Controls.DataGridLengthConverter$" 90 67   1  +System.Windows.Controls.DataGridBoundColumn#   Binding# 6B   �� *	idAutor+  59      $! Nombre Completo��6%   $" * 6>   # 6H   �� *Nombre+5;      �� 5<   
   $
��Left=�6   $��
277,16,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $��95��6o   $	��101��6z   �� 6�   .F�5=      .  (MahApps.Metro.IconPacks.PackIconBoxIcons  $   Kind$$ SolidBookBookmark=�6-   $��82��6F   $��68��6R   5>      5?      �� 5@   
   $
��Left=�6   $��
35,147,0,0q�6/   $
��Wrap=�6C   $��ID Libro��6W   $	��Top=�6g   $��17(�6   $9��3/WpfAppDataSet;component/Fonts/#Noto Sans TC Medium)�6�   �� 5A   
   $
��Left=�6   $��
35,205,0,0q�6/   $
��Wrap=�6C   $��Titulo��6W   $	��Top=�6e   $��17(�6}   $9��3/WpfAppDataSet;component/Fonts/#Noto Sans TC Medium)�6�   �� 5B   
   $
��Left=�6   $��
35,262,0,0q�6/   $
��Wrap=�6C   $��	Editorial��6W   $	��Top=�6h   $��17(�6�   $9��3/WpfAppDataSet;component/Fonts/#Noto Sans TC Medium)�6�   �� 5C   
   $
��Left=�6   $��
35,322,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $��17(�6o   $9��3/WpfAppDataSet;component/Fonts/#Noto Sans TC Medium)�6}   �� 6�   $
�N° ��6�   �� 6�   $�Páginas��6�   6�   -	 % 'MahApps.Metro.Controls.MetroProgressBar	  5E   
   -   5        % 	 Name$% status��5E      $
��Left=�6/   & � Minimum$& 0Q�6J   ' � Maximum$	' 100Q�6V   $��20��6d   $��
35,112,0,0q�6p   $	��Top=�6�   $	��557��6�   �� 5F   
   -   5        ( ��Name$( 
txtIdLibro��5F      $
��Left=�6&   $��26��6A   $��145,147,0,0q�6j   ) �� TextWrapping$
) Wrap=�6   $	��Top=�6�   $	��144��6�   $��17(�6�   $8��2/WpfAppDataSet;component/Fonts/#Noto Sans TC Light)�6�   #��[ 5G      .��65   ��5H      �� 5I      $ Id�6   * �� Source#* [  6$   + �� ValidatesOnExceptions+ . , �� UpdateSourceTrigger$, PropertyChanged=�5K      - �� ValidationRules- 5L      5
  /System.Windows.Controls.DataErrorValidationRule
  5M      5O      .��5P      5R      �� 5S   
   -   5        $( 	txtTitulo��5S      $
��Left=�6%   $��26��6@   $��145,205,0,0q�6h   $
) Wrap=�6}   $	��Top=�6�   $	��144��6�   $��17(�6�   $8��2/WpfAppDataSet;component/Fonts/#Noto Sans TC Light)�6�   #��[ 5T      .��63   ��5U      �� 5V      $ Otros�6   #* [  6'   + . $, PropertyChanged=�5X      - 5Y      
  5Z      5\      .��5]      5^      �� 5_   
   -   5        $( txtEditorial��5_      $
��Left=�6(   $��26��6C   $��145,262,0,0q�6n   $
) Wrap=�6�   $	��Top=�6�   $	��144��6�   $��17(�6�   $8��2/WpfAppDataSet;component/Fonts/#Noto Sans TC Light)�6�   #��[ 5`      .��67   ��5a      �� 5b      $ Apellido�6   #* [  6*   + . $, PropertyChanged=�5d      - 5e      
  5f      5h      .��5i      5j      �� 5k   
   -   5        $( 
txtPaginas��5k      $
��Left=�6&   $��26��6A   $��145,322,0,0q�6j   $
) Wrap=�6   $	��Top=�5l      $	��144��6*   $��17(�66   $8��2/WpfAppDataSet;component/Fonts/#Noto Sans TC Light)�5m      #��[ 5n      .��67   ��5o      �� 5p      $ Numero�6   #* [  6(   + . $, PropertyChanged=�5r      - 5s      
  5t      5v      .��5w      5y      �� 5z   
   -   5        . ��Name$. btnIngresar��5z   $   $��Ingresar��6   $��16(�69   $
��Left=�6G   $��156,438,0,-35q�6b   $	��Top=�6y   $	��133��6�   $��48��6�   $2��,/WpfAppDataSet;component/Fonts/#Noto Sans TC)�6�   6�   �� 5{   
   -	   5        $. btnRegresar��5{   $   $��Regresar��6   $��16(�69   $
��Left=�6G   $��332,438,0,-35q�6b   $	��Top=�6y   $	��133��6�   $��48��6�   $2��,/WpfAppDataSet;component/Fonts/#Noto Sans TC)�6�   6�   �� 5|   
   $
��Left=�6   $��
35,378,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $��17(�6o   $9��3/WpfAppDataSet;component/Fonts/#Noto Sans TC Medium)�6}   �� 6�   $�ID Autor��6�   6�   �� 5}   
   -
   5        / ��Name$/ 
tbxIdAutor��5}      $
��Left=�6E   $��145,378,0,0q�6`   $
��Wrap=�6u   $	��Top=�6�   $��17(�6�   $8��2/WpfAppDataSet;component/Fonts/#Noto Sans TC Light)�6�   5      5�      5�      
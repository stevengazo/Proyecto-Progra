   M S B A M L   `   `   `  ����P  LWpfInterfacePrincipal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WpfInterfacePrincipalWpfInterfacePrincipal  5   	   *    $WpfInterfacePrincipal.WpfUbicaciones   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:WpfInterfacePrincipal     5   	     � Title$  Menú Ubicciones��5   	   $	��434��5	      $	��324��6   $��Center=�6   $��Center=�65    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      � $��0,0,2,-1q�6   ���	#FF1C8BAC � ColumnDefinitions 5   
   �� 5      $	��95* �6   �� 5      $	��14* �6   �� 5      $
��205* �6   .+�5   
   �� -   5         ��Name$ txtNombreUbicacion��5      $
��Left=�6.   $��23��6I   $��	41,50,0,0q�6U    �� TextWrapping$
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��121��6�   $��2��6�   �� 5   
   -   5         ��Name$ lblNombreUbicacion��5      $��Nombre Ubicación:��6,   $
��Left=�6H   $��	31,50,0,0q�6c   $	��Top=�6v   $��3��6�   �� 5   
   -   5        $ lblUbicacion��5      $$��Administración de Ubicaciones��6&   $
��Left=�6N   $��	31,10,0,0q�6i   $	��Top=�6|   $��16(�6�    J� RenderTransformOrigin$ 
0.33,0.677&�6�   $��3��6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ btnAgregarUbicacion��5      $��Agregar��6.   $
��Left=�6@   $��	44,81,0,0q�6[   $	��Top=�6n   $��75��6�   $��3��6�   6�   �� 5   
   -   5        $ btnModificarUbicacion��5      $��	Modificar��60   $
��Left=�6D   $��	66,81,0,0q�6_   $	��Top=�6r   $��75��6�   $��2��6�   6�   �� 5   
   -   5        $ btnEliminarUbicacion��5      $��Eliminar��6/   $
��Left=�6B   $��
44,122,0,0q�6]   $	��Top=�6q   $��75��6�   $��3��6�   6�   �� 5   
   -   5        $ 
btnMostrar��5      $��Mostrar��6%   $
��Left=�67   $��
66,122,0,0q�6R   $	��Top=�6f   $��75��6~   $��2��6�   6�   �� 5   
   -   5         ��Name$ listViewUbicacion��5      $
��Left=�6.   $	��215��6I   $��
31,164,0,0q�6V   $	��Top=�6j   $	��238��6�   $��3��6�   ���	#FFE2E2E2���	#FF3A3939���	#FF110D0D$
��Bold"�6  	 �� View	 5      �� 5      .P�5      �� $��Ubicaciones��6%   
 �� Width$	
 200��6:    �� DisplayMemberBinding 6F   �� *nombreUbicacion+5      5       5!      5"      
   M S B A M L   `   `   `  ���� C  ?Winlight, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WinlightWinlight      Winlight.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:Winlight     -     � Title$  WinSpotFetcher��$��239.716��$��392.667�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ CanMinimize=� � AllowsTransparency .  � WindowStyle$
 None=���Z�  � 	Resources    SymonsButtonStyle �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� Triggers P� Property P� Value��%�   &	        �� " ��.���  � �� �� "	 ��.R��� ���� " ��.���  � ��$ 1q���  � ��
 �����
 P�  �@J�IsMouseOver . . ���  � �� �	#4CFFFFFF._�� 
������ .+��� $��Center=�$��Center=�.���  J� Opacity$
 0.98Q�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFB5CD1F�� � Offset$ 1Q�� $ 	#FF111111��$
 0.98Q�.+��� -    ��Name$ BrowseButton��#��[  $��Browse��$
��Left=�$	��Top=�$��85��$��
92,104,0,0q�
�������
�������$��34��$��15(���Z� �� -   $ SearchButton��#��[  $��Search��$
��Left=�$	��Top=�$��85��$��209,104,0,0q�
�������
�������$��34��$��15(��� -    ��Name$ 	PathLabel��$�� ��$
��Left=�$	��Top=�$��
45,210,0,0q����	#FFB5CD1F$��13(��� -   $ NotActualPathLabel��$��Path:��$
��Left=�$	��Top=�$��	0,210,0,0q�
�������$��13(��� -   $ 
TitleLabel��$��Winlight��$��Center=�$
��Left=�$	��Top=����	#FFB5CD1F$��40(�$��Bariol Regular)� J� IsHitTestVisible .  $	��393��$��0,10,0,0q���Z� �� -   $ CloseButton��#��[  $��X��$	��Top=�
�������
������� �� IsCancel . $��
356,10,0,0q�$��9(�$��18��$
��Left=�$��27����Z� �� -   $ 
OpenButton��#��[  $
��Open��$
��Left=�$	��Top=�$��39��$��	6,213,0,0q�
�������
�������$��21��$��13(��� -	   $ UsernameLabel��$�� ��$
��Left=�$	��Top=�$��	61,-5,0,0q����	#FFB5CD1F$��13(���Z� �� $��	Welcome, ��$
��Left=�$	��Top=�
�������$��0,-5,0,0q�$��13(�$��66��
   M S B A M L   `   `   `  ����C  ?Timeline, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:软测期末项目软测期末项目  5   	       Timeline.login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:软测期末项目     5   	   -   5          � 
ResizeMode$  NoResize=�5       � WindowStartupLocation$ CenterScreen=�5	       � Title$ Login��5
      $	��500��6   $	��700��6&    � WindowStyle$
 None=�63    � AllowsTransparency . ��6`   Z�  � 	Resources 5         ButtonStyle �� 
TargetType �� Property �� Value	 �� 
TargetType
 ��Name �� StrokeMiterLimit �� RadiusX �� RadiusY ��Name J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName �� Color��%w  &	        �� 5   
   " ��6$   .�5      ��  � ��
 �����6+   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      � .+�5      �� $
 	Rectangle��6(   ���	#FFFFFFFF$ 1.000000Q�6N   $��0.500000��6j   $ 20��6�   $ 20��6�   ���	#FF7777775      �� 5      $ ContentPresenter��6/   # z 6I   #��z��6�   #��z��6�   ��. 6  5       5      P� 5       �@J�IsMouseOver . . �5   "   �� $ 	Rectangle��69    � �� 5   &   �� 5   *   $ White��6:   6J   5   #   �� 5   "    � ��
 �����6S   5      5!      5#      5$      5%      .��5&      � ��6   �� *Width+ �� ElementName$ w����63   �� *Height+$ w�� � RowDefinitions 5'   
   �� 5(      $	��150 �6   �� 5)      $��50 �6   �� 5*      $��50 �6   �� 5+      .+�5-   
   �� $��4��6   
�������$��3q�67    �� CornerRadius$ 20��6K    J� Opacity$ 1Q�6_   $��4��6m   ��5.      �� 5/       �� ImageSource$ Image/bgm.jpg��6   6;   51      �� 52   
   -   5        $��登录��52        MyWpfButton#��[ 60   $
��Left=�6a   $��300,43.026,0,0q�6|   $��3��6�   $	��Top=�6�   $	��149��6�    J� RenderTransformOrigin$ 0.382,-0.19&�6�   $��44��6�   $��24(�6�   ���	#FFEEEE55���	#FF1E09156  �� 54   
   $
��Left=�6   $��68��6/   $��
186,71,0,0q�6;   $
��Wrap=�6O   $��45(�6c   $��欢迎来到Timeline��6q   $	��Top=�6�   $	��381��6�   �� 55   
   -   5         ��Name$ UsernameBox��55      $��Center=�6B   $��1,1,1,1q�6]   $��30��6w   $��300,19.766,251.052,0.104q�6�    �� SelectionBrush �	#FF041507$��20(�6�   $��1��6�   �� 56   
   -   5         ��Name$ UsernameBlock��56      
������� J� IsHitTestVisible .  $
��Left=�6Z   $��300,36.766,0,0q�6u   $
��Wrap=�6�   $��请输入账号��6�   $	��Top=�6�   $��85��6�   $��1��6�   $��2��6�   G� 57   
   -   5         G�Name$ PwdBox��57      $��2��6B   $��Center=�6O   $��1,1,1,1q�6j   $��30��6�   $ ��300,19.896,252.052,249.948q�6�   $��20(�6�   $��2��6�   �� 58   
   -   5        $ PwdBlock��58      
������� .  $
��Left=�6U   $��300,35.896,0,0q�6q   $��2��6�   $
��Wrap=�6�   $��请输入密码��6�   $	��Top=�6�   $��74��6�   $ 0.642,0.364&�6�   $��2��6�   �� 5:   
   -   5        $��	去注册��5:      #��[ 6   $
��Left=�6P   $��299,118.026,0,0q�6k   $��3��6�   $	��Top=�6�   $	��149��6�   $ 0.382,-0.19&�6�   $��44��6�   $��24(�6�   ���	#FFEEEE55���	#FF1E09156!  �� 5<   
   -   5        $��Button1��5<      #��[  6    $��31��6Y   $��X��6d   $��Right=�6p   $��	0,1,0,120q�6�   
���   ����	#FF183FD2���	#FF3D33D7$ 	0.511,0.5&�6�   �� 5=   
   $��15(�6   $
��Left=�6"   $��234,26.766,0,48.974q�6=   $��1��6Z   $
��Wrap=�6g   $��账号��6{   $��40��6�   $��2��6�   �� 5>   
   $��15(�6   $
��Left=�6"   $��234,25.896,0,249.948q�6=   $��2��6[   $
��Wrap=�6h   $��密码��6|   $��50��6�   $��2��6�   5@      5A      
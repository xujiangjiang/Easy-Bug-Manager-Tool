   M S B A M L   `   `   `  ����M  IEasyBugManagerTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:EasyBugManagerToolEasyBugManagerTool  5      (    "EasyBugManagerTool.BrowseUiControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:EasyBugManagerTool     5      -   5        $��BrowseUiUserControl��5      .��5      � .+�5   
   �� -   5        $��BackgroundBorder��5      $	��580��5      $	��222��6!   $��
18,-90,0,0q�6.   
�������  �� CornerRadius$  15��5   (    J� Opacity$ 1Q�5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         	Direction$ 0Q�6#      ShadowDepth$ 0Q�61      
BlurRadius$ 20Q�6A      Opacity$
 0.25Q�5   '      Color$ 	#FF5B5B5B��66   6J   5      � 5   
   $	��580��6   $	��222��6   $��
18,-90,0,0q�6(   .+�5      �� $��39.5,20,0,0q�6   $	��Top=�5        $
��Left=�68      ZcoolButter.FontFamily#��[  5"       $��31(�5#       ���#787878��5!       ��  �� ElementName$ BrowseUiUserControl��	 �� Path$	 TitleString�5#   .   �� 5'      
 �� Orientation$
 
Horizontal=�6   $��	60,20,0,0q�62   $
��Left=�5(   !   $��Center=�6<   .+�5+      �� $��Center=�6   $
��Left=�67   #��[  5-   $   $��22(�5.   $   ���#c0c0c0��5,   $   �� $ BrowseUiUserControl��$	 LocationString�5.   2   +   %EasyBugManagerTool.ImageButtonControl  51      +   %EasyBugManagerTool.ImageButtonControl   Click$ BrowseButtonControl_Click��58   3   $��46��51   +   $��40��66   $��35,0,0,0q�52   3   $	��Top=�53   3      PressAnimationSize$ 	0.85,0.85&�54   3    . *OtherUi.BrowseButton.MouseEnter.ImageBrush   MouseEnterImage# �  55   3    . *OtherUi.BrowseButton.MouseLeave.ImageBrush   MouseLeaveImage# �  56   3   58   3   �� 5;      $	��300��5<   "   $��42��61   $��	10,4,15,0q�5=   "   $��0,0,10,0q�66   $y�Visible=�5>   "   $��0q�5@   "    �� SelectionBrush
 �����$��Center=�5B   "     ZcoolLiterary.FontFamily#��[ 5C   "   $��16(�5D   "   
������ ���	#FFA8A8A8 �� TextWrapping$
 Wrap=�5F   "    �� 
IsReadOnly . " �� VerticalScrollBarVisibility$
 Auto=�5H   "   ��5;      �� $ BrowseUiUserControl��$	 
PathString�5H   "   5K      �� 5P      -   5        $��TipTextBlock��5P      $��	40,60,0,0q�5Q       $
��Left=�5R      $	��Top=�67   $	 0.8Q�5T      #��[ 5U      $��18(�5V       �� Padding$ 5,4,5,0q�6*   ���#852a2a��5S      �� $ BrowseUiUserControl��$	 	TipString�5V   <   5[      �� 5_   
   $��83��6   $��590,-179,0,0q�6    $��Center=�5`      $��Center=�66   .+�5c      )   #EasyBugManagerTool.YesButtonControl  )   #EasyBugManagerTool.YesButtonControl   Click$ YesButtonControl_Click��5i   )   $��73��5c   %   $��62��60   $��0,0,0,0q�6<      PressAnimationSize$ 	0.85,0.85&�5d   )    * &MainUi.YesButton.MouseLeave.ImageBrush   MouseLeaveImage# �  5e   )    * &MainUi.YesButton.MouseEnter.ImageBrush   MouseEnterImage# �  5f   )   $��Right=�5g   )   5i   )   (   "EasyBugManagerTool.NoButtonControl  5l      (   "EasyBugManagerTool.NoButtonControl   Click$ NoButtonControl_Click��5q   (   $��70��5l   $   $��57��6/   $��2,3,0,0q�6;      PressAnimationSize$ 	0.85,0.85&�5m   (    ) %MainUi.NoButton.MouseLeave.ImageBrush   MouseLeaveImage# �  5n   (    ) %MainUi.NoButton.MouseEnter.ImageBrush   MouseEnterImage# �  5o   (   5q   (   5s      � 5w   
   -   5        $��ForegroundCanvas��5w      $
 0.75Q�5x      $y�	Collapsed=�5y      .+�5|      �� $	��580��6   $	��222��6!   $��
18,-90,0,0q�6.   
���   �$  14��5}   (   $ 1Q�5~      �� 5�      $��83��6   $��593,-179,0,0q�6$   $��Center=�5�      $��Center=�66   .+�5�      �� $��73��6   $��62��6$   $��0,0,0,0q�60   $��Right=�5�       * &MainUi.Foreground.YesButton.ImageBrush#���  5�        5�      $��70��6(   $��57��63   $��1,3,0,0q�6?    )	 %MainUi.Foreground.NoButton.ImageBrush#��� 	 5�   (   5�      5�      5�      5�      